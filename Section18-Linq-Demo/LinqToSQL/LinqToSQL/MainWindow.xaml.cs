using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataDataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["LinqToSQL.Properties.Settings.TestDBConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataDataContext(connectionString);

            // InsertUniversities();
            // InsertStudents();
            // InsertLectures();
            // InsertStudentAssociations();
            // GetUniversityOfElton();
            // GetLectureForElton();
            // GetAllStudentsFromYale();
            // GetAllUniversitiesWithMale();
            // lecturesFromBeijingTech();
            // UpdateElton();
            DeleteElton();
        }

        public void InsertUniversities()
        {
            dataContext.ExecuteCommand("Delete from University");

            University yale = new University();
            yale.Name = "Yale";
            dataContext.Universities.InsertOnSubmit(yale);

            University beijingTech = new University() { Name = "Beijing Tech" };
            dataContext.Universities.InsertOnSubmit(beijingTech);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Universities;
        }

        public void InsertStudents()
        {
            dataContext.ExecuteCommand("Delete from Student");
            University yale = dataContext.Universities.First(un => un.Name.Equals("Yale"));
            University beijingTech = dataContext.Universities.First(un => un.Name.Equals("Beijing Tech"));

            List<Student> students = new List<Student>();
            students.Add(new Student() { Name="Elton", Gender="Male", UniversityId= yale.Id });
            students.Add(new Student() { Name = "Kate", Gender = "Female", UniversityId = yale.Id });
            students.Add(new Student() { Name = "John", Gender = "Male", UniversityId = beijingTech.Id });
            students.Add(new Student() { Name = "Kevin", Gender = "Male", UniversityId = yale.Id });
            students.Add(new Student() { Name = "Keith", Gender = "Male", UniversityId = beijingTech.Id });

            dataContext.Students.InsertAllOnSubmit(students);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Students;
        }

        public void InsertLectures()
        {
            dataContext.ExecuteCommand("Delete from Lecture");

            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Math"});
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "English" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "History" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "PE" });
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Lectures;
        }

        public void InsertStudentAssociations()
        {
            dataContext.ExecuteCommand("Delete from StudentLecture");
            Student Elton = dataContext.Students.First(student => student.Name.Equals("Elton"));
            Student Kate = dataContext.Students.First(student => student.Name.Equals("Kate"));
            Student John = dataContext.Students.First(student => student.Name.Equals("John"));
            Student Kevin = dataContext.Students.First(student => student.Name.Equals("Kevin"));
            Student Keith = dataContext.Students.First(student => student.Name.Equals("Keith"));

            Lecture Math = dataContext.Lectures.First(lecture => lecture.Name.Equals("Math"));
            Lecture English = dataContext.Lectures.First(lecture => lecture.Name.Equals("English"));
            Lecture History = dataContext.Lectures.First(lecture => lecture.Name.Equals("History"));
            Lecture PE = dataContext.Lectures.First(lecture => lecture.Name.Equals("PE"));

            StudentLecture EltonLecture = new StudentLecture() { Student = Elton, LectureId = Math.Id};
            StudentLecture KateLecture = new StudentLecture() { StudentId = Kate.Id, LectureId = English.Id };
            StudentLecture KevinLecture = new StudentLecture() { StudentId = Kevin.Id, LectureId = History.Id };
            StudentLecture KeithLecture = new StudentLecture() { Student = Keith, LectureId = PE.Id };
            dataContext.StudentLectures.InsertOnSubmit(EltonLecture);
            dataContext.StudentLectures.InsertOnSubmit(KateLecture);
            dataContext.StudentLectures.InsertOnSubmit(KevinLecture);
            dataContext.StudentLectures.InsertOnSubmit(KeithLecture);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.StudentLectures;
        }

        public void GetUniversityOfElton()
        {   
            Student Elton = dataContext.Students.First(student => student.Name.Equals("Elton"));
            University EltonUniversity = Elton.University;
            List<University> universities = new List<University>();
            universities.Add(EltonUniversity);
            MainDataGrid.ItemsSource = universities;
        }

        public void GetLectureForElton()
        {
            Student Elton = dataContext.Students.First(student => student.Name.Equals("Elton"));
            var lectures = from studentLecture in Elton.StudentLectures select studentLecture.Lecture;
            MainDataGrid.ItemsSource = lectures;
        }

        public void GetAllStudentsFromYale()
        {
            University yale = dataContext.Universities.First(university => university.Name.Equals("Yale"));
            var students = from student in dataContext.Students where student.University.Equals(yale) select student;
            MainDataGrid.ItemsSource = students;
        }

        public void GetAllUniversitiesWithMale()
        {
            var maleStudentsUniversities = from student in dataContext.Students
                                           join university in dataContext.Universities
                                           on student.UniversityId equals university.Id
                                           where student.Gender == "Male"
                                           select university;
            MainDataGrid.ItemsSource = maleStudentsUniversities;
        }

        public void lecturesFromBeijingTech()
        {
            var lectures = from student in dataContext.Students
                           join university in dataContext.Universities on student.UniversityId equals university.Id
                           join studentlecture in dataContext.StudentLectures on student.Id equals studentlecture.StudentId
                           where university.Name == "Beijing Tech"
                           select studentlecture.Lecture;
            MainDataGrid.ItemsSource = lectures;
        }

        public void UpdateElton()
        {
            Student Elton = dataContext.Students.FirstOrDefault(student => student.Name.Equals("Elton"));
            Elton.Name = "new Elton Name";
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Students;
        }

        public void DeleteElton()
        {
            Student Elton = dataContext.Students.FirstOrDefault(student => student.Name.Equals("new Elton Name"));
            dataContext.Students.DeleteOnSubmit(Elton);
            MainDataGrid.ItemsSource = dataContext.Students;
        }

    }
}
