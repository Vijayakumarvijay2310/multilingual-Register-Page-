using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using firstapp.Properties;

namespace firstapp
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            
            string firstname;
            string lastname;
            if (txtname.Text.Contains(" "))
            {
                int index = txtname.Text.IndexOf(" ");
                 firstname = txtname.Text.Remove(index);
                 lastname = txtname.Text.Substring(index);
                MessageBox.Show("FirstName :" + firstname);
                MessageBox.Show("LastName :" + lastname);
            }
            else
            {
                 firstname = txtname.Text;
                MessageBox.Show("FirstName :" + firstname);
            }

            string phone = txtphone.Text;
            string age = txtage.Text;
            MessageBox.Show("Phone :" + phone);
            MessageBox.Show("Age :" + age);

            char[] password = txtpassword.Password.ToCharArray();
            int count = password.Count();
            int passwordscore = 0;

            int isdigit = 0;
            int isletter = 0;
            int isletterordigit = 0;

            for(int i = 0; i < count; i++)
            {
                if (char.IsDigit(password[i]) && isdigit == 0)
                {
                    isdigit = 1;
                }else if (char.IsLetter(password[i]) && isletter == 0)
                {
                    isletter = 1;
                } else if (!char.IsLetterOrDigit(password[i]) && isletterordigit == 0){
                    isletterordigit = 1;
                }
            }
            passwordscore = isdigit + isletter + isletterordigit;

            if(passwordscore == 0)
            {
                txtpassworderror.Text = "invalid password";
                txtpassworderror.Foreground = Brushes.Red;
            }else if (passwordscore == 1)
            {
                txtpassworderror.Text = "Password is weak";
                txtpassworderror.Foreground = Brushes.Red;
            } else if (passwordscore == 2)
            {
                txtpassworderror.Text = "Password is medium strong";
                txtpassworderror.Foreground = Brushes.Blue;
            }else if (passwordscore ==3)
            {
                txtpassworderror.Text = "Good Choice";
                txtpassworderror.Foreground = Brushes.Green;
            }

            if (txtpassword.Password != txtrepassword.Password)
            {
                txtrepassworderror.Text = "Please re-enter the same password";
                txtrepassworderror.Foreground = Brushes.Red;
            }else
            {
                txtrepassworderror.Text = "";
            }
        }

        private void btnclear(object sender, RoutedEventArgs e)
        {
            txtname.Clear();
            txtphone.Clear();
            txtage.Clear();
            txtpassword.Clear();
            txtrepassword.Clear();
            txtpassworderror.Text = "";
            txtrepassworderror.Text = "";
        }

        private void btn_save(object sender, RoutedEventArgs e)
        {
            RadioButton first = (RadioButton)stlanguage.Children[0];
            RadioButton second = (RadioButton)stlanguage.Children[1];
            RadioButton third = (RadioButton)stlanguage.Children[2];
            Settings os = new Settings();
            if (first.IsChecked == true)
            {  
                os.Language = first.Tag.ToString();
                os.Save();
            }
            if (second.IsChecked == true)
            {
                os.Language = second.Tag.ToString();
                os.Save();
            }
            if (third.IsChecked == true)
            {
                os.Language = third.Tag.ToString();
                os.Save();
            }
        }
    }
}
