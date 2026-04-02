using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Economy
{
    internal class CInfo
    {
        public DateTime Data { get; set; }
        public float Temperatura { get; set; }
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
