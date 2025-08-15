using System;

namespace HealthcareSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Healthcare System ===");
                Console.WriteLine();

                HealthSystemApp healthSystemApp = new HealthSystemApp();
                healthSystemApp.SeedData();
                healthSystemApp.BuildPrescriptionMap();
                healthSystemApp.PrintAllPatients();
                healthSystemApp.PrintPrescriptionsForPatient(1);
                healthSystemApp.PrintPrescriptionsForPatient(2);
                healthSystemApp.PrintPrescriptionsForPatient(3);

                Console.WriteLine("System demonstration completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
