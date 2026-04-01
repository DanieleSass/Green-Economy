using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Green_Economy
{
    public partial class Form1 : Form
    {
        List<CInfo> lista;
        string path;
        public Form1()
        {
            InitializeComponent();
            lista = new();
            path = Path.Combine(Directory.GetCurrentDirectory(), "../../File/dati.json");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                List<CInfo> lista = JsonConvert.DeserializeObject<List<CInfo>>(txt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }

        }
    }
}
