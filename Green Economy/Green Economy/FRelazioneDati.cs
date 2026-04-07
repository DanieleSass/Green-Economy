using System;
using System.Collections;
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
    public partial class FRelazioneDati : Form
    {
        BindingList<CInfo> dati;
        public FRelazioneDati(BindingList<CInfo> dati)
        {
            InitializeComponent();
            this.dati = dati;
        }

        private void FRelazioneDati_Load(object sender, EventArgs e)
        {
            CreaGraficoConRelazione();
        }

        private void CreaGraficoConRelazione()
        {
            if (dati == null || dati.Count == 0)
            {
                MessageBox.Show("Nessun elemento da valutare", "Attenzione", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                return;
            }

            //pulisce grafico precedente
            plt_rapporto.Plot.Clear();
            double[] temp = new double[dati.Count];
            double[] inqu = new double[dati.Count];
            for (int i = 0; i < dati.Count; i++)
            {
                temp[i] = dati[i].Temperatura;
                inqu[i] = dati[i].Inquinamento;
            }

            var graficoRapporto = plt_rapporto.Plot.Add.Scatter(temp, inqu);
            graficoRapporto.LegendText = "Rapporto Temperatura-Inquinamento";
            graficoRapporto.Smooth = true;     //collega i punti con una linea curva (effetto scala logaritmica)
            graficoRapporto.SmoothTension = 0.5; //regola la tensione della curva (0-1) = più basso più curva, più alto più lineare
            graficoRapporto.Color = ScottPlot.Colors.Green;

            plt_rapporto.Plot.ShowLegend(); //mostra legenda (già di default)
            plt_rapporto.Refresh();    //aggiorna graficamente(ridondante, per sicurezza)
        }
    }
}
