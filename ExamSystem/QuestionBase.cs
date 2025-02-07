using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal abstract class QuestionBase
    {

        #region Props
        internal protected string? Header { get; set; }
        internal protected string? Body { get; set; }

        internal protected double Mark { get; set; }

        internal protected int CorrectAnswer { get; set; }

        internal protected List<Answer> ListOfAnswers { get; set; }

        #endregion

        #region Constructor

        public QuestionBase(string? header, string? body, double mark, List<Answer> listOfAnswers, int correctAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            ListOfAnswers = listOfAnswers;
            CorrectAnswer = correctAnswer;
        }
        #endregion

    }
}
