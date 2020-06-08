using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmailLab
{
    /// <summary>
    /// Interaction logic for PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        // declare a custom email class
        readonly MyEmail myEmail;
        // declare a passwordbox variable
        readonly PasswordBox PASSWORD_TEXTBOX;

        public PasswordWindow(MyEmail myEmail)
        {
            // initialize component
            InitializeComponent();
            // initialize myEmail
            this.myEmail = myEmail;
            // initialize password box
            PASSWORD_TEXTBOX = (PasswordBox)FindName("password_textbox");
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            // set the password to the password inputted by user
            myEmail.setPassword(PASSWORD_TEXTBOX.Password);
            // send the email
            if (myEmail.send())
            {
                // if email is send successfully, display a success message
                MessageBox.Show("Email successfully delivered");
            }
            else
            {
                // if email failed to send, display a failure message
                MessageBox.Show("Email failed to deliver");
            }
            // close passwordbox at the end
            Close();
        }
        // if cancel button is clicked, close the password form
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
