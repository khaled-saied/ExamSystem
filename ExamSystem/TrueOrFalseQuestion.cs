using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class TrueOrFalseQuestion : QuestionBase
    {

        #region Constructor
        public TrueOrFalseQuestion(string? header, string? body, double mark, List<Answer> listOfAnswers, int correctAnswer)
            : base(header, body, mark, listOfAnswers, correctAnswer)
        {

        }
        #endregion

        #region Method Of CreateTrueFalseQuestion
        public static void CreateTrueFalseQuestion()
        {
            string header = "True | False Question";
            #region Take The Bode Of Question
            Console.WriteLine("-----------------------------------");
            bool flag;
            string body;
            do
            {
                Console.Write("Enter Body of Question: ");
                body = Console.ReadLine();

                flag = !string.IsNullOrWhiteSpace(body);

                if (!flag)
                {
                    Console.WriteLine("Invalid Body of Question! Please enter a valid text.");
                }
            }
            while (!flag);
            Console.WriteLine("-----------------------------------");
            #endregion

            #region Mark Of Question
            bool flag02;
            int mark;
            do
            {
                Console.Write("Enter the Mark Of The Question: ");

                flag02 = int.TryParse(Console.ReadLine(), out mark);

                if (!flag02)
                {
                    Console.WriteLine("Invalid Mark of Question!!!! Please enter a valid Mark.");
                    Console.Clear();
                }
            }
            while (!flag02);
            Console.WriteLine("-----------------------------------");
            #endregion

            #region Number of The Answer
            bool flag03;
            int numOfRightAnswer;
            do
            {
                Console.Write("Enter the Number Of The Right Anwer Of The Question=> (1-> True) (2->False): ");

                flag03 = int.TryParse(Console.ReadLine(), out numOfRightAnswer);

                if (!flag03)
                {
                    Console.WriteLine("Invalid Answer of Question!!!! Please enter a valid Answer.");
                    Console.Clear();
                }
            }
            while (!flag03 || numOfRightAnswer > 2 || numOfRightAnswer < 1);

            #endregion

            List<Answer> listOfAnswers = new List<Answer>()
            {
                new Answer(0,"True"),
                new Answer(1,"False"),
            };

            #region Storing data of question in a list
            QuestionBase question = new TrueOrFalseQuestion(header, body, mark, listOfAnswers, numOfRightAnswer);


            Exam.QuestionList.Add(question);
            #endregion
        }
        #endregion
    }
}
