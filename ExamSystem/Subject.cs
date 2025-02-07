using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class Subject
    {
        #region Fields
        private int subjectId;
        private string? subjectName;
        public Exam? exam;
        #endregion

        #region Properties
        public int SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        }

        public string? SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }


        #endregion

        #region Constructor
        public Subject(int subjectId, string? subjectName)
        {
            if (subjectId == 0 || subjectId < 0 || subjectName?.Length < 0)
            {
                Console.WriteLine("Invalid Id Or subjectName !!");
                throw new ArgumentException("Id Must Be More Than 0!!!");
            }

            this.subjectId = subjectId;
            this.subjectName = subjectName;
            //CreateExam();
        }
        #endregion

        #region Method
        public void CreateExam()
        {

            #region Type-Of-Exam
            bool flag01;
            int typeOfExam;
            do
            {
                Console.Write("Please Enter Type of Exam (1)=> Practice , (2)=>Final: ");
                flag01 = int.TryParse(Console.ReadLine(), out typeOfExam);
                if (!flag01)
                {
                    Console.WriteLine("Invalid Type of Exam!!!!:(");
                }
            }
            while (!flag01);
            Console.WriteLine("--------------------------------------");
            #endregion

            #region Time Of Exam
            bool flag02;
            int timeOfExam;
            do
            {
                Console.Write("Enter time in minutes: ");
                flag02 = int.TryParse(Console.ReadLine(), out timeOfExam);
                if (!flag02)
                {
                    Console.WriteLine("Invalid Time!!!!:(");
                }
            }
            while (!flag02);
            Console.WriteLine("--------------------------------------");
            #endregion

            #region Number-Of-Question
            bool flag03;
            int numberOfQuestion;
            do
            {
                Console.Write("Enter Number Of Questions: ");
                flag03 = int.TryParse(Console.ReadLine(), out numberOfQuestion);
                if (!flag03)
                {
                    Console.WriteLine("Invalid Number of Question!!!!:(");
                }
            }
            while (!flag03);
            Console.WriteLine("--------------------------------------");
            #endregion

            #region Chose-Type-Of-Exam
            switch (typeOfExam)
            {
                case 1:
                    exam = new PracticeExam(timeOfExam, numberOfQuestion);
                    break;
                case 2:
                    exam = new FinalExam(timeOfExam, numberOfQuestion);
                    break;
                default:
                    throw new Exception("Invalid Type Of Exam!!!");
            }
            #endregion

            Console.Clear();

            #region Take-The-Questions

            bool flag04;
            int typeOfQuestion;

            if (typeOfExam == 1)
            {
                for (int i = 0; i < numberOfQuestion; i++)
                {
                    Console.WriteLine($"Question({i + 1}) \n");
                    McqQuestions.CreateMCQQuestion();
                    Console.Clear();
                }
            }
            else if (typeOfExam == 2)
            {

                for (int i = 0; i < numberOfQuestion; i++)
                {
                    do
                    {
                        Console.Write($"Please Enter Type of Question({i + 1}) ((1)=> For T Or F || (2)=> For MCQ) : ");
                        flag04 = int.TryParse(Console.ReadLine(), out typeOfQuestion);
                        if (!flag01)
                        {
                            Console.WriteLine("Invalid Type of Question!!!!:(");
                        }
                    }
                    while (!flag01);

                    switch (typeOfQuestion)
                    {
                        case 1:
                            TrueOrFalseQuestion.CreateTrueFalseQuestion();
                            Console.Clear();
                            break;
                        case 2:
                            McqQuestions.CreateMCQQuestion();
                            Console.Clear();
                            break;
                        default:
                            throw new Exception("Invalid Type Of Question!!!");
                    }

                }
            }

            #endregion


        }
        #endregion



    }
}
