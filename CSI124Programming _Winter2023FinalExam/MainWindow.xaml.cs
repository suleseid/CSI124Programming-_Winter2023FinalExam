using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary;

namespace CSI124Programming__Winter2023FinalExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // UserAccount userAccount = new UserAccount("Sule", "SuleS", "S", UserAccount.Role.Admin);
        public MainWindow()
        {
            InitializeComponent();
            SerilizedAdminPage();
        }

        private void SerilizedAdminPage()
        {
            throw new NotImplementedException();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            ValidateUser();
        }

        public void ValidateUser()
        {
            string userInputeName = txtUserName.Text;
            string userPassword = psPassword.Password;

            foreach (UserAccount userAccount in Data1.userAccounts)
            {
                if (userAccount.IsUser(userInputeName))
                {
                    if (userAccount.ValidateUser(userInputeName, userPassword))
                    {
                        //This will run when the user has properly logged in
                        Data1.currentUserAccount = userAccount;

                        if (Data1.currentUserAccount.UserRole == UserAccount.Role.Admin)
                        {
                            new AdminPage().Show();
                        }
                        else if(Data1.currenTransactiont.UserRole == Transaction.Role.User)
                        {
                            MessageBox.Show("UserRole");
                        }
                        else
                        {
                            MessageBox.Show("");
                        }
                    }

                }
            }
        }//ValidateUser



    }
    
        
}
