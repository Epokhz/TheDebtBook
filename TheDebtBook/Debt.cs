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
        private List<double> _amount;
        private double _sum;
        private DateTime _datetime = DateTime.Now;

        public Debt()
        {   
        }

        public Debt(string aName, double anAmount, DateTime aTime)
        {
            _name = aName;
            _amount = new List<double>();
            _amount.Add(anAmount);
            _sum = _amount[0];
            _datetime = aTime;
        }

        public void addToHistory(double amount)
        {
            _amount.Add(amount);
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

     

        public DateTime Time
        {
            get => _datetime;
            set => _datetime = value;
        }

        public double Sum
        {
            get => _sum;
            set => _sum = value;
        }

        public List<double> getAmount()
        {
            return _amount;
        }

        public void setAmount(List<double> amount)
        {
            _amount = amount;
        }

    }
}
