using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
