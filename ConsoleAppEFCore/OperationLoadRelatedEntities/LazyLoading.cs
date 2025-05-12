using ConsoleAppEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFCore.OperationLoadRelatedEntities
{
    //Install the Required Package for Lazy Loading
    //Install-Package Microsoft.EntityFrameworkCore.Proxies

    //Enable Lazy Loading in the DbContext

    //Mark Navigation Properties as virtual

    public static class LazyLoading
    {

        public static void LazyLoadingSingleLevelAction()
        {
            using (var context = new EFCoreDbContext())
            {
                try
                {
                    // Lazy Loading Example
                    Console.WriteLine("Lazy Loading Student and related data\n");
                    // Load a student (only student data is loaded initially)
                    var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
                    // Display basic student information
                    Console.WriteLine($"\nStudent Id: {student?.StudentId}, Name: {student?.FirstName} {student?.LastName}, Gender: {student?.Gender} \n");
                    // Accessing the Branch property triggers lazy loading
                    // EF Core will issue a SQL query to load the related Branch
                    if (student != null)
                    {
                        Console.WriteLine($"\nBranch Location: {student.Branch?.BranchLocation}, Email: {student.Branch?.BranchEmail}, Phone: {student.Branch?.BranchPhoneNumber}  \n");
                        // Accessing the Address property triggers lazy loading
                        // EF Core will issue a SQL query to load the related Address
                        Console.WriteLine($"\nAddress: {student.Address?.Street}, {student.Address?.City}, {student.Address?.State}, Pin: {student.Address?.PostalCode} \n");
                        // Accessing the Courses collection triggers lazy loading
                        // EF Core will issue a SQL query to load the related Courses and their related Subjects

                        //foreach (var course in student.Courses)
                        //{
                        //    Console.WriteLine($"Course Enrolled: {course.Name}");
                        //  //You can also access the Subjects of each as follows
                        //foreach (var subject in course.Subjects)
                        //{
                        //    Console.WriteLine($"    Subject: {subject.SubjectName}");
                        //}
                        //}
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during data retrieval
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            // Final Output
            Console.WriteLine("\nLazy loading of related entities completed.");
        }

        public static void EagerLoadingBranchAndLazyLoadingAddressAction()
        {
            using (var context = new EFCoreDbContext())
            {
                try
                {
                    // Eager Loading Example for Branch, Lazy Loading for Address
                    Console.WriteLine("Eager Loading Branch, Lazy Loading Address\n");
                    // Load a student and related Branch using Eager Loading
                    var student = context.Students
                                         .Include(s => s.Branch)  // Eagerly load the Branch entity
                                         .FirstOrDefault(s => s.StudentId == 2);
                    // Display basic student information
                    if (student != null)
                    {
                        Console.WriteLine($"\nStudent Id: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Gender: {student.Gender}");
                        // Check if Branch is null
                        if (student.Branch != null)
                        {
                            Console.WriteLine($"\nBranch Location: {student.Branch.BranchLocation}, Email: {student.Branch.BranchEmail}, Phone: {student.Branch.BranchPhoneNumber}\n");
                        }
                        else
                        {
                            Console.WriteLine("\nBranch data not available.\n");
                        }
                        // Accessing the Address property triggers lazy loading
                        // EF Core will issue a SQL query to load the related Address
                        if (student.Address != null)
                        {
                            Console.WriteLine($"\nAddress: {student.Address.Street}, {student.Address.City}, {student.Address.State}, Pin: {student.Address.PostalCode}");
                        }
                        else
                        {
                            Console.WriteLine("\nAddress data not available.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Student data not found.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during data retrieval
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            // Final Output
            Console.WriteLine("\nEager loading of Branch and lazy loading of Address completed.");
        }
    }

}
