using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie1_Kozera.Data;
using Zadanie1_Kozera.Models;

namespace Zadanie1_Kozera.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Zadanie1_KozeraContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Zadanie1_KozeraContext>>()))
            {
                // Look for any movies.
                if (!context.Movie.Any())
                {
                    context.Movie.AddRange(
                          new Movie
                          {
                              Title = "When Harry Met Sally",
                              ReleaseDate = DateTime.Parse("1989-2-12"),
                              Genre = "Romantic Comedy",
                              Price = 7.99M
                          },

                          new Movie
                          {
                              Title = "Ghostbusters ",
                              ReleaseDate = DateTime.Parse("1984-3-13"),
                              Genre = "Comedy",
                              Price = 8.99M
                          },

                          new Movie
                          {
                              Title = "Ghostbusters 2",
                              ReleaseDate = DateTime.Parse("1986-2-23"),
                              Genre = "Comedy",
                              Price = 9.99M
                          },

                          new Movie
                          {
                              Title = "Rio Bravo",
                              ReleaseDate = DateTime.Parse("1959-4-15"),
                              Genre = "Western",
                              Price = 3.99M
                          }
                      );
                    context.SaveChanges();
                    // DB has been seeded
                }

                if (!context.Students.Any())
                {
                    var students = new Student[]
                     {
                        new Student { FirstMidName = "Carson",   LastName = "Alexander",
                            EnrollmentDate = DateTime.Parse("2010-09-01") },
                        new Student { FirstMidName = "Meredith", LastName = "Alonso",
                            EnrollmentDate = DateTime.Parse("2012-09-01") },
                        new Student { FirstMidName = "Arturo",   LastName = "Anand",
                            EnrollmentDate = DateTime.Parse("2013-09-01") },
                        new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",
                            EnrollmentDate = DateTime.Parse("2012-09-01") },
                        new Student { FirstMidName = "Yan",      LastName = "Li",
                            EnrollmentDate = DateTime.Parse("2012-09-01") },
                        new Student { FirstMidName = "Peggy",    LastName = "Justice",
                            EnrollmentDate = DateTime.Parse("2011-09-01") },
                        new Student { FirstMidName = "Laura",    LastName = "Norman",
                            EnrollmentDate = DateTime.Parse("2013-09-01") },
                        new Student { FirstMidName = "Nino",     LastName = "Olivetto",
                            EnrollmentDate = DateTime.Parse("2005-09-01") }
                     };

                    context.Students.AddRange(students);
                    context.SaveChanges();

                    var instructors = new Instructor[]
                    {
                        new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie",
                            HireDate = DateTime.Parse("1995-03-11") },
                        new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",
                            HireDate = DateTime.Parse("2002-07-06") },
                        new Instructor { FirstMidName = "Roger",   LastName = "Harui",
                            HireDate = DateTime.Parse("1998-07-01") },
                        new Instructor { FirstMidName = "Candace", LastName = "Kapoor",
                            HireDate = DateTime.Parse("2001-01-15") },
                        new Instructor { FirstMidName = "Roger",   LastName = "Zheng",
                            HireDate = DateTime.Parse("2004-02-12") }
                    };

                    context.Instructors.AddRange(instructors);
                    context.SaveChanges();

                    var departments = new Department[]
                    {
                        new Department { Name = "English",     Budget = 350000,
                            StartDate = DateTime.Parse("2007-09-01"),
                            InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                        new Department { Name = "Mathematics", Budget = 100000,
                            StartDate = DateTime.Parse("2007-09-01"),
                            InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                        new Department { Name = "Engineering", Budget = 350000,
                            StartDate = DateTime.Parse("2007-09-01"),
                            InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                        new Department { Name = "Economics",   Budget = 100000,
                            StartDate = DateTime.Parse("2007-09-01"),
                            InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
                    };

                    context.Departments.AddRange(departments);
                    context.SaveChanges();

                    var courses = new Course[]
                    {
                        new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                            DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                        },
                        new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                            DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                        },
                        new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                            DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                        },
                        new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
                            DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                        },
                        new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                            DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                        },
                        new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                            DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                        },
                        new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
                            DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                        },
                    };

                    foreach (Course c in courses)
                    {
                        context.Courses.Add(c);
                    }
                    context.SaveChanges();

                    var officeAssignments = new OfficeAssignment[]
                    {
                        new OfficeAssignment {
                            InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,
                            Location = "Smith 17" },
                        new OfficeAssignment {
                            InstructorID = instructors.Single( i => i.LastName == "Harui").ID,
                            Location = "Gowan 27" },
                        new OfficeAssignment {
                            InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,
                            Location = "Thompson 304" },
                    };

                    context.OfficeAssignments.AddRange(officeAssignments);
                    context.SaveChanges();

                    var courseInstructors = new CourseAssignment[]
                    {
                        new CourseAssignment {
                            CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                            InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
                            },
                        new CourseAssignment {
                            CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                            InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                            },
                        new CourseAssignment {
                            CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                            InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                            },
                        new CourseAssignment {
                            CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                            InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                            },
                        new CourseAssignment {
                            CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                            InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
                            },
                        new CourseAssignment {
                            CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                            InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                            },
                        new CourseAssignment {
                            CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                            InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                            },
                        new CourseAssignment {
                            CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
                            InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                            },
                    };

                    context.CourseAssignments.AddRange(courseInstructors);
                    context.SaveChanges();

                    var enrollments = new Enrollment[]
                    {
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Alexander").ID,
                            CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                            Grade = Grade.A
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Alexander").ID,
                            CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                            Grade = Grade.C
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Alexander").ID,
                            CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                            Grade = Grade.B
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Alonso").ID,
                            CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                            Grade = Grade.B
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Alonso").ID,
                            CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                            Grade = Grade.B
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Alonso").ID,
                            CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                            Grade = Grade.B
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Anand").ID,
                            CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Anand").ID,
                            CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                            Grade = Grade.B
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
                            CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                            Grade = Grade.B
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Li").ID,
                            CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                            Grade = Grade.B
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Justice").ID,
                            CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                            Grade = Grade.B
                        }
                    };

                    foreach (Enrollment e in enrollments)
                    {
                        var enrollmentInDataBase = context.Enrollments.Where(
                            s =>
                                    s.Student.ID == e.StudentID &&
                                    s.Course.CourseID == e.CourseID).SingleOrDefault();
                        if (enrollmentInDataBase == null)
                        {
                            context.Enrollments.Add(e);
                        }
                    }
                    context.SaveChanges();
                }

                if (!context.Teams.Any())
                {
                    var teams = new Team[]
                    {
                        new Team { Name = "ADMINISTRACJA", Address = "PIOTROWO 20" },
                        new Team { Name = "SYSTEMY ROZPROSZONE", Address = "PIOTROWO 3A" },
                        new Team { Name = "SYSTEMY EKSPERCKIE", Address = "STRZELECKA 14" },
                        new Team { Name = "ALGORYTMY", Address = "WIENIAWSKIEGO 16" },
                        new Team { Name = "BADANIA OPERACYJNE", Address = "MIELZYNSKIEGO 30" }
                    };
                    context.Teams.AddRange(teams);
                    context.SaveChanges();

                    var jobs = new Job[]
                    {
                        new Job { Name = "PROFESOR", WorkFrom = 3000, WorkTo = 4000 },
                        new Job { Name = "SEKRETARKA", WorkFrom = 1470, WorkTo = 1650 },
                        new Job { Name = "DOKTORANT", WorkFrom = 800, WorkTo = 1000 },
                        new Job { Name = "ASYSTENT", WorkFrom = 1500, WorkTo = 2100 },
                        new Job { Name = "ADIUNKT", WorkFrom = 2510, WorkTo = 3000 },
                        new Job { Name = "DYREKTOR", WorkFrom = 4280, WorkTo = 5100 }
                    };
                    context.Jobs.AddRange(jobs);
                    context.SaveChanges();

                    var jobHierarchies = new JobHierarchy[]
                    {
                        new JobHierarchy { BossId = context.Jobs.Single(x => x.Name == "PROFESOR").Id, SubordinateId = context.Jobs.Single(x => x.Name == "DOKTORANT").Id },
                        new JobHierarchy { BossId = context.Jobs.Single(x => x.Name == "PROFESOR").Id, SubordinateId = context.Jobs.Single(x => x.Name == "ADIUNKT").Id },
                        new JobHierarchy { BossId = context.Jobs.Single(x => x.Name == "DYREKTOR").Id, SubordinateId = context.Jobs.Single(x => x.Name == "PROFESOR").Id },
                        new JobHierarchy { BossId = context.Jobs.Single(x => x.Name == "DYREKTOR").Id, SubordinateId = context.Jobs.Single(x => x.Name == "SEKRETARKA").Id },
                        new JobHierarchy { BossId = context.Jobs.Single(x => x.Name == "DYREKTOR").Id, SubordinateId = context.Jobs.Single(x => x.Name == "DOKTORANT").Id },
                        new JobHierarchy { BossId = context.Jobs.Single(x => x.Name == "DYREKTOR").Id, SubordinateId = context.Jobs.Single(x => x.Name == "ASYSTENT").Id },
                        new JobHierarchy { BossId = context.Jobs.Single(x => x.Name == "DYREKTOR").Id, SubordinateId = context.Jobs.Single(x => x.Name == "ADIUNKT").Id }

                    };
                    context.jobHierarchies.AddRange(jobHierarchies);
                    context.SaveChanges();


                    var employees = new Employee[]
                    {
                        new Employee
                        {
                            FirstMidName = "Jan",
                            LastName = "Marecki",
                            TeamId = context.Teams.Single(x => x.Name == "ADMINISTRACJA").Id,
                            JobId = context.Jobs.Single(x => x.Name == "PROFESOR").Id,
                            Salary = 3100,
                            AddicionalSalary = 100,
                            HireDate = new DateTime(1980, 11, 21, 12, 0, 6)
                        },
                        new Employee
                        {
                            FirstMidName = "Jan",
                            LastName = "Winnicki",
                            TeamId = context.Teams.Single(x => x.Name == "SYSTEMY ROZPROSZONE").Id,
                            JobId = context.Jobs.Single(x => x.Name == "ASYSTENT").Id,
                            Salary = 800,
                            AddicionalSalary = 50,
                            HireDate = new DateTime(1990, 11, 1, 12, 0, 5)
                        },
                        new Employee
                        {
                            FirstMidName = "Karol",
                            LastName = "Marecki",
                            TeamId = context.Teams.Single(x => x.Name == "SYSTEMY EKSPERCKIE").Id,
                            JobId = context.Jobs.Single(x => x.Name == "ASYSTENT").Id,
                            Salary = 850,
                            AddicionalSalary = 50,
                            HireDate = new DateTime(1999, 8, 11, 6, 0, 5)
                        },
                        new Employee
                        {
                            FirstMidName = "Karol",
                            LastName = "Janicki",
                            TeamId = context.Teams.Single(x => x.Name == "ALGORYTMY").Id,
                            JobId = context.Jobs.Single(x => x.Name == "DYREKTOR").Id,
                            Salary = 4300,
                            AddicionalSalary = 0,
                            HireDate = new DateTime(2000, 11, 11, 9, 6, 5)
                        },
                        new Employee
                        {
                            FirstMidName = "Joanna",
                            LastName = "Bibicka",
                            TeamId = context.Teams.Single(x => x.Name == "BADANIA OPERACYJNE").Id,
                            JobId = context.Jobs.Single(x => x.Name == "SEKRETARKA").Id,
                            Salary = 1500,
                            AddicionalSalary = 0,
                            HireDate = new DateTime(2005, 4, 3, 9, 6, 5)
                        },
                        new Employee
                        {
                            FirstMidName = "Piotr",
                            LastName = "Nowak",
                            TeamId = context.Teams.Single(x => x.Name == "SYSTEMY EKSPERCKIE").Id,
                            JobId = context.Jobs.Single(x => x.Name == "DOKTORANT").Id,
                            Salary = 800,
                            AddicionalSalary = 0,
                            HireDate = new DateTime(2006, 5, 5, 10, 12, 3)
                        },
                        new Employee
                        {
                            FirstMidName = "Piotr",
                            LastName = "Nowakowski",
                            TeamId = context.Teams.Single(x => x.Name == "ALGORYTMY").Id,
                            JobId = context.Jobs.Single(x => x.Name == "ADIUNKT").Id,
                            Salary = 2600,
                            AddicionalSalary = 100,
                            HireDate = new DateTime(2006, 8, 3, 11, 6, 3)
                        },
                        new Employee
                        {
                            FirstMidName = "Karol",
                            LastName = "Janicki",
                            TeamId = context.Teams.Single(x => x.Name == "BADANIA OPERACYJNE").Id,
                            JobId = context.Jobs.Single(x => x.Name == "ADIUNKT").Id,
                            Salary = 2600,
                            AddicionalSalary = 0,
                            HireDate = new DateTime(2007, 1, 3, 11, 6, 3)
                        },
                        new Employee
                        {
                            FirstMidName = "Krzysztof",
                            LastName = "Kowalski",
                            TeamId = context.Teams.Single(x => x.Name == "ADMINISTRACJA").Id,
                            JobId = context.Jobs.Single(x => x.Name == "SEKRETARKA").Id,
                            Salary = 2600,
                            AddicionalSalary = 0,
                            HireDate = new DateTime(2007, 4, 3, 11, 6, 3)
                        }
                    };

                    context.Employees.AddRange(employees);
                    context.SaveChanges();
                }
            }
        }
    }
}
