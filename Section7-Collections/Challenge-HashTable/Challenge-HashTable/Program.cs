using System.Collections;

namespace Challenge_HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[5];
            students[0] = new Student(1, "Denis", 88);
            students[1] = new Student(2, "Olaf", 97);
            students[2] = new Student(6, "Ragner", 65);
            students[3] = new Student(1, "Luise", 73);
            students[4] = new Student(4, "Levi", 58);

            // CHALLENGE - HASHTABLE
            Hashtable studentTable = new Hashtable();
            foreach(Student student in students)
            {
                if (studentTable.ContainsKey(student.Id))
                {
                    Console.WriteLine("Sorry, A student with the same ID already Exists.");
                }
                else
                {
                    studentTable.Add(student.Id, student);
                }
            }
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float GPA { get; set; }

        public Student(int id, string name, float GPA)
        {
            this.Id = id;
            this.Name = name;
            this.GPA = GPA;
        }
    }
}
