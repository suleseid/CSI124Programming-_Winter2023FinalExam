using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using ClassLibrary;
using Transaction = ClassLibrary.Transaction;

namespace CSI124Programming__Winter2023FinalExam
{
    public static class Data1
    {
        public static UserAccount currentUserAccount = null;
        public static Transaction currenTransactiont = null;
        public static string userFilePath = @"userAccountList.json";
        public static List<UserAccount> userAccounts = new List<UserAccount>();
        public static string AdminPageExtension = "_transaction.csv";
        public static string UserPageExtantion = "";
        public static List<Transaction> transactions = new List<Transaction>();
       //  private static object currentUsersTransaction;
       // private static object currentTransaction;

        public static string UserPageExtension { get; private set; }

        static Data1()
        {
            ReadUserAccount();
        }

        public static string UsersTransactions()
        {
            return currentUserAccount.Name + AdminPageExtension;
        }

        public static void SerilizedAdminPage()
        {

            JsonSerializerOptions jso = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonUserAccount = JsonSerializer.Serialize(userAccounts, jso);

            File.WriteAllText(Data1.userFilePath, jsonUserAccount);
        }

        public static void ReadUserAccount()
        {
            // ---- Read file back
            // File destination
            string filePath = Data1.userFilePath;
            // Reads all text from file
            string listFromFile = File.ReadAllText(filePath);
            // COnverts text to List of Name
            userAccounts = JsonSerializer.Deserialize<List<UserAccount>>(listFromFile);
        }

        public static string usersFilePath()
        {
            throw new NotImplementedException();
        }
    } 
}
