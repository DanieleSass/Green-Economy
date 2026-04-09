using System.ComponentModel;

namespace Green_Economy
{
    public class CInfo
    {
        [DisplayName("Data e Ora")] //nome mostrato nel dgv, altrimenti
                                    //verrebbe mostrato il nome della proprietà
        public DateTime Data { get; set; }

        [DisplayName("Temperatura (C°)")]
        public float Temperatura { get; set; }

        [DisplayName("Inquinamento (PM 2.5 (µg/m³)")]
        //PM = particolato=polveri sottili
        //2.5 indica il pm con diametro < a 2,5 micrometri
        public float Inquinamento { get; set; }

        public CInfo()
        {
            //necessario per database
        }
        public CInfo(DateTime d, float t, float i)
        {
            Data = d;
            Temperatura = t;
            Inquinamento = i;
        }
    }
}
