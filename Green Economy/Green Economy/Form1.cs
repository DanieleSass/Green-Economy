using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using Dapper;   //per database
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
namespace Green_Economy
{
    public partial class Form1 : Form
    {

        //API OPEN-METEO = https://open-meteo.com/en/docs

        BindingList<CInfo> lista;
        Impostazioni settings;
        FImpostazioni formImpostazioni; //lo creo come variabile di classe
                                        //così lo posso nascondere e
                                        //mostrare senza doverlo ricaricare ogni volta
        string path;
        //FAI BEGIN INVOKE PER GESTIRE THREAD UI
        static readonly HttpClient client = new(); //comunica col server, riceve i dati(socket)
        //classe per fare richiesta http, statico così esiste una sola istanza condivisa
        //non serve crearne una nuova ogni volta che si fa una richiesta, sennò socket intasati
        public Form1()
        {
            InitializeComponent();
            lista = new();
            path = Path.Combine(Directory.GetCurrentDirectory(), "../../../File");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(Directory.GetCurrentDirectory(), "../../../File/dati.json");
            if (!File.Exists(path))
            {
                File.Create(path).Close(); //cosi il file non risulta utilizzato da un altro processo
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeggiFile();
            dgv_tempo_temperatura.DataSource = lista;   //abbino la lista e le sue info al dgv
            CreaGrafico();
            CaricaFormImpostazioni(); //carica form impostazioni all' avvio del form principale
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
            /*
            using (FImpostazioni form = new FImpostazioni())
            {
                form.SalvaImpostazioni += OnSalvaImpostazioni;
                form.ShowDialog();
            }
            */
            formImpostazioni.ShowDialog();
        }

        private void CaricaFormImpostazioni()
        {
            //lo carica all' avvio del form prinicipale e non lo chiude mai ma semplicemente lo nascone
            //in modo tale da non dover ricaricare tutto il file json ogni volta
            formImpostazioni = new FImpostazioni();
            formImpostazioni.SalvaImpostazioni += OnSalvaImpostazioni;

        }

        private async void OnSalvaImpostazioni(object sender, ImpostazioniEventArgs e)
        {
            Impostazioni imp = e.impostazioni;
            settings = imp;
            Aggiornamento();
        }

        //fare questa funzione asincrona
        private void AggiornaDati(Meteo m, QualitaAria a)
        {
            //qui dentro popolare la lista con i valori presi dall' api
            lista.Clear();
            if (m == null || a == null || m.time == null || a.time == null)
            {
                MessageBox.Show("Dati non disponibili", "Attenzione", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                return;
            }

            int min = Math.Min(m.time.Count, a.time.Count);
            CInfo c;

            for (int i = 0; i < min; i++)
            {
                //se anche un solo dato è null allora lo skippa e lo salta
                if (m.temperature_2m[i] == null || a.pm2_5[i] == null || m.time[i] == null)
                {
                    continue;
                }
                c = new CInfo(DateTime.Parse(m.time[i]), (float)m.temperature_2m[i].Value, (float)a.pm2_5[i].Value);
                lista.Add(c);
            }
            CreaGrafico();
        }
        private async Task Aggiornamento()
        {
            Task<Meteo> tMeteo = null;
            Task<QualitaAria> tAria = null;

            List<Task> tasks = new List<Task>();


            if (settings.flags.Contains(DatoDaAnalizzare.Meteo))
            {
                string lat = settings.citta.Latitudine.ToString(CultureInfo.InvariantCulture);
                string lon = settings.citta.Longitudine.ToString(CultureInfo.InvariantCulture);

                // Assicurati che settings.giorni sia tra 0 e 92
                string urlMeteo = $"https://api.open-meteo.com/v1/forecast" +
                    $"?latitude={lat}&longitude={lon}" +
                    $"&hourly=temperature_2m" +
                    $"&timezone=Europe%2FRome" +
                    $"&past_days={settings.giorni}";

                tMeteo = LeggiDatiAPI<Meteo>(urlMeteo);
            }

            if (settings.flags.Contains(DatoDaAnalizzare.Aria))
            {
                string lat = settings.citta.Latitudine.ToString(CultureInfo.InvariantCulture);
                string lon = settings.citta.Longitudine.ToString(CultureInfo.InvariantCulture);

                string urlAria = $"https://air-quality-api.open-meteo.com/v1/air-quality" +
                    $"?latitude={lat}&longitude={lon}" +
                    $"&hourly=pm2_5" +
                    $"&timezone=Europe%2FRome" +
                    $"&past_days={settings.giorni}";

                tAria = LeggiDatiAPI<QualitaAria>(urlAria);
            }


            //letti i dati fare qualcosa, tipo mostrarli, salvarli nella lista, fare controlli null
            //  SE ANCHE SOLO UN DATO è NULL (O TEMP, O INQUIN, O DATA è NULL), SCARATARE INTERA RIGA   

            AggiornaDati(await tMeteo, await tAria);  //TROVARE ALTERNATIVA A RESULT pk sincrono
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult risposta = MessageBox.Show("Salvare gli ultimi dati scaricati in un file?", "Salvataggio Dati", MessageBoxButtons.YesNo);
            if (risposta == DialogResult.Yes)
            {
                ScriviFile();
                formImpostazioni.Close(); //chiude anche form impostazioni
            }

        }

        private void lbl_nomi_Click(object sender, EventArgs e)
        {
            //easter egg

            //da cambiare
            MessageBox.Show("SORPRESA");
        }

        private void btn_esci_Click(object sender, EventArgs e)
        {
            formImpostazioni.Close();
            this.Close();
        }

        private async void btn_avvia_Click(object sender, EventArgs e)
        {
            await Aggiornamento();
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
