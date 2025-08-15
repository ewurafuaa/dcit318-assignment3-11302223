using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolGradingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== School Grading System ===");
                Console.WriteLine();

                string currentDirectory = Directory.GetCurrentDirectory();
                Console.WriteLine($"Current working directory: {currentDirectory}");
                
                string inputFilePath = "students.txt";
                string outputFilePath = "grades_report.txt";
                
                Console.WriteLine($"Looking for input file: {Path.GetFullPath(inputFilePath)}");
                
                if (!File.Exists(inputFilePath))
                {
                    Console.WriteLine($"Input file '{inputFilePath}' not found. Creating sample data...");
                    CreateSampleData(inputFilePath);
                    Console.WriteLine($"Sample data should be created at: {Path.GetFullPath(inputFilePath)}");
                }
                else
                {
                    Console.WriteLine($"Found existing input file: {inputFilePath}");
                }
                
                StudentResultProcessor processor = new StudentResultProcessor();
                
                Console.WriteLine("Reading student data from file...");
                List<Student> students = processor.ReadStudentsFromFile(inputFilePath);
                
                if (students.Count > 0)
                {
                    Console.WriteLine($"Successfully processed {students.Count} students");
                    Console.WriteLine("Writing grades report...");
                    processor.WriteReportToFile(students, outputFilePath);
                    Console.WriteLine($"Report written to '{outputFilePath}'");
                    
                    Console.WriteLine();
                    Console.WriteLine("=== Sample Student Grades ===");
                    for (int i = 0; i < Math.Min(3, students.Count); i++)
                    {
                        var student = students[i];
                        Console.WriteLine($"{student.FullName}: Score {student.Score} = Grade {student.GetGrade()}");
                    }
                }
                else
                {
                    Console.WriteLine("No valid student records found in the input file.");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch (InvalidScoreFormatException ex)
            {
                Console.WriteLine($"Invalid score format: {ex.Message}");
            }
            catch (MissingFieldException ex)
            {
                Console.WriteLine($"Missing field: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void CreateSampleData(string filePath)
        {
            try
            {
                Console.WriteLine($"Attempting to create file at: {Path.GetFullPath(filePath)}");
                
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("101,Alice Smith,84");
                    writer.WriteLine("102,John Doe,72");
                    writer.WriteLine("103,Jane Wilson,95");
                    writer.WriteLine("104,Mike Johnson,58");
                    writer.WriteLine("105,Sarah Brown,67");
                }
                
                if (File.Exists(filePath))
                {
                    Console.WriteLine("Sample data file created successfully.");
                    Console.WriteLine($"File size: {new FileInfo(filePath).Length} bytes");
                }
                else
                {
                    Console.WriteLine("ERROR: File was not created!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating sample data: {ex.Message}");
                Console.WriteLine($"Full exception: {ex}");
            }
        }
    }
}
