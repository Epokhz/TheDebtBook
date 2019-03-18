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
    public class Debtbook : ObservableCollection<Debt>
    {
        static private ObservableCollection<Debt> debts;
        static private Debtbook Debtbook_ = null;

        static public Debtbook getDebts()
        {
            if (Debtbook_ == null)
            {
                Debtbook_ = new Debtbook();
                return Debtbook_;
            }
            else
            {
                return Debtbook_;
            }
        }

        private Debtbook()
        {
            
            //getDebts().Add(new Debt("Mie Kryds Nielsen", "689 kr", DateTime.Now));
            //getDebts().Add(new Debt("Viggo", "-100 kr", DateTime.Now));
        }
    }

    public class Debt
    {
        
        private string _name;
        private string _amount;
        private DateTime _datetime = DateTime.Now;

        
        public Debt(string aName, string anAmount, DateTime aTime)
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

        public string Amount
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

