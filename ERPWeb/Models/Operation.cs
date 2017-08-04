using System;

namespace ERPWeb.Models
{
    public class Operation
    {
        private TimeSpan timespan;

        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual TimeSpan Timespan { get; set; }
        public virtual double Duration
        {
            get { return timespan.Minutes; }
            set { timespan = TimeSpan.FromMinutes(value); }
        }
    }
}