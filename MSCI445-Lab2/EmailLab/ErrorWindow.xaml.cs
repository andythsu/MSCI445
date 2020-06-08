using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace EmailLab
{
    public partial class ErrorWindow : Window, INotifyPropertyChanged
    {
        String errors;

        public ErrorWindow(String errors)
        {
            InitializeComponent();
            this.errors = errors;
            DataContext = this;
            this._errormessage = this.errors;
        }

        private string _errormessage = "this is the error message";
        public string errormessage
        {
            get { return _errormessage; }
            set
            {
                _errormessage = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion


        private void OK_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MyTargetControl_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
