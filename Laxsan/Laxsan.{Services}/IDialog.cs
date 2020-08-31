namespace Laxsan
{
    using System.Windows;

    public interface IDialog
    {
        object DataContext { get; set; }

        bool ? DialogResult { get; set; }

        Window Owner { get; set; }

        void Close();

        bool? ShowDialog();
    }
}
