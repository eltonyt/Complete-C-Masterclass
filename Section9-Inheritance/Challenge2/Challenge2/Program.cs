namespace Challenge2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee
            Employee ee = new Employee("Liu", "David", 40);
            ee.Work();
            ee.Pause();

            //Bose
            Bose bose = new Bose("Li", "Elton", 40);
            bose.CompanyCar = "4 cars";
            bose.Work();
            bose.Pause();
            bose.Lead();

            //Trainee
            Trainee trainee = new Trainee("Li", "Su", 40);
            trainee.WorkingHours = 20;
            trainee.SchoolHours = 20;
            trainee.Work();
        }
    }
}
