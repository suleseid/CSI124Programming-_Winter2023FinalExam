using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Transaction_Sort_Time : IComparer<Transaction>
    {
        public int Compare(Transaction x, Transaction y)
        {
            return x.DateTime.CompareTo(y.DateTime);
        }
    }
}
