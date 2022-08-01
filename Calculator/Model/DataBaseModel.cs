using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class DataBaseModel
    {
        public int ID { get; set; }
        public string Infix { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public string Decimal { get; set; }
        public string Binary { get; set; }
    }
}
