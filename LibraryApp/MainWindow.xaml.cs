using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryApp
{
    public partial class MainWindow : Window
    {
        private LoginWindow loginWindow = null;
        private RegistrationWindow registrationWindow = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (registrationWindow == null)
            {
                registrationWindow = new RegistrationWindow();
                registrationWindow.Closed += (s, args) => registrationWindow = null;
                registrationWindow.ShowDialog();
                this.Close();
            }
            else
            {
                loginWindow.ShowDialog();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginWindow == null)
            {
                loginWindow = new LoginWindow();
                loginWindow.Closed += (s, args) => loginWindow = null;
                loginWindow.ShowDialog();
                this.Close();
            }
            else
            {
                loginWindow.ShowDialog();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}