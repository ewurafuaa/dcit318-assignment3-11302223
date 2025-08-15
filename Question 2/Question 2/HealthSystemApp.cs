using System;
using System.Collections.Generic;

namespace HealthcareSystem
{
    public class HealthSystemApp
    {
        private Repository<Patient> _patientRepo;
        private Repository<Prescription> _prescriptionRepo;
        private Dictionary<int, List<Prescription>> _prescriptionMap;

        public HealthSystemApp()
        {
            _patientRepo = new Repository<Patient>();
            _prescriptionRepo = new Repository<Prescription>();
            _prescriptionMap = new Dictionary<int, List<Prescription>>();
        }

        public void SeedData()
        {
            Patient patient1 = new Patient(1, "John Doe", 35, "Male");
            Patient patient2 = new Patient(2, "Jane Smith", 28, "Female");
            Patient patient3 = new Patient(3, "Mike Johnson", 42, "Male");

            _patientRepo.Add(patient1);
            _patientRepo.Add(patient2);
            _patientRepo.Add(patient3);

            Prescription prescription1 = new Prescription(1, 1, "Aspirin", DateTime.Now.AddDays(-5));
            Prescription prescription2 = new Prescription(2, 1, "Ibuprofen", DateTime.Now.AddDays(-3));
            Prescription prescription3 = new Prescription(3, 2, "Paracetamol", DateTime.Now.AddDays(-7));
            Prescription prescription4 = new Prescription(4, 2, "Vitamin D", DateTime.Now.AddDays(-1));
            Prescription prescription5 = new Prescription(5, 3, "Antibiotics", DateTime.Now.AddDays(-10));

            _prescriptionRepo.Add(prescription1);
            _prescriptionRepo.Add(prescription2);
            _prescriptionRepo.Add(prescription3);
            _prescriptionRepo.Add(prescription4);
            _prescriptionRepo.Add(prescription5);
        }

        public void BuildPrescriptionMap()
        {
            var allPrescriptions = _prescriptionRepo.GetAll();
            foreach (var prescription in allPrescriptions)
            {
                if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                {
                    _prescriptionMap[prescription.PatientId] = new List<Prescription>();
                }
                _prescriptionMap[prescription.PatientId].Add(prescription);
            }
        }

        public void PrintAllPatients()
        {
            var patients = _patientRepo.GetAll();
            Console.WriteLine("=== All Patients ===");
            foreach (var patient in patients)
            {
                Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}");
            }
            Console.WriteLine();
        }

        public void PrintPrescriptionsForPatient(int id)
        {
            if (_prescriptionMap.ContainsKey(id))
            {
                var prescriptions = _prescriptionMap[id];
                Console.WriteLine($"=== Prescriptions for Patient ID {id} ===");
                foreach (var prescription in prescriptions)
                {
                    Console.WriteLine($"ID: {prescription.Id}, Medication: {prescription.MedicationName}, Date: {prescription.DateIssued:yyyy-MM-dd}");
                }
            }
            else
            {
                Console.WriteLine($"No prescriptions found for Patient ID {id}");
            }
            Console.WriteLine();
        }

        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            if (_prescriptionMap.ContainsKey(patientId))
            {
                return _prescriptionMap[patientId];
            }
            return new List<Prescription>();
        }
    }
}
