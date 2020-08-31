namespace Laxsan.ViewModels
{
    using System;
    using Laxsan.DataAccess;
    using Laxsan.Model;

    public class LoginViewModel : BindableBase, IDialogRequestClose
    {
        #region Private Fields

        private readonly IDialogService _dialogService;
        private readonly IUnitOfWork _laxsanWork;
        private string _userId;
        private string _password;
        private string _notification;
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        #endregion Private Fields

        #region Public Constructor

        public LoginViewModel(
            IUnitOfWork laxsanWork,
            IDialogService dialogService)
        {
            _dialogService = dialogService;
            _laxsanWork = laxsanWork;

            LoginCommand = new RelayCommand(OnLogin, CanLogin);
            CancelCommand = new RelayCommand(OnCancel, CanCancel);
            PasswordChangedCommand = new RelayCommand<object>(OnPasswordChanged);
        }

        #endregion Public Constructors

        #region Public Properties

        public string UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                SetProperty(ref _userId, value);
                LoginCommand.RaiseCanExecuteChanged();
                Notification = string.Empty;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                LoginCommand.RaiseCanExecuteChanged();
                Notification = string.Empty;
            }
        }

        public string Notification
        {
            get => _notification;
            set
            {
                SetProperty(ref _notification, value);
            }
        }
        #endregion Public Properties

        #region Public Relay Commands

        public RelayCommand LoginCommand { get; private set; }

        public RelayCommand CancelCommand { get; private set; }

        public RelayCommand<object> PasswordChangedCommand { get; private set; }

        #endregion Public Relay Commands

        #region Private Methods

        private void OnLogin(object obj)
        {
            var user = new User
            {
                UserName = this.UserId,
                Password = this.Password
            };
            Authenticator authenticator = new Authenticator(_laxsanWork);
            var success = authenticator.Authenticate(user);
            if (success)
            {
                var dashBoard = new MainWindow(_laxsanWork, _dialogService);
                dashBoard.Show();
                CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
            }
            else
            {
                //TODO : Use message from resex file
                Notification = "UserId or password is invalid";
            }
        }

        private bool CanLogin(object obj)
        {
            if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Password))
            {
                return false;
            }

            return true;
        }

        private void OnCancel(object obj)
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false));
        }

        private bool CanCancel(object obj)
        {
            return true;
        }

        private void OnPasswordChanged(object obj)
        {
            Password = ((System.Windows.Controls.PasswordBox)obj).Password;
        }
        #endregion Private Methods
    }
}
