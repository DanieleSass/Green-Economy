using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Green_Economy
{
    public partial class FImpostazioni : Form
    {
        public event EventHandler<ImpostazioniEventArgs> SalvaImpostazioni;
        
        public FImpostazioni()
        {
            InitializeComponent();
        }

        private void FImpostazioni_Load(object sender, EventArgs e)
        {
            foreach (DatoDaAnalizzare valore in Enum.GetValues(typeof(DatoDaAnalizzare)))
            {
                chc_dati.Items.Add(valore);
            }
        }

        private void btn_annulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_salva_Click(object sender, EventArgs e)
        {

            //FARE CONTROLLO VALIDITà INPUT

            List<DatoDaAnalizzare> flagRichiesti = new();

            //scorre tutti gli elementi selezionati
            foreach (DatoDaAnalizzare item in chc_dati.CheckedItems)
            {
                flagRichiesti.Add(item);
            }

            int giorni = (int)nmr_giorni.Value;

                //PASSARE COME PARAMETRO ANCHE LA CITTà

            Impostazioni impo = new(giorni, flagRichiesti);
            SalvaImpostazioni?.Invoke(this, new ImpostazioniEventArgs(impo));
            this.Close();
        }
    }

    public class Impostazioni
    {
        public int giorni { get; set; }
        //serve latitutidine e longitudine della città penso, guardare documentazione API
        //meglio se basta solo la citta

        public List<DatoDaAnalizzare> flags { get; set; }
        public Impostazioni(int giorni, List<DatoDaAnalizzare> flags)
        {
            this.giorni = giorni;
            this.flags = flags;
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
