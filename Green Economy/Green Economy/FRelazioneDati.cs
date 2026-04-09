using System.ComponentModel;
using System.Data;

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
            InizializzaDGV();
            CreaGraficoConRelazione();
            CompilaDGV();
        }

        private void InizializzaDGV()
        {
            dgv_dati.Columns.Add("temp", "Temperatura");
            dgv_dati.Columns.Add("inqu", "Inquinamento");
            List<string> etichette = new List<string> { "Media", "Moda", "Mediana", "Varianza" };

            dgv_dati.RowCount = etichette.Count;

            for (int i = 0; i < etichette.Count; i++)
            {
                dgv_dati.Rows[i].HeaderCell.Value = etichette[i];
            }
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

        private void CompilaDGV()
        {
            if (dati == null || dati.Count == 0)
            {
                MessageBox.Show("Nessun elemento da valutare", "Attenzione", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                return;
            }

            List<double> temp = new List<double>();
            List<double> inqu = new List<double>();
            foreach (var c in dati)
            {
                temp.Add(c.Temperatura);
                inqu.Add(c.Inquinamento);
            }

            //media
            dgv_dati.Rows[0].Cells["temp"].Value = temp.Average().ToString("F2");
            dgv_dati.Rows[0].Cells["inqu"].Value = inqu.Average().ToString("F2");

            //moda
            //dgv_dati.Rows[1].Cells["temp"].Value = CalcolaModa(temperature);
            //dgv_dati.Rows[1].Cells["inqu"].Value = CalcolaModa(inquinamento);

            //media
            dgv_dati.Rows[2].Cells["temp"].Value = Mediana(temp).ToString("F2");
            dgv_dati.Rows[2].Cells["inqu"].Value = Mediana(inqu).ToString("F2");

            //varianza
            //dgv_dati.Rows[3].Cells["temp"].Value = CalcolaVarianza(temperature).ToString("F2");
            //dgv_dati.Rows[3].Cells["inqu"].Value = CalcolaVarianza(inquinamento).ToString("F2");
        }
        private double Mediana(List<double> lista)
        {
            var nuova = lista.OrderBy(n => n).ToList();
            if(nuova.Count % 2 == 0)
            {
                return (nuova[nuova.Count / 2 - 1] + nuova[nuova.Count / 2]) / 2; 
            }
            else
            {
                return nuova[nuova.Count / 2];
            }
        }
        private void Moda()
        {

        }
        private void Varianza()
        {

        }
    }
}
