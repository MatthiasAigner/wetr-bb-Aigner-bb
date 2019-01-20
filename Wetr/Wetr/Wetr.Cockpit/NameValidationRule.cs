using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wetr.Cockpit
{
    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString().Length < 1)
                return new ValidationResult(false, "Feld darf nicht leer sein");
            else
            {
                if (value.ToString().Length >= 3)
                    return new ValidationResult(true, null);
                else
                    return new ValidationResult(false, "Mindestens 3 Zeichen erforderlich");
            }
        }
    }
}
