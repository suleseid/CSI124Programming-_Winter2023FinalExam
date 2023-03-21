using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CsvHelper;
using ClassLibrary;
using Transaction = ClassLibrary.Transaction;
using System.Collections;

namespace CSI124Programming__Winter2023FinalExam
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        List<Transaction> transactions = new List<Transaction>();
        private string TransactionTime;
        private readonly IEnumerable userTransaction;

        public UserPage()
        {
            InitializeComponent();
        }
        private void CreateNameFile(string filePath)
        {
            FileStream tryout = File.OpenRead(filePath);
            tryout.Close();
            tryout.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            double price = double.Parse(txtPrice.Text);
            string DateTime_TransactionTime;
            decimal _total;
            transactions.Add(new Transaction(name,TransactionTime, price));
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
                csvWriter.WriteRecords(userTransaction);
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
                transactions = csv.GetRecords<Transaction>().ToList();
            }

        }

        public void UpdateListView()
        {
            lvRoter2.Items.Clear();

            foreach (Transaction Ttansaction in Data1.transactions)
            {
                lvRoter2.Items.Add(transactions);
            }
        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            transactions.Sort();
            UpdateListView();
        }

        private void btnTransactionTime_Click(object sender, RoutedEventArgs e)
        {
            transactions.Sort();
            UpdateListView();
        }
    }
}
