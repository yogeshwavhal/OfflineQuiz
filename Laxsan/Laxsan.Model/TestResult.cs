
namespace Laxsan.Model
{
    public class TestResult
    {
        /// <summary>
        /// State the result status (pass or fail)
        /// </summary>
        public string Status { get; set; }

        public int CorrectAnswered { get; set; }

        public int TotalQuestion { get; set; }

        public double Percentage { get; set; }
    }
}
