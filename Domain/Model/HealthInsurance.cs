using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{

    public class HealthInsurance
    {
        private string _companyName;
        private string _policyNumber;
        private bool _isActive;
        private DateTime _expirationDate;

        public string CompanyName { get => _companyName; set => _companyName = value; }
        public string PolicyNumber { get => _policyNumber; set => _policyNumber = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public DateTime ExpirationDate { get => _expirationDate; set => _expirationDate = value; }
    }

}
