using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolGradingSystem
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            List<Student> students = new List<Student>();
            
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                int lineNumber = 0;
                
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    try
                    {
                        string[] fields = line.Split(',');
                        
                        if (fields.Length != 3)
                        {
                            throw new MissingFieldException($"Line {lineNumber}: Expected 3 fields, found {fields.Length}");
                        }
                        
                        if (!int.TryParse(fields[0].Trim(), out int id))
                        {
                            throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid ID format '{fields[0]}'");
                        }
                        
                        string fullName = fields[1].Trim();
                        if (string.IsNullOrEmpty(fullName))
                        {
                            throw new MissingFieldException($"Line {lineNumber}: Full name is missing");
                        }
                        
                        if (!int.TryParse(fields[2].Trim(), out int score))
                        {
                            throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid score format '{fields[2]}'");
                        }
                        
                        Student student = new Student(id, fullName, score);
                        students.Add(student);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing line {lineNumber}: {ex.Message}");
                    }
                }
            }
            
            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var student in students)
                {
                    string grade = student.GetGrade();
                    string summary = $"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {grade}";
                    writer.WriteLine(summary);
                }
            }
        }
    }
}
