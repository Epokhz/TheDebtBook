using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;


namespace TheDebtBook
{
    public class WindowViewModel : INotifyPropertyChanged
    {
        readonly ObservableCollection<Debt> debts;

        public WindowViewModel()
        {
            debts = new ObservableCollection<Debt>();
            debts.Add(new Debt("Mie Kryds Nielsen", "689 kr", DateTime.Now));
            debts.Add(new Debt("Viggo", "-100 kr", DateTime.Now));
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
                    debts.Add(new Debt("Dummy", "Data", DateTime.MinValue));
                }
                return;
            }
            if (Name.Text != "" && Amount.Text != "")
            {
                debts.Add(new Debt(Name.Text, Amount.Text + " kr", DateTime.Now));
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
