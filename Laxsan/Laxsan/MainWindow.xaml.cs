using Laxsan.DataAccess;
using Laxsan.Model;
using Laxsan.ViewModels;
using System.Windows;

namespace Laxsan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(
            IUnitOfWork laxsanWork,
            IDialogService dialogService)
        {
            InitializeComponent();

            var viewModel = new MainWindowVM(laxsanWork, dialogService);
            this.DataContext = viewModel;
        }
    }
}
