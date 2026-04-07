using Dapper;   //per database
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System.ComponentModel;
namespace Green_Economy
{
    public partial class Form1 : Form
    {

        //API OPEN-METEO = https://open-meteo.com/en/docs

        BindingList<CInfo> lista;
        string path;

        static readonly HttpClient client = new(); //comunica col server, riceve i dati(socket)
        //classe per fare richiesta http, statico così esiste una sola istanza condivisa
        //non serve crearne una nuova ogni volta che si fa una richiesta, sennò socket intasati
        public Form1()
        {
            InitializeComponent();
            lista = new();
            path = Path.Combine(Directory.GetCurrentDirectory(), "../../File/dati.json");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeggiFile();
            dgv_tempo_temperatura.DataSource = lista;   //abbino la lista e le sue info al dgv
            CInfo c;
            for (int i = 0; i < 10; i++)  //serve per creare
            {
                c = new(DateTime.Now.AddDays(-i * (i % 2)), 20 + i, i * (i % 2));

                lista.Add(c);
            }
            CreaGrafico();
        }

        private void ScriviFile()
        {

            //fare controllo se esiste cartella e file, altrimenti crearli
            try
            {
                string txt = JsonConvert.SerializeObject(lista, Formatting.Indented);
                File.WriteAllText(path, txt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }
        private void LeggiFile()
        {
            //fare controllo se esiste cartella e file, altrimenti crearli
            try
            {
                string txt = File.ReadAllText(path);
                lista = JsonConvert.DeserializeObject<BindingList<CInfo>>(txt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }

        }

        private void CreaGrafico()
        {

            if (lista == null || lista.Count == 0)
            {
                MessageBox.Show("Nessun elemento da valutare", "Attenzione", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                return;
            }

            //pulisce grafico precedente
            plt_tempo_temperatura.Plot.Clear();

            //uso array perchè la libreria dovrebbe conveertitre autonomamente in array = + dispensioso
            double[] date = new double[lista.Count];
            double[] temp = new double[lista.Count];
            double[] inqu = new double[lista.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                date[i] = lista[i].Data.ToOADate(); //converte datetime in double
                temp[i] = lista[i].Temperatura;
                inqu[i] = lista[i].Inquinamento;
            }

            //prende i valori e crea scatter = grafico a dispersione (x,y) = (date, temp)+collega i punti
            var grafico1 = plt_tempo_temperatura.Plot.Add.Scatter(date, temp);
            //permette di regolare le curve, i colori ecc, (vedi sotto)

            grafico1.LegendText = "Temperatura";
            grafico1.Smooth = true;     //collega i punti con una linea curva (effetto scala logaritmica)
            grafico1.SmoothTension = 0.5; //regola la tensione della curva (0-1) = più basso più curva, più alto più lineare
            grafico1.Color = ScottPlot.Colors.Blue;


            var grafico2 = plt_tempo_temperatura.Plot.Add.Scatter(date, inqu);
            grafico2.LegendText = "Inquinamento";
            grafico2.Smooth = true;
            grafico2.SmoothTension = 0.5;
            grafico2.Color = ScottPlot.Colors.Red;

            //converte i numeri double di array di date in formato leggibile
            //anche a seconda di quanto si zooma (e di quanto spazio si ha per visualizzarle)
            plt_tempo_temperatura.Plot.Axes.DateTimeTicksBottom();

            plt_tempo_temperatura.Plot.ShowLegend(); //mostra legenda (già di default)
            plt_tempo_temperatura.Refresh();    //aggiorna graficamente(ridondante, per sicurezza)
        }

        private void SalvaSuDatabase()
        {
            string connessione = "Data Source=MeteoDati.db";
            try
            {
                using (var database = new SqliteConnection(connessione))
                {
                    database.Open();
                    database.Execute(@"CREATE TABLE IF NOT EXISTS StoricoMeteo (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Data DATETIME,
                    Temperatura REAL,
                    Inquinamento REAL
                    )"
                    );

                    //passo direttamente la lista, Dapper legge le proprietà di CInfo e 
                    //le inserisce in automatico nel database riga per riga, senza dover scrivere un ciclo for o foreach
                    string sql = "INSERT INTO StoricoMeteo (Data, Temperatura, Inquinamento) VALUES (@Data, @Temperatura, @Inquinamento)";
                    database.Execute(sql, lista);
                    //MessageBox.Show("Dati salvati su database con successo!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }

        private void ScriviSuDGV()
        {
            //oppure fare inserimento manuale riga per riga

            //scolleghi la lista
            dgv_tempo_temperatura.DataSource = null;
            //la ricolleghi così dgv è costretto a rileggere tutto
            dgv_tempo_temperatura.DataSource = lista;
        }

        private void btn_rapporto_misure_Click(object sender, EventArgs e)
        {
            using (FRelazioneDati form = new FRelazioneDati(lista))
            {
                form.ShowDialog();
            }
        }

        private void btn_scelta_Click(object sender, EventArgs e)
        {
            using (FImpostazioni form = new FImpostazioni())
            {
                form.SalvaImpostazioni += OnSalvaImpostazioni;
                form.ShowDialog();
            }
        }

        private async Task OnSalvaImpostazioni(object sender, ImpostazioniEventArgs e)
        {
            Impostazioni imp = e.impostazioni;
            double longitudine = imp.citta.Longitudine;
            double latitudine = imp.citta.Latitudine;

            Task<Meteo> tMeteo = null;
            Task<QualitaAria> tAria = null;

            if (imp.flags.Contains(DatoDaAnalizzare.Meteo))
            {
                string urlMeteo = $"https://api.open-meteo.com/v1/forecast" +
                $"?latitude={latitudine}&longitude={longitudine}" +
                $"&hourly=temperature_2m" +
                $"&timezone=Europe%2FRome" +
                $"&past_days={imp.giorni}";
                tMeteo=LeggiDatiAPI<Meteo>(urlMeteo);
            }


            if (imp.flags.Contains(DatoDaAnalizzare.Aria))
            {
                string urlAria = $"https://air-quality-api.open-meteo.com/v1/air-quality" +
                $"?latitude={latitudine}&longitude={longitudine}" +
                $"&hourly=pm2_5" +
                $"&timezone=Europe%2FRome" +
                $"&past_days={imp.giorni}";

                tAria= LeggiDatiAPI<QualitaAria>(urlAria);
            }

            List<Task> tasks = new List<Task>();
            tasks.Add(tMeteo);
            tasks.Add(tAria);
            await Task.WhenAll(tasks);


            //letti i dati fare qualcosa, tipo mostrarli, salvarli nella lista, fare controlli null
            //  SE ANCHE SOLO UN DATO è NULL (O TEMP, O INQUIN, O DATA è NULL), SCARATARE INTERA RIGA   
            
            AggiornaDati(tasks);
        }

        //fare questa funzione asincrona
        private void AggiornaDati(List<Task> info)
        {
            //qui dentro popolare la lista con i valori presi dall' api
            lista.Clear();
            Meteo m;
            QualitaAria a;
            if (info.Contains(Meteo))
            {
                m = info.OfType<Meteo>().FirstOrDefault();
            }
            if (info.Contains(QualitaAria))
            {
                a = info.OfType<QualitaAria>().FirstOrDefault();
            }
            int min = Math.Min(m.time.Count, a.time.Count);
            CInfo c;
            for(int i =0; i < min; i++)
            {
                if (m.temperature_2m[i] == null)
                    c = new(DateTime.Parse(m.time[i]), 0, 0);
                else
                    c = new(DateTime.Parse(m.time[i]), (float)(m.temperature_2m[i] ?? 0), (float)(a.pm2_5[i]));
                lista.Add(c);
            }
            CreaGrafico();
            SalvaSuDatabase();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult risposta = MessageBox.Show("Salvare gli ultimi dati scaricati in un file?", "Salvataggio Dati", MessageBoxButtons.YesNo);
            if (risposta == DialogResult.Yes)
            {
                ScriviFile();
            }

        }



        //FIXARE ASYNC VOID-->TASK

        private async Task btn_avvia_Click_1(object sender, EventArgs e)
        {
            try
            {
                Task<Meteo> taskMeteo = LeggiMeteoDaAPI(7);
                Task<QualitaAria> taskAria = LeggiAriaDaAPI(7);

                //aspetta che le finiscano di leggere i dati entrambe
                Meteo meteo = await taskMeteo;
                QualitaAria aria = await taskAria;

                //for (int i = 0; i < 10; i++)
                lista.Clear();
                CInfo c;

                //fixare questo, cioè bisogna fare controllo != null dentro for per evitare di perdere dati di uno dei 2
                int numeroCicli = Math.Min(meteo.time.Count, aria.time.Count); //per evitare errori se i dati hanno lunghezze diverse
                for (int i = 0; i < numeroCicli; i++)  //mostra tutti i dati raccolti
                {
                    if (meteo.temperature_2m[i] == null)
                        c = new(DateTime.Parse(meteo.time[i]), 0, 0);
                    else
                        c = new(DateTime.Parse(meteo.time[i]), (float)(meteo.temperature_2m[i] ?? 0), (float)(aria.pm2_5[i]));
                    lista.Add(c);
                }
                CreaGrafico();
                SalvaSuDatabase();
                //ScriviSuDGV();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Errore di rete: " + ex.Message);
            }
            catch (Exception ex)//generica
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }




        private async Task<T> LeggiDatiAPI<T>(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string txt = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<MessaggioAPI<T>>(txt).hourly;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
            return default;
        }
    }

    public enum DatoDaAnalizzare    //parametro per capire cosa è richiesto dall' utente
    {
        Meteo,
        Aria,
        //eventuali altri, facilmente scalabile
    }



    //i nomi delle proprietà devono essere identici a quelli del json dell' api
    //quindi non scelti da noi
    //perchè quando deserializza la stringa in oggetto meteo/aria, deve cercaree gli attributi
    //con lo stesso nome dei dati (contenuti nella stringa) presi dall' api

    public class MessaggioAPI<T>    //necessaria per la struttura interna del json dell' api
                                    //cont <T> riutilizziamo anche la stessa clase
    {
        public T hourly { get; set; }
        public MessaggioAPI() { }
    }

    public class Meteo
    {
        public List<string> time { get; set; }
        public List<double?> temperature_2m { get; set; }
        public Meteo() { }
    }

    public class QualitaAria
    {
        public List<string> time { get; set; }
        public List<double?> pm2_5 { get; set; }
        public List<double?> european_aqi { get; set; }
        public QualitaAria() { }
    }
}
