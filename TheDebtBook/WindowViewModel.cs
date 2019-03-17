using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using TheDebtBook;


namespace TheDebtBook
{
    public class WindowViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Debt> debts;

        public WindowViewModel()
        {
            debts = new ObservableCollection<Debt>();
            debts.Add(new Debt("Mie Kryds Nielsen" ,689, DateTime.Now));
            debts.Add(new Debt("Viggo", 100, DateTime.Now));
            CurrentDebt = debts[0];
        }

        #region Properties

        Debt currentDebt = null;

        public Debt CurrentDebt
        {
            get { return currentDebt; }
            set
            {
                if (currentDebt != value)
                {
                    currentDebt = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<Debt> Debts
        {
            get
            {
                return debts;
            }
        }

        #endregion

        #region Methods

        public void AddNewDebt(TextBox Name, TextBox Amount)
        {
            if (Name.Text == "dummy" && Amount.Text == "dummy")
            {
                for (int i = 0; i < 99; i++)
                {
                    debts.Add(new Debt("Dummy Data", 00, DateTime.MinValue));
                }
                return;
            }
            if (Name.Text != "" && Amount.Text.Length != 0)
            {
                double val;
                debts.Add(new Debt(Name.Text, (double.TryParse(Amount.Text, out val) ? val : Double.NaN), DateTime.Now));
            }
            else
            {
                MessageBox.Show("En (Eller flere!) af felterne var tomme Prøv igen!");
            }
            
           
        }

        public void DeleteDebt()
        {
            debts.Remove(CurrentDebt);
        }


        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
