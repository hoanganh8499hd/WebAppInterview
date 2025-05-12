using ConsoleAppEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFCore.OperationLoadRelatedEntities
{
    public static class EagerLoading
    {
        //avoid the “N+1 Query Problem”
        public static void EagerLoadingSingleLevelAction()
        {
            // Initialize the database context
            using (var context = new EFCoreDbContext())
            {
                try
                {
                    // Method Syntax with Include (using lambda expression) 
                    Console.WriteLine("Method Syntax: Loading Students and their Addresses\n");
                    // Eagerly load Student entities along with their related Address entities using method syntax.
                    var studentsWithAddressesMethod = context.Students
                        .Include(s => s.Address) // Eager load Address entity using a lambda expression
                        .AsEnumerable();
                    // Method Syntax with Include (using string parameter)
                    // Eagerly load Student entities along with their related Address entities using string-based Include.
                    //var studentsWithAddressesMethodString = context.Students
                    //    .Include("Address") // Eager load Address entity using string parameter
                    //    .ToList();
                    // Eager Loading using Query Syntax with Lambda Expression
                    //var studentsWithAddressesQueryLambda = (from student in context.Students
                    //                                        .Include(s => s.Address) // Eagerly load Address entity using lambda in query syntax
                    //                                        select student).ToList();
                    // Eager Loading using Query Syntax with String
                    //var studentsWithAddressesQueryString = (from student in context.Students
                    //                                        .Include("Address") // Eagerly load Address entity using string in query syntax
                    //                                        select student).ToList();
                    // Display results
                    Console.WriteLine(); // Display a new line before displaying the data
                    foreach (var student in studentsWithAddressesMethod)
                    {
                        if (student.Address != null)
                        {
                            // Address exists, display the full address details
                            Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Address: {student.Address.Street}, {student.Address.City}, {student.Address.State}");
                        }
                        else
                        {
                            // Address is null, display "No Address"
                            Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Address: No Address");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine($"An error occurred while fetching the data. Error: {ex.Message}");
                }
            }
            // Final Output
            Console.WriteLine("Eager loading completed.");
        }

        public static void EagerLoadingMultipleLevelsAction()
        {
            // Initialize the database context
            using (var context = new EFCoreDbContext())
            {
                try
                {
                    // Method Syntax with Include and ThenInclude (using lambda expressions)
                    Console.WriteLine("Loading Students and their related entities\n");
                    // Eagerly load Student, Branch, Address, Courses, and the related Subjects using method syntax
                    var student = (context.Students
                        .Where(std => std.StudentId == 1)
                        .Include(s => s.Branch)               // Eagerly load related Branch
                        .Include(s => s.Address)              // Eagerly load related Address
                        .Include(s => s.Courses)              // Eagerly load related Courses
                        .ThenInclude(c => c.Subjects))        // Eagerly load related Subjects for each Course
                        .FirstOrDefault();                    // Execute the query and retrieve the data
                    // Display basic student information
                    Console.WriteLine($"Student: {student.FirstName} {student.LastName}");
                    Console.WriteLine($"Branch: {student.Branch?.BranchLocation}");
                    Console.WriteLine($"Address: {student.Address?.Street}, {student.Address?.City}, {student.Address?.State}");
                    // Display each course and its related subjects
                    foreach (var course in student.Courses)
                    {
                        Console.WriteLine($"Course: {course.Name}");
                        foreach (var subject in course.Subjects)
                        {
                            Console.WriteLine($"    Subject: {subject.SubjectName}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Exception handling: Catch and display any errors that occur during data retrieval
                    Console.WriteLine($"An error occurred while fetching the data. Error: {ex.Message}");
                }
            }
            // Final Output
            Console.WriteLine("\nEager loading of related entities completed.");
        }

    }
}
