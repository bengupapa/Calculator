using Calculator.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Managers
{ 
    public abstract class BaseManager
    {
        //Encapsulation and absraction
        protected static ExpressionValidator _expressionValidator = new ExpressionValidator();
    }
}
