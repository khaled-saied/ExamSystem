using System.Diagnostics;

namespace ExamSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");



            Subject subject = new Subject(10, "C#");
            subject.CreateExam();
            Console.Clear();
            Console.Write("Do You Want To Start The Exam (y | n): ");

            if (char.Parse(Console.ReadLine() ?? "") == 'y')
            {
                Stopwatch sw = new Stopwatch();
                if (subject?.exam != null)
                {
                    sw.Start();
                    subject.exam.ShowExam();
                }
                else
                {
                    throw new Exception("Error!!!!!");
                }
                //subject.exam.ShowExam();
                sw.Stop();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }

        }
    }
}
