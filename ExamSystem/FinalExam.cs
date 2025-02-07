using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class FinalExam : Exam
    {
        #region Constructor
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }
        #endregion


        #region Override


        #region Show Exam 
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

                #region Show The Right Aswer Of Question And Degree Of Student
                Console.WriteLine("Right Aswer Of the Questions & Grade Of Student=>");
                Console.WriteLine("--------------------------------------------------");
                for (int i = 0; i < QuestionList.Count; i++)
                {
                    Console.WriteLine($"{QuestionList[i].Header}");
                    Console.WriteLine($"{QuestionList[i].Body}");
                    Console.WriteLine($"Correct Answer of Question({i + 1}): {QuestionList[i].ListOfAnswers[QuestionList[i].CorrectAnswer - 1].AnswerText}");
                    Console.WriteLine("==============================");
                }

                Console.WriteLine($"Your Grade Is=>( {Grade()} )");
                #endregion
            }
        }
        #endregion



        #region Calc Grade Of Student
        public override string Grade()
        {
            if (AnswersOfStudent == null || QuestionList == null) return "F";

            double totalScore = 0;
            double maxScore = 0;

            for (int i = 0; i < QuestionList.Count; i++)
            {
                maxScore += QuestionList[i].Mark;

                if (i < AnswersOfStudent.Count)
                {
                    if (QuestionList[i].CorrectAnswer == AnswersOfStudent[i].AnswerId)
                    {
                        totalScore += QuestionList[i].Mark;
                    }
                }
            }

            if (maxScore == 0) return "F";

            double percentage = (totalScore / maxScore) * 100;

            if (percentage >= 97) return "A+ (Excellent Plus)";
            else if (percentage >= 90) return "A (Excellent)";
            else if (percentage >= 87) return "B+ (Very Good Plus)";
            else if (percentage >= 80) return "B (Very Good)";
            else if (percentage >= 77) return "C+ (Good Plus)";
            else if (percentage >= 70) return "C (Good)";
            else if (percentage >= 67) return "D+ (Satisfactory Plus)";
            else if (percentage >= 60) return "D (Satisfactory)";
            else return "F (Fail)";
        }

        #endregion

        #endregion
    }
}
