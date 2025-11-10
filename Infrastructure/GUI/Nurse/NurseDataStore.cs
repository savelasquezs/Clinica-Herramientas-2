using System;
using System.Collections.Generic;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    public static class NurseDataStore
    {
        private static readonly List<PatientVitalRecord> records = new List<PatientVitalRecord>();

        public static event Action? RecordsChanged;

        public static IReadOnlyList<PatientVitalRecord> GetAll() => records.AsReadOnly();

        public static void AddRecord(PatientVitalRecord record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));
            records.Add(record);
            RecordsChanged?.Invoke();
        }

        public static void Clear()
        {
            records.Clear();
            RecordsChanged?.Invoke();
        }
    }
}
