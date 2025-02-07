using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal abstract class Exam
    {

        #region Properties
        protected int Time { get; set; }
        protected int NumberOfQuestions { get; set; }

        public static List<QuestionBase> QuestionList { get; set; } = new List<QuestionBase>();
        protected static List<Answer> AnswersOfStudent { get; set; } = new List<Answer>();
        #endregion

        #region Constructor
        protected Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            QuestionList = new List<QuestionBase>();
            AnswersOfStudent = new List<Answer>();
        }


        #endregion

        #region Virtual-Method
        public abstract void ShowExam();

        public virtual string Grade()
        {
            return "";
        }
        #endregion

    }
}
