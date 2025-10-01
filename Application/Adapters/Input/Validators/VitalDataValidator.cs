using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class VitalDataValidator : SimpleValidator
    {
        public VitalDataValidator() { }

        public string ValidateBloodPressure(string bloodPressure)
        {
            StringNotNullOrEmpty(bloodPressure, "BloodPressure");
            var parts = bloodPressure.Split('/');
            if (parts.Length != 2 || !int.TryParse(parts[0], out var sys) || !int.TryParse(parts[1], out var dia) || sys < 50 || sys > 250 || dia < 30 || dia > 150)
            {
                throw new ArgumentException("BloodPressure debe tener formato SYS/DIA con valores válidos.");
            }
            return bloodPressure;
        }

        public double ValidateTemperature(double temperature)
        {
            if (temperature < 30 || temperature > 45)
            {
                throw new ArgumentException("Temperature debe estar entre 30 y 45 °C.");
            }
            return temperature;
        }

        public int ValidatePulse(int pulse)
        {
            if (pulse < 30 || pulse > 220)
            {
                throw new ArgumentException("Pulse debe estar entre 30 y 220.");
            }
            return pulse;
        }

        public int ValidateOxygenLevel(int oxygenLevel)
        {
            if (oxygenLevel < 0 || oxygenLevel > 100)
            {
                throw new ArgumentException("OxygenLevel debe estar entre 0 y 100.");
            }
            return oxygenLevel;
        }
    }
}
