using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class McqQuestions : QuestionBase
    {

        #region Constructor
        public McqQuestions(string? header, string? body, double mark, List<Answer> listOfAnswers, int correctAnswer)
            : base(header, body, mark, listOfAnswers, correctAnswer)
        {
        }
        #endregion

        #region Method Of Create MCQ Question
        public static void CreateMCQQuestion()
        {
            string header = "Chose One Answer Question";
            Console.WriteLine("-----------------------------------");

            List<Answer> answerList = new List<Answer>();

            #region Take-Body Of Question
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
                    Console.Clear();
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

            #region Take 3 Choice Answer
            for (int i = 0; i < 3; i++)
            {
                bool flag03;
                string choiceAnswer;
                do
                {
                    Console.Write($"Please Enter The Choice Number ({i + 1}): ");
                    choiceAnswer = Console.ReadLine();

                    flag03 = !string.IsNullOrWhiteSpace(choiceAnswer);

                    if (!flag03)
                    {
                        Console.WriteLine("Invalid Choice Answer of Question!!!!");
                        Console.Clear();
                    }
                }
                while (!flag03);

                Answer answer = new Answer(i, choiceAnswer);
                answerList.Add(answer);
            }
            Console.WriteLine("-----------------------------------");
            #endregion

            #region Number of The Answer
            bool flag04;
            int numOfRightAnswer;
            do
            {
                Console.Write("Enter the Number Of The Right Anwer Of The Question:  ");

                flag04 = int.TryParse(Console.ReadLine(), out numOfRightAnswer);

                if (!flag04)
                {
                    Console.WriteLine("Invalid Answer of Question!!!! Please enter a valid Answer.");
                    Console.Clear();
                }
            }
            while (!flag04 || numOfRightAnswer > 3 || numOfRightAnswer < 1);

            #endregion

            #region #region Storing data of question in a list
            QuestionBase question = new McqQuestions(header, body, mark, answerList, numOfRightAnswer);

            Exam.QuestionList.Add(question);
            #endregion
        }
        #endregion

    }
}
