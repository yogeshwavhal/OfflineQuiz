namespace Laxsan.DataAcess.Repositories
{
    using Laxsan.Contracts;
    using Laxsan.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuestionRepository : IQuestionRepository
    {
        #region Private Fields
        private readonly List<Question> questions;
        private Random _random;
        private List<int> _randomNumbers;
        private IReadOnlyDictionary<string, string> _answerKey;
        #endregion

        #region Public Constructors
        public QuestionRepository()
        {
            questions = new List<Question>();
            _random = new Random();
            _randomNumbers = new List<int>();
            //This method will not be required if we use DB here
            Seed();
            PrepareAnswerKey();
        }
        #endregion

        #region Public Methods

        public Question Add(Question entity)
        {
            questions.Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<Question> entities)
        {
            questions.AddRange(entities);
        }

        public void Delete(Question entity)
        {
            questions.Remove(entity);
        }

        public void DeleteRange(IEnumerable<Question> entities)
        {
            throw new System.NotImplementedException();
        }

        public Question Get(string id)
        {
            return questions.FirstOrDefault(quest => quest.Id == id);
        }

        public IEnumerable<Question> GetAll()
        {
            return questions;
        }

        public Question GetRandom()
        {
            var randomQuestionId = GetRandomQuestionId();
            return Get(randomQuestionId);
        }

        public bool AllQuestionDone()
        {
            if (_randomNumbers.Count == 6)
                return true;
            return false;
        }

        /// <summary>
        /// Gets the answer key for question set
        /// </summary>
        /// <returns></returns>
        public IReadOnlyDictionary<string, string> GetAnswerKey()
        {
            return _answerKey;
        }

        public int Count()
        {
            return questions.Count;
        }

        #endregion Public Methods

        #region Private Methods

        private string GetRandomQuestionId()
        {
            //To get the random question
            int number;
            do
            {
                number = _random.Next(1, 7);
            } while (_randomNumbers.Contains(number));
            _randomNumbers.Add(number);
            return number.ToString();
        }

        /// <summary>
        /// Create seeds
        /// </summary>
        private void Seed()
        {
            var question1 = new Question
            {
                Id = "1",
                Content = "Which state produces maximum soybean?",
                Choices = new List<string>()
                {
                    "MP",
                    "UP",
                    "Bihar",
                    "Maharashtra",
                },
               // Answer = "MP"
            };
            var question2 = new Question
            {
                Id = "2",
                Content = "2 + 2 = ?",
                Choices = new List<string>()
                {
                    "3",
                    "4",
                    "5",
                    "2",
                },
                //Answer = "4"
            };
            var question3 = new Question
            {
                Id = "3",
                Content = "5 * 6 = ?",
                Choices = new List<string>()
                {
                    "28",
                    "32",
                    "29",
                    "30",
                },
               // Answer = "30"
            };
            var question4 = new Question
            {
                Id = "4",
                Content = "Which country operationalized world’s largest radio telescope?",

                Choices = new List<string>()
                {
                    "USA",
                    "China",
                    "Russia",
                    "India",
                },
               // Answer = "China"
            };
            var question5 = new Question
            {
                Id = "5",
                Content = "What is India’s rank on EIU’s Global Democracy Index 2019?",
                Choices = new List<string>()
                {
                    "48",
                    "51",
                    "52",
                    "49",
                },
                //Answer = "51"
            };
            var question6 = new Question
            {
                Id = "6",
                Content = "999 - 888",
                Choices = new List<string>()
                {
                    "121",
                    "211",
                    "111",
                    "131",
                },
               // Answer = "111"
            };

            

            //var question7 = new Question
            //{
            //    Id = "7",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //};
            //var question8 = new Question
            //{
            //    Id = "8",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //}; 
            //var question9 = new Question
            //{
            //    Id = "9",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //};
            //var question10 = new Question
            //{
            //    Id = "10",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //}; 
            //var question11 = new Question
            //{
            //    Id = "11",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //};
            //var question12 = new Question
            //{
            //    Id = "12",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //}; 
            //var question13 = new Question
            //{
            //    Id = "13",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //};
            //var question14 = new Question
            //{
            //    Id = "14",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //}; 
            //var question15 = new Question
            //{
            //    Id = "15",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //};
            //var question16 = new Question
            //{
            //    Id = "16",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //};
            //var question17 = new Question
            //{
            //    Id = "17",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //};
            //var question18 = new Question
            //{
            //    Id = "18",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //};
            //var question19 = new Question
            //{
            //    Id = "19",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //}; 
            //var question20 = new Question
            //{
            //    Id = "20",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //}; 
            //var question21 = new Question
            //{
            //    Id = "21",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //}; 
            //var question22 = new Question
            //{
            //    Id = "22",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //};
            //var question23 = new Question
            //{
            //    Id = "23",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //};
            //var question24 = new Question
            //{
            //    Id = "24",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //}; 
            //var question25 = new Question
            //{
            //    Id = "25",
            //    Content = "",
            //    FirstOption = "",
            //    SecondOption = "",
            //    ThirdOption = "",
            //    FourthOption = "",
            //    Answer = ""
            //};

            questions.Add(question1);
            questions.Add(question2);
            questions.Add(question3);
            questions.Add(question4);
            questions.Add(question5);
            questions.Add(question6);
            //questions.Add(question7);
        }

        private void PrepareAnswerKey()
        {
            _answerKey = new Dictionary<string, string>()
           {
               {"1", "MP"},
               {"2", "4"},
               { "3", "30"},
               { "4", "China"},
               {"5", "51" },
               { "6", "111"}
           };
        }
        #endregion Private Methods
    }
}
