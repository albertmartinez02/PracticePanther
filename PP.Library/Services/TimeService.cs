using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Services
{
    public class TimeService
    {
        private List<Time> times;

        public List<Time> Times
        {
            get
            {
                return times;
            }
        }

        private static TimeService? instance;

        private static object _lock = new object();

        public static TimeService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new TimeService();
                    }
                }
                return instance;
            }
        }

        private TimeService()
        {
            times = new List<Time>
            {
                new Time {Id=1 , EmployeeId=1 , ProjectId=1 , Hours=1.75M , Narrative="Test"},
            };
        }

        public Time? Get(int Tid)
        {
            return times.FirstOrDefault(t => t.Id == Tid);
        }

        public void Add(Time? time)
        {
            if (time != null)
                times.Add(time);
        }

        public void Read()
        {
            times.ForEach(Console.WriteLine);
        }

        public void Delete(Time t)
        {
            Times?.Remove(t);
        }

        public void AddOrUpdate(Time t)
        {
            if (t != null && t.Id == 0)
            {
                t.Id = LastID + 1;
                times.Add(t);
            }
        }

        private int LastID
        {
            get
            {
                return Times.Any() ? Times.Select(t => t.Id).Max() : 0;
            }
        }
    }
}
