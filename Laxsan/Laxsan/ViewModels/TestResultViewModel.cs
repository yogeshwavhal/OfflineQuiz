

namespace Laxsan.ViewModels
{
    using System;
    using Laxsan.Model;

    public class TestResultViewModel : BindableBase, IDialogRequestClose
    {
        #region Public Constructor
        public TestResultViewModel(TestResult testResult)
        {
            ResultStatus = testResult.Status;
            TotalQuestions = testResult.TotalQuestion;
            CorrectAnswered = testResult.CorrectAnswered;
            Percentage = testResult.Percentage;
            if (ResultStatus == "Pass")
            {
                //This messages should be written in resx file for multilingual purpose
                GreetingMessage = "Congratulations! You are passed...";
            }
            else
            {
                GreetingMessage = "Sorry...Please try next time";
            }

            OkCommand = new RelayCommand(OnOk, CanOk);
            CancelCommand = new RelayCommand(OnCancel, CanCancel);
        }
        #endregion Public Constructor

        #region Public Events

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        #endregion Public Events

        #region Public Relay Commands

        public RelayCommand OkCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        #endregion Public Relay Commands

        #region Public Propertes

        public string GreetingMessage { get; set; }

        public string ResultStatus { get; set; }

        public int TotalQuestions { get; set; }

        public int CorrectAnswered { get; set; }

        public double Percentage { get; set; }

        #endregion Public Properties

        #region Private Methods

        private bool CanOk(object obj)
        {
            return true;
        }

        private void OnOk(object obj)
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
            App.Current.Shutdown();
        }

        private void OnCancel(object obj)
        {
            App.Current.Shutdown();
        }

        private bool CanCancel(object obj)
        {
            return true;
        }

        #endregion Private Methods

    }
}
