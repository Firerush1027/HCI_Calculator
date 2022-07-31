using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public enum Symbol
    {
        Clear,
        Equal,
        Others
    }
    public class ButtonModel
    {
        public int GridColumn { get; set; }
        public int GridRow { get; set; }
        public int GridColumnSpan { get; set; }
        public string Content { get; set; }
        public Symbol Symbol { get; set; }= Symbol.Others;
    }
}
