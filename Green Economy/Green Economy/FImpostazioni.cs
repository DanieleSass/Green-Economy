using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Green_Economy
{
    public partial class FImpostazioni : Form
    {
        public delegate Task AsyncImpostazioniHandler(object sender, ImpostazioniEventArgs e);
        public event AsyncImpostazioniHandler SalvaImpostazioni;

        static readonly HttpClient client = new(); //comunica col server, riceve i dati(socket)
        //classe per fare richiesta http, statico così esiste una sola istanza condivisa
        //non serve crearne una nuova ogni volta che si fa una richiesta, sennò socket intasati

        public FImpostazioni()
        {
            InitializeComponent();
            //popola checkbox list
            foreach (DatoDaAnalizzare valore in Enum.GetValues(typeof(DatoDaAnalizzare)))
            {
                chc_dati.Items.Add(valore);
            }
            LeggiCittà();
        }

        private void FImpostazioni_Load(object sender, EventArgs e)
        {

        }

        private void LeggiCittà() //legge da file json
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "../../../File/comuni.json");
                string txt = File.ReadAllText(path);
                var lista = JsonConvert.DeserializeObject<List<Città>>(txt);
                foreach (Città c in lista)
                {
                    cmb_citta.Items.Add(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }          
        }

        private void btn_annulla_Click(object sender, EventArgs e)
        {
            //this.Close();
            Hide();
        }

        private async void btn_salva_Click(object sender, EventArgs e)
        {
            List<DatoDaAnalizzare> flagRichiesti = new();

            //scorre tutti gli elementi selezionati
            foreach (DatoDaAnalizzare item in chc_dati.CheckedItems)
            {
                flagRichiesti.Add(item);
            }

            int giorni = (int)nmr_giorni.Value;
            
            Città citta = (Città)cmb_citta.SelectedItem;
            if(citta == null)
            {
                MessageBox.Show("Seleziona una città");
                return;
            }
            if (flagRichiesti.Count() == 0)
            {
                MessageBox.Show("Seleziona almeno un dato da analizzare");
                return;
            }
            if(giorni <= 0 || giorni >100)
            {
                MessageBox.Show("Inserisci un numero di giorni da analizzare valido");
                return;
            }
            Impostazioni impo = new(giorni,citta,flagRichiesti);

            //così form non scompare subito e aspetta che evento finisca nell' altro form, quindi che carichi graficamente
            await SalvaImpostazioni?.Invoke(this, new ImpostazioniEventArgs(impo));
            //this.Close();
            Hide();
        }
    }

    public class Città
    {
        [JsonProperty("denominazione_ita")] //quando file viene deserializzato controlla questo nome e non quello della proprietà
        public string Nome { get; set; }

        [JsonProperty("sigla_provincia")]
        public string Provincia { get; set; }

        [JsonProperty("lat")]
        public double Latitudine { get; set; }

        [JsonProperty("lon")]
        public double Longitudine { get; set; }
        public override string ToString()   //lo rende "leggibile" nella combobox
        {
            return $"{Nome} ({Provincia})";
        }
    }


    public class Impostazioni
    {
        public int giorni { get; set; }
        //serve latitutidine e longitudine della città penso, guardare documentazione API
        //meglio se basta solo la citta
        public Città citta { get; set; }
        public List<DatoDaAnalizzare> flags { get; set; }
        public Impostazioni(int giorni,Città citta ,List<DatoDaAnalizzare> flags)
        {
            this.giorni = giorni;
            this.flags = flags;
            this.citta = citta;
        }
    }

    public class ImpostazioniEventArgs : EventArgs
    {

        public Impostazioni impostazioni{ get; set; }
        public ImpostazioniEventArgs(Impostazioni impostazioni)
        {
            this.impostazioni = impostazioni;
        }
    }
}
