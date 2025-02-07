using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class Answer
    {
        #region Props
        public string? AnswerText { get; set; }
        public int AnswerId { get; set; }
        #endregion

        #region Constructor
        public Answer(int answerId, string answerText)
        {
            AnswerText = answerText;
            AnswerId = answerId;
        }
        #endregion

    }
}
