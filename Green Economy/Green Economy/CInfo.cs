using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Economy
{
    internal class CInfo
    {
        public DateTime data { get; set; }
        public float temperatura { get; set; }

        public CInfo(DateTime d, float t)
        {
            data = d;
            temperatura = t;
        }
    }
}
