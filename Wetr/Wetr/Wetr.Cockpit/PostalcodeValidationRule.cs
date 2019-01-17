using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wetr.Cockpit
{
    public class PostalcodeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {            
            if (value == null || value.ToString().Length < 1)
                return new ValidationResult(false, "Feld darf nicht leer sein!");
            else
            {                
                int intVal = 0;
                bool canConvert = false;
                canConvert = int.TryParse(value.ToString(), out intVal);
                if (canConvert && intVal < 10000 && intVal > 999)
                    return new ValidationResult(true, null);
                else
                    return new ValidationResult(false, "Postleitzahl muss aus genau 4 Ziffern bestehen!");
            }
        }
    }
}
