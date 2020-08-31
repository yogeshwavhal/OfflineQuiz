
using Laxsan.DataAccess;
using Laxsan.Model;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;

namespace Laxsan
{
    public class ResultCalculator
    {
        #region Private Fields

        private readonly IUnitOfWork _laxsanWork;

        #endregion

        #region Public Constructor

        public ResultCalculator(IUnitOfWork unitOfWork)
        {
            _laxsanWork = unitOfWork;     
        }

        #endregion

        #region Public Methods
        public TestResult GetTestResult(IEnumerable<Question> questions)
        {
            TestResult testResult = new TestResult
            {
                TotalQuestion = _laxsanWork.QuestionSet.Count()
            };

            int totalCorrectAnswered = 0;
            var answerKey = _laxsanWork.QuestionSet.GetAnswerKey();
            foreach (var question in questions)
            {
                var answer = answerKey[question.Id];
                if (answer == question.Answer)
                {
                    totalCorrectAnswered++;
                }
            }
            testResult.CorrectAnswered = totalCorrectAnswered;

            if (totalCorrectAnswered >= testResult.TotalQuestion/2)
            {
                testResult.Status = "Pass";
            }
            else
            {
                testResult.Status = "Fail";
            }
            testResult.Percentage = (totalCorrectAnswered * 100 / testResult.TotalQuestion);

            return testResult;
        }
        #endregion
    }
}
