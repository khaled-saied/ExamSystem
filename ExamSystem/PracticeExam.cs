using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class PracticeExam : Exam
    {
        #region Constructor
        public PracticeExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }
        #endregion

        #region Override
        public override void ShowExam()
        {
            if (QuestionList?.Count > 0)
            {
                #region Show Time Of Exam
                Console.WriteLine("-------------------------------------------");
                int hours = Time / 60;
                int minutes = Time % 60;
                Console.WriteLine($"Time: {hours} hours and {minutes} minutes.");
                Console.WriteLine("-------------------------------------------");
                #endregion

                #region Take Answer From Student
                int answerOfStudent = 0;
                for (int i = 0; i < QuestionList.Count; i++)
                {
                    if (QuestionList[i].Header != null && QuestionList[i].ListOfAnswers != null && QuestionList[i].Body != null)
                    {

                        Console.WriteLine($"{QuestionList[i].Header}");
                        Console.WriteLine($"{QuestionList[i].Body}");
                        for (int j = 0; j < QuestionList[i].ListOfAnswers.Count; j++)
                        {
                            Console.Write($"{j + 1}. {QuestionList[i].ListOfAnswers[j].AnswerText}      ");
                        }

                        #region To ensure that the student chose an available number from the options
                        if (QuestionList[i].Header == "True | False Question")
                        {
                            do
                            {
                                Console.Write("Enter num of Answer: ");
                            } while (!int.TryParse(Console.ReadLine(), out answerOfStudent) || answerOfStudent > 2 || answerOfStudent < 1);
                        }
                        else if (QuestionList[i].Header == "Chose One Answer Question")
                        {
                            do
                            {
                                Console.Write("Enter num of Answer: ");
                            } while (!int.TryParse(Console.ReadLine(), out answerOfStudent) || answerOfStudent > 3 || answerOfStudent < 1);
                        }
                        #endregion


                        Answer answer = new Answer(answerOfStudent, QuestionList[i].ListOfAnswers[answerOfStudent - 1].AnswerText);
                        AnswersOfStudent.Add(answer);
                        Console.WriteLine("------------------------------------");
                    }
                    else
                        Console.WriteLine("Erorr!!!!!!!!!!");
                }
                #endregion

                Console.Clear();

                #region Show only the student's correct answers 
                Console.WriteLine("Right Aswer Of the Student=>");

                RightAnswerOfStudent();

                Console.WriteLine("==============================");
                #endregion
            }
        }

        #region Show & Calc Number Of Right Aswer Of Student 
        private void RightAnswerOfStudent()
        {
            int count = 0;
            if (AnswersOfStudent == null || QuestionList == null) return;

            for (int i = 0; i < QuestionList.Count; i++)
            {
                if (i < AnswersOfStudent.Count)
                {
                    if (QuestionList[i].CorrectAnswer == AnswersOfStudent[i].AnswerId)
                    {
                        count++;
                        Console.WriteLine($"{AnswersOfStudent[i].AnswerText}");
                    }
                }
            }
            Console.WriteLine($"({count}) is True From ({QuestionList.Count}) ");
        }
        #endregion

        #endregion

    }
}
