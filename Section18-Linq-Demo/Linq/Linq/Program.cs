using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // EXAPMLE 1
/*            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            OddNumbers(numbers);
            Console.ReadKey();*/

            // EXAMPLE 2
            UniversityManager um = new UniversityManager();
            /*            um.MaleStudents();
                        um.FemaleStudents();
                        um.SortStudentsByAge();*/
            // um.AllStudentsFromBeijingTech();
            /*Console.WriteLine("Enter the university ID");
            string input = Console.ReadLine();
            try
            {
                int inputAsInt = Convert.ToInt32(input);
                um.getStudentsFromUniversityWithId(inputAsInt);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/
            um.StudentAndUniversityNameCollection();
            Console.ReadKey();
        }

        static void OddNumbers(int[] numbers)
        {
            Console.WriteLine("Odd Numbers: ");

            IEnumerable<int> oddNumbers = from number in numbers where number % 2 != 0 select number;
            Console.WriteLine(oddNumbers);

            foreach (int number in oddNumbers)
            {
                Console.WriteLine(number);
            }
        }

        class UniversityManager
        {
            public List<University> universities;
            public List<Student> students;

            public UniversityManager()
            {
                universities = new List<University>();
                students = new List<Student>();

                universities.Add(new University(1, "Yale"));
                universities.Add(new University(2, "Beijing Tech"));

                students.Add(new Student(1, "Carla", "Female", 17, 1));
                students.Add(new Student(2, "Toni", "Male", 22, 1));
                students.Add(new Student(3, "Leyla", "Female", 19, 2));
                students.Add(new Student(4, "James", "Male", 25, 2));
                students.Add(new Student(5, "Linda", "Female", 22, 2));
            }

            public void MaleStudents()
            {
                IEnumerable<Student> maleStudents = from student in students where student.Gender == "Male" select student;
                Console.WriteLine("Male Students:");
                foreach (var maleStudent in maleStudents)
                {
                    Console.WriteLine(maleStudent.Name);
                }
            }

            public void FemaleStudents()
            {
                IEnumerable<Student> femaleStudents = from student in students where student.Gender != "Male" select student;
                Console.WriteLine("Female Students:");
                foreach (var femaleStudent in femaleStudents)
                {
                    Console.WriteLine(femaleStudent.Name);
                }
            }

            public void SortStudentsByAge()
            {
                var sortedStudents = from student in students orderby student.Age select student;
                Console.WriteLine("Students sorted by Age:");
                foreach(var student in sortedStudents)
                {
                    student.Print();
                }
            }

            public void AllStudentsFromBeijingTech()
            {
                IEnumerable<Student> bjStudents = from student in students
                                                  join university in universities on student.UnversityId equals university.Id
                                                  where university.Name == "Beijing Tech"
                                                  select student;
                Console.WriteLine("Students from Beijing Tech:");
                foreach (Student student in bjStudents)
                {
                    student.Print();
                }
            }

            public void getStudentsFromUniversityWithId(int id)
            {
                IEnumerable<Student> selectedStudents = from student in students 
                                                join university in universities on student.UnversityId equals university.Id
                                                where university.Id == id
                                                select student;
                Console.WriteLine("Students from selected University with Id {0}", id);
                foreach (Student student in selectedStudents)
                {
                    student.Print();
                }
            }

            public void StudentAndUniversityNameCollection()
            {
                var newCollection = from student in students
                                    join university in universities on student.UnversityId equals university.Id
                                    orderby student.Name
                                    select new { StudentName = student.Name, UniversityName = university.Name};
                Console.WriteLine("New Collection:");
                foreach (var col in newCollection)
                {
                    Console.WriteLine("Student {0} from University {1}", col.StudentName, col.UniversityName);
                }
            }
        }
        
        class University
        {
            public University(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public void Print()
            {
                Console.WriteLine("University {0} with id {1}", Name, Id);
            }
        }

        class Student
        {
            public Student (int id, string name, string gender, int age, int unversityId)
            {
                Id = id;
                Name = name;
                Gender = gender;
                Age = age;
                UnversityId = unversityId;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender {  get; set; }
            public int Age { get; set; }

            // FOREIGN KEY
            public int UnversityId {  get; set; }

            public void Print()
            {
                Console.WriteLine("Student {0} with id {1}, Gender {2}, Age {3} from University with the Id {4}", Name, Id, Gender, Age, UnversityId);
            }
        }
    }
}
