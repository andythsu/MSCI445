﻿using System;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        readonly MyEmail myEmail;
        readonly PasswordBox PASSWORD_TEXTBOX;

        public PasswordWindow(MyEmail myEmail)
        {
            InitializeComponent();
            this.myEmail = myEmail;
            PASSWORD_TEXTBOX = (PasswordBox)this.FindName("password_textbox");
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.myEmail.setPassword(PASSWORD_TEXTBOX.Password);
            myEmail.send();
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
