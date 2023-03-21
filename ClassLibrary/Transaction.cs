using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Transaction : IComparable<Transaction>
    {
        DateTime _transactionTime;
        string _name;
        decimal _price;
        decimal _tax;
        decimal _total;
        public object UserRole;
        public static object Role;

        public DateTime DateTime { get => _transactionTime; set => _transactionTime = value; }
        public string Name { get => _name; set => _name = value; }
        public decimal Price { get => _price; set => _price = value; }
        public decimal Tax { get => _tax; set => _tax = value; }
        public decimal Total { get => _total; set => _total = value; }
        public double Price1 { get; }
        public string DateTime_TransactionTime { get; }
        public double Price2 { get; }

        public Transaction()
        {

        }

        public Transaction(DateTime transactionTime, string name, decimal price, decimal tax, decimal total)
        {
            _transactionTime = transactionTime;
            _name = name;
            _price = price;
            _tax = tax;
            _total = total;
        }

        public Transaction(string name, double price)
        {
            Name = name;
            Price1 = price;
        }

        public Transaction(string name, string dateTime_TransactionTime, double price)
        {
            Name = name;
            DateTime_TransactionTime = dateTime_TransactionTime;
            Price2 = price;
        }

        public int CompareTo(Transaction other)
        {
            return _name.CompareTo(other._name);
        }
       
     
    }
}
