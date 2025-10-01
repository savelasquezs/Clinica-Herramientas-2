using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class AppointmentValidator : SimpleValidator
    {
        public AppointmentValidator() { }

        public int ValidateId(int id)
        {
            ValidatePositiveInt(id, "Id");
            return id;
        }

        public DateTime ValidateDate(DateTime date)
        {
            ValidateDateNotInFuture(date, "Date");
            return date;
        }
    }
}
