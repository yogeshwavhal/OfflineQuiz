

namespace Laxsan.ViewModels
{
    using Laxsan.DataAccess;
    using Laxsan.Model;
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Threading;
    using Unity;

    public class MainWindowVM : BindableBase
    {
        #region Private Fields
        private readonly IUnitOfWork _laxsanWork;
        private TimeSpan _time;
        private readonly IDialogService _dialogService;
        private string _currentTime;
        private DispatcherTimer _timer;
        private QuestionViewModel _questionViewModel;
        private Stack<QuestionViewModel> _prevQuestionStack;
        private Stack<QuestionViewModel> _nextQuestionStack;
        private ResultCalculator _resultCalculator;
        private List<int> _randomNumbers;
        private Random _random;

        #endregion Private Fields

        #region Public Constructor
        public MainWindowVM(
            IUnitOfWork laxsanWork,
            IDialogService dialogService)
        {
            _dialogService = dialogService;
            _laxsanWork = laxsanWork;
            _resultCalculator = new ResultCalculator(_laxsanWork);
            //We are tracking prev and next questions
            //We can also use DoublyLinkedList here
            _prevQuestionStack = new Stack<QuestionViewModel>();
            _nextQuestionStack = new Stack<QuestionViewModel>();
            _randomNumbers = new List<int>();
            _random = new Random();

            NextQuestionCommand = new RelayCommand(OnNextQuestion, CanNextQuestion);
            PrevQuestionCommand = new RelayCommand(OnPrevQuestion, CanPrevQuestion);
            SubmitTestCommand = new RelayCommand(OnSubmitTest, CanSubmitTest); 

            _time = TimeSpan.FromSeconds(60);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                CurrentTime = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    //Once time of quiz ended call this method
                    OnTimerElapsed();
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timer.Start();

            CurrentQuestionViewModel = GetQuestionViewModel();
        }

    

        #endregion Public Constructor

        #region Public Commands
        public RelayCommand NextQuestionCommand { get; set; }

        public RelayCommand PrevQuestionCommand { get; set; }

        public RelayCommand SubmitTestCommand { get; set; }

        #endregion

        #region Public Properties

        public string CurrentTime
        {
            get
            {
                return this._currentTime;
            }
            set
            {
                SetProperty(ref _currentTime, value);
            }
        }

        public QuestionViewModel CurrentQuestionViewModel
        {
            get => _questionViewModel;
            set
            {
                SetProperty(ref _questionViewModel, value);
                PrevQuestionCommand.RaiseCanExecuteChanged();
                NextQuestionCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion Public Properties

        #region Private Event Handler
        private void OnTimerElapsed()
        {
            TestResult testResult = GetTestResult();
            _dialogService.ShowDialog(new TestResultViewModel(testResult));
        }

        private void OnPrevQuestion(object obj)
        {
            if (_prevQuestionStack.Count != 0)
            {
                _nextQuestionStack.Push(CurrentQuestionViewModel);
                CurrentQuestionViewModel = _prevQuestionStack.Pop();
            }
        }

        private bool CanPrevQuestion(object obj)
        {
            if (_prevQuestionStack.Count == 0)
            {
                return false;
            }
            return true;
        }

        private bool CanNextQuestion(object obj)
        {
            if (_laxsanWork.QuestionSet.AllQuestionDone()
                && _nextQuestionStack.Count == 0)
            {
                return false;
            }
            return true;
        }

        private QuestionViewModel GetQuestionViewModel()
        {
            var question = _laxsanWork.QuestionSet.GetRandom();
            return new QuestionViewModel(question);
        }

        private void OnNextQuestion(object obj)
        {
          
            if (_nextQuestionStack.Count == 0)
            {
                _prevQuestionStack.Push(CurrentQuestionViewModel);
                CurrentQuestionViewModel = GetQuestionViewModel();
            }
            else
            {
                _prevQuestionStack.Push(CurrentQuestionViewModel);
                CurrentQuestionViewModel = _nextQuestionStack.Pop();
            }
        }

        private bool CanSubmitTest(object obj)
        {
            return true ;
        }

        private void OnSubmitTest(object obj)
        {
            TestResult testResult = GetTestResult();
            _dialogService.ShowDialog(new TestResultViewModel(testResult));
        }

        private TestResult GetTestResult()
        {
            List<Question> questionsWihChosenAnswer = new List<Question>();
            foreach (var questionVM in _prevQuestionStack)
            {
                questionsWihChosenAnswer.Add(questionVM.Question);
            }
            foreach (var questionVM in _nextQuestionStack)
            {
                questionsWihChosenAnswer.Add(questionVM.Question);
            }

            questionsWihChosenAnswer.Add(CurrentQuestionViewModel.Question);

            var testResult = _resultCalculator.GetTestResult(questionsWihChosenAnswer);
            return testResult;
        }
     
        #endregion Private Event Handler
    }
}
