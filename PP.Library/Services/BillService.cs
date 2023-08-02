using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Services
{
    public class BillService
    {
        private List<Bill> bills;

        public List<Bill> Bills
        { 
            get 
            { 
                return bills; 
            } 
        }

        private static BillService? instance;

        private static object _lock = new object();

        public static BillService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new BillService();
                    }
                    return instance;
                }
            }
        }

        private BillService()
        {
            bills = new List<Bill>();
        }

        public Bill? Get(int pid)
        {
            return Bills.FirstOrDefault(b => b.ProjectID == pid);
        }

        public void Add(Bill b)
        {
            if(b != null)
            {
                Bills.Add(b);
            }
        }

        public void Delete(Bill b)
        {
            if( b != null)
            {
                Bills?.Remove(b);
            }
        }

    }
}
