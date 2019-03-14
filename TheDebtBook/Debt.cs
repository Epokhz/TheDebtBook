using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TheDebtBook
{
    public class Debt
    {
        private string _name;
        private string _amount;

        public Debt()
        {
        }

        public Debt(string aName, string anAmount)
        {
            _name = aName;
            _amount = anAmount;
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


    }
}
