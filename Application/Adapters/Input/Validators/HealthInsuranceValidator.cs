using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class HealthInsuranceValidator : SimpleValidator
    {
        public HealthInsuranceValidator() { }

        public string ValidateCompanyName(string companyName)
        {
            ValidateStringLength(companyName, "CompanyName", max: 100, min: 1);
            return companyName.Trim();
        }

        public string ValidatePolicyNumber(string policyNumber)
        {
            ValidateStringLength(policyNumber, "PolicyNumber", max: 50, min: 1);
            return policyNumber.Trim();
        }

        public DateTime ValidateExpirationDate(DateTime expirationDate)
        {
            ValidateDateNotInFuture(expirationDate, "ExpirationDate");
            return expirationDate;
        }
    }
}
