
namespace Laxsan.ViewModels
{
    using Laxsan.Model;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class QuestionViewModel : BindableBase
    {
        #region Private Fields

        private string _question;
        private static int _questionCounter = 0;
        private string _questionNumber;
        private ObservableCollection<string> _choices;
        private string _chosenAnswer;
        #endregion Private Fields

        #region Public Constructor
        public QuestionViewModel(Question question)
        {
            _choices = new ObservableCollection<string>(question.Choices);
            Question = question;
            Content = question.Content;
            QuestionNumber =  "Q." + (++_questionCounter) + ")";
        }

        #endregion Public Constructor

        #region Public Commands

        public RelayCommand<string> OptionSelectionCommand { get; set; }

        #endregion

        #region Public Properties

        public Question Question { get; set; }

        public string QuestionNumber
        {
            get => _questionNumber;
            set => SetProperty(ref _questionNumber, value);
        }

        public string Content
        {
            get => _question;
            set => SetProperty(ref _question, value);
        }

        public ObservableCollection<string> Choices
        {
            get => _choices;
            set => SetProperty(ref _choices, value);
        }

        public string ChosenAnswer
        {
            get => _chosenAnswer;
            set
            {
                SetProperty(ref _chosenAnswer, value);
                Question.Answer = _chosenAnswer;
            }
        }

        #endregion Public Properties
    }
}
