using Laxsan.DataAccess;
using Laxsan.Model;
using Laxsan.ViewModels;
using Laxsan.Views;
using System.Windows;
using Unity;

namespace Laxsan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IDialogService dialogService = new DialogService(App.Current.MainWindow);
            dialogService.Register<LoginViewModel, LoginView>();
            dialogService.Register<TestResultViewModel, TestResultView>();

            var loginViewModel = new LoginViewModel(
                ContainerHelper.Container.Resolve<UnitOfWork>(),
                dialogService);
            dialogService.ShowDialog(loginViewModel);
           
        }
    }
}
