using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wetr.Cockpit
{
    public class DegreeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString().Length < 1)
                return new ValidationResult(false, "Feld darf nicht leer sein");
            else
            {
                double doubleVal = 0.0;
                bool canConvert = false;
                canConvert = double.TryParse(value.ToString(), out doubleVal);
                if (canConvert && doubleVal < 100.0 && doubleVal >= 0.0)
                    return new ValidationResult(true, null);
                else
                    return new ValidationResult(false, "Bitte geben Sie eine Dezimalzahl ein im Format XX.YYYYYY");
            }
        }
    }
}
