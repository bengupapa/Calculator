using Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class CalculatorModel
    {
        public Screen Screen { get; set; }
        public IEnumerable<ButtonsGroup> ButtonGroups { get; set; }
    }
}
