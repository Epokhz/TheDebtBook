using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using TheDebtBook;


namespace TheDebtBook.
{
    public class WindowViewModel : INotifyPropertyChanged { 
       
        private Debtbook minbook;


        public WindowViewModel()
        {
            minbook = Debtbook.getDebts();
        }


        public Debtbook getBook()
        {
            return minbook;
        }

        public void AddNewDebt(TextBox Name, TextBox Amount, object DC)
        {
            if (Name.Text == "dummy" && Amount.Text == "dummy")
            {
                for (int i = 0; i < 99; i++)
                {
                    minbook.Add(new Debt("Dummy", "Data" + " kr", DateTime.Now));
                }

                return;
            }

            if (Name.Text != "" && Amount.Text != "")
            {

                minbook.Add(new Debt(Name.Text, Amount.Text + " kr", DateTime.Now));
                return;
            }
            else
            {
                MessageBox.Show("En (Eller flere!) af felterne var tomme Prøv igen!");
            }


        }

        public void DeleteDebt()
        {
            var index = ((MainWindow) Application.Current.MainWindow).ListboxDebts.SelectedIndex;
            minbook.RemoveAt(index);
            return;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
};


