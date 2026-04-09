using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Globalization;
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            //LeggiFile();  //inutile se tanto carichiamo informazioni all' avvio dalla città delle impostazioni
            CaricaFormImpostazioni(); //carica form impostazioni all' avvio del form principale
            await Aggiornamento();
            dgv_tempo_temperatura.DataSource = lista;   //abbino la lista e le sue info al dgv        
        }

        private void ScriviFile()
        {

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

        private void btn_esci_Click(object sender, EventArgs e)
        {
            formImpostazioni.Close();
            this.Close();
        }

        private async void btn_avvia_Click(object sender, EventArgs e)
        {
            await Aggiornamento();
        }

        private void lbl_nomi_Click(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult risposta = MessageBox.Show("Salvare gli ultimi dati scaricati in un file?", "Salvataggio Dati", MessageBoxButtons.YesNo);
            if (risposta == DialogResult.Yes)
            {
                ScriviFile();
                formImpostazioni.Close(); //chiude anche form impostazioni
            }
            SalvaImpostazioniSuFile();  //così quando si riapre ci si ritrova le informazioni dell' ultima volta

        }

        private void SalvaImpostazioniSuFile()
        {
            string pathImp;
            try
            {
                pathImp = Path.Combine(Directory.GetCurrentDirectory(), "../../../File/Impostazioni.json");
                if (!File.Exists(pathImp))
                {
                    File.Create(pathImp).Close(); //cosi il file non risulta utilizzato da un altro processo
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore nel trovare il file");
                return;
            }

            try
            {
                string txt = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(pathImp, txt);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore nella lettura del file");
            }

        }

        private void CaricaFormImpostazioni()
        {
            //lo carica all' avvio del form prinicipale e non lo chiude mai ma semplicemente lo nascone
            //in modo tale da non dover ricaricare tutto il file json ogni volta
            formImpostazioni = new FImpostazioni();
            formImpostazioni.SalvaImpostazioni += OnSalvaImpostazioni;
            try
            {
                string pathImp = Path.Combine(Directory.GetCurrentDirectory(), "../../../File/Impostazioni.json");
                if (File.Exists(pathImp))
                {
                    string txt = File.ReadAllText(pathImp);
                    this.settings = JsonConvert.DeserializeObject<Impostazioni>(txt);
                }
                else
                {
                    File.Create(pathImp).Close(); //cosi il file non risulta utilizzato da un altro processo
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore caricamento imposazioni");  
            }
            formImpostazioni.AggiornaGraficaControlli(this.settings);
        }

        private async Task OnSalvaImpostazioni(object sender, ImpostazioniEventArgs e)
        {
            Impostazioni imp = e.impostazioni;
            settings = imp;
            await Aggiornamento();
        }

        //fare questa funzione asincrona METTERE ASYNC SE SERVE ALTRIMENTI TOGLIERE
        //TUTTO IL ASYNC AWAIT TASK DAPPERTUTTO PK NON SERVIREBBE PIU' A NIENTE
        private async Task AggiornaDati(Meteo m, QualitaAria a)
        {
            //qui dentro popolare la lista con i valori presi dall' api
            lista.Clear();
            if ((m == null && a == null) || (m?.time == null && a?.time == null))
            {
                MessageBox.Show("Dati non disponibili", "Attenzione", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                return;
            }
            int countMeteo = m?.time?.Count ?? 0;  //setta il count a 0 se è null
            int countAria = a?.time?.Count ?? 0;
            int max = Math.Max(countMeteo,countAria);
   

            DateTime data = DateTime.Now;  //non prenderà mai il valore di datetime .now serve solo per settarla inzialmente
            float temp = 0;
            float inq = 0;

            for (int i = 0; i < max; i++)
            {

                if (m != null)
                {
                    data = DateTime.Parse(m.time[i]);
                    temp = (float)m.temperature_2m[i].Value;
                }
                else 
                {
                    //se non c'è il meteo, prendiamo la data dalla qualità dell'aria
                    data = DateTime.Parse(a.time[i]);
                    
                }
                if (a != null)
                    inq = (float)a.pm2_5[i].Value;


                lista.Add(new CInfo(data, temp, inq));
            }
            CreaGrafico();
            lbl_citta.Text = $"Città: {settings.citta.ToString()}";
        }
        
        /*private async Task AggiornaDati(Meteo m, QualitaAria a)
        {
            lista.Clear();

            // Se entrambi sono null, non c'è nulla da fare
            if (m == null && a == null)
            {
                MessageBox.Show("Dati non disponibili", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // operatore ?. per evitare crash se uno dei due è null
            int countMeteo = m?.time?.Count ?? 0; //?? significa se è null allora metti a 0
            int countAria = a?.time?.Count ?? 0;
            int maxIterazioni = Math.Max(countMeteo, countAria);

            if (maxIterazioni == 0) return;

            DateTime data;
            float temp = 0;
            float inq = 0;

            for (int i = 0; i < maxIterazioni; i++)
            {
   

                // --- Gestione Meteo ---
                if (m != null)
                {
                    data = DateTime.Parse(m.time[i]);
                    temp = (float)m.temperature_2m[i].Value;
                }
                else if (a != null)
                {
                    // Se non c'è il meteo, prendiamo la data dalla qualità dell'aria
                    data = DateTime.Parse(a.time[i]);
                }
                else continue; // Se non abbiamo nemmeno una data valida, saltiamo l'ora i

                // --- Gestione Aria ---
                if (a != null && i < countAria && a.pm2_5[i] != null)
                {
                    inq = (float)a.pm2_5[i].Value;
                }

                // Aggiungiamo il record alla lista
                lista.Add(new CInfo(data, temp, inq));
            }

            CreaGrafico();
        }
        */
        private async Task Aggiornamento()
        {

            //perchè file imp...json potrebbe non esistere o pk corrotto
            if (settings == null || settings.citta == null)
            {
                //se mancano le impostazioni, esci dal metodo senza fare nulla
                return;
            }

            Task<Meteo> tMeteo = null;
            Task<QualitaAria> tAria = null;

            string lat = settings.citta.Latitudine.ToString(CultureInfo.InvariantCulture);
            string lon = settings.citta.Longitudine.ToString(CultureInfo.InvariantCulture);

            if (settings.flags.Contains(DatoDaAnalizzare.Meteo))
            {
                string urlMeteo = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&hourly=temperature_2m&timezone=Europe%2FRome&past_days={settings.giorni}&forecast_days=1";
                tMeteo = LeggiDatiAPI<Meteo>(urlMeteo);
            }

            if (settings.flags.Contains(DatoDaAnalizzare.Aria))
            {
                string urlAria = $"https://air-quality-api.open-meteo.com/v1/air-quality?latitude={lat}&longitude={lon}&hourly=pm2_5&timezone=Europe%2FRome&past_days={settings.giorni}&forecast_days=1";
                tAria = LeggiDatiAPI<QualitaAria>(urlAria);
            }


            Meteo m = null;
            QualitaAria a = null;
            if (tMeteo != null)
                m = await tMeteo;

            if (tAria != null)
                a = await tAria;

            await AggiornaDati(m, a);
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            using (FGuida form = new FGuida())
            {
                form.ShowDialog();
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

    [JsonConverter(typeof(StringEnumConverter))]    //non salva indice ma stringa quindi al posto di 0 salva "Meteo"
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
