using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media.Animation;

namespace TheDebtBook
{
    public class Debt
    {
        private string _name;
        private double _amount;
        private string _sum;
        private DateTime _datetime = DateTime.Now;

        public Debt()
        {   
        }

        public Debt(string aName, double anAmount, DateTime aTime)
        {
            _name = aName;
            _amount = anAmount;
            _datetime = aTime;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public double Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public DateTime Time
        {
            get => _datetime;
            set => _datetime = value;
        }



    }
}
