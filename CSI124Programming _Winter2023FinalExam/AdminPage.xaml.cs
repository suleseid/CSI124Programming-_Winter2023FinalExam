using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClassLibrary;
using CsvHelper;

namespace CSI124Programming__Winter2023FinalExam
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        List<UserAccount> userAccounts = new List<UserAccount>();

        //  private UserAccount.Role role;

        public AdminPage()
        {
            InitializeComponent();
            CreateNameFile(Data1.usersFilePath());
            ReadFullList();
            UpdateListView();

            // userAccounts.Add(new UserAccount("Will", "Cram", "76", userRole));
        }

        private void CreateNameFile(string filePath)
        {
            FileStream tryout = File.OpenRead(filePath);
            tryout.Close();
            tryout.Dispose();
        }

        /*  public void CboxRoll_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
                  CboxRoll.Items.Add("User");
                  CboxRoll.Items.Add("Admin");
                  CboxRoll.SelectedIndex = 0; 

          }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string userRole= txtName.Text;

            userAccounts.Add( new UserAccount(name, username, password, userRole));
            SaveList();
            UpdateListView();
        }

        public void SaveList()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            string filePath = Data1.usersFilePath();

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                // .WriteRecords(list);
                csvWriter.WriteRecords(userAccounts);
                writer.Flush();
            }
        } // SaveList

        public void ReadFullList()
        {
            string filePath = Data1.usersFilePath();

            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                // Pull the entire csv file as a list of Player
                // For this to work, class must have a default constructor,
                // and properties must be the EXACT SAME NAME AND SPELLING AS HEADERS IN CSV
                userAccounts = csv.GetRecords<UserAccount>().ToList();
            }

        }

        public void UpdateListView()
        {
            lvRoster.Items.Clear();

            foreach (UserAccount userAccount in Data1.userAccounts)
            {
                lvRoster.Items.Add(userAccount);
            }
        }

      
    }
        
}
