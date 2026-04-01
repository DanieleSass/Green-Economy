using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Green_Economy
{
    public partial class Form1 : Form
    {

        //API OPEN-METEO = https://open-meteo.com/en/docs

        List<CInfo> lista;
        string path;

        private static readonly HttpClient client = new();
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
            CInfo c;
            for (int i = 0; i < 10; i++)
            {
                c = new(DateTime.Now.AddDays(-i * (i % 2)), 20 + i);
                
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
                lista = JsonConvert.DeserializeObject<List<CInfo>>(txt);
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
                MessageBox.Show("Nessun elemento da valutare", "Errore", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                return;
            }

            //pulisce grafico precedente
            plt_tempo_temperatura.Plot.Clear();

            //uso array perchè la libreria dovrebbe conveertitre autonomamente in array = + dispensioso
            double[] date = new double[lista.Count];
            double[] temp = new double[lista.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                date[i] = lista[i].data.ToOADate();
                temp[i] = lista[i].temperatura;
            }

            //prende i valori e crea scatter = grafico a dispersione (x,y) = (date, temp)+collega i punti
            var grafico1 = plt_tempo_temperatura.Plot.Add.Scatter(date, temp);
            //permette di regolare le curve, i colori ecc, (vedi sotto)

            grafico1.LegendText = "Temperatura";
            grafico1.Smooth = true;     //collega i punti con una linea curva (effetto scala logaritmica)
            grafico1.SmoothTension = 0.1; //regola la tensione della curva (0-1) = più basso più curva, più alto più lineare


            //converte i numeri double di array di date in formato leggibile
            //anche a seconda di quanto si zooma (e di quanto spazio si ha per visualizzarle)
            plt_tempo_temperatura.Plot.Axes.DateTimeTicksBottom();

            plt_tempo_temperatura.Plot.ShowLegend(); //mostra legenda (già di default)
            plt_tempo_temperatura.Refresh();    //aggiorna graficamente
        }

        //async task così mentre legge i dati non blocca l'interfaccia grafica
        private async Task<Meteo> LeggiMeteoDaAPI(int d = 7)
        {
            string url = $"https://api.open-meteo.com/v1/forecast" +
                 $"?latitude=45.41&longitude=11.87" +
                 $"&hourly=temperature_2m" +
                 $"&timezone=Europe%2FRome" +
                 $"&past_days={d}";

            //invia richiesta http get a indirizzo scritto
            HttpResponseMessage response = await client.GetAsync(url);
            //contiene sia la risposta, sia lo stato della risposta (200 ok, 404 not found, ecc)

            //controlla se la risposta è positiva (200-299), altrimenti lancia un'eccezione
            response.EnsureSuccessStatusCode();

            //legge la risposta, api da noi usata dà risposte formattate in json
            string txt = await response.Content.ReadAsStringAsync();

            //lo converte nell' oggetto meteo a partire dalla stringa
            return JsonConvert.DeserializeObject<MessaggioAPI<Meteo>>(txt).hourly;
        }

        //FIXARE ASYNC VOID-->TASK
        private async void btn_avvia_Click(object sender, EventArgs e)
        {
            try
            {
                Meteo meteo = await LeggiMeteoDaAPI(7);


                //for (int i = 0; i < 10; i++)
                lista.Clear();
                CInfo c;
                for (int i = 0; i < meteo.time.Count; i++)  //mostra tutti i dati raccolti
                {
                    if (meteo.temperature_2m[i]==null)
                        c = new(DateTime.Parse(meteo.time[i]), 0);
                    else
                        c = new(DateTime.Parse(meteo.time[i]), (float)(meteo.temperature_2m[i] ?? 0));
                    lista.Add(c);
                }
                //CreaGrafico();
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
