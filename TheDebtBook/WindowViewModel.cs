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


namespace TheDebtBook 
{
    public class WindowViewModel { 
       
        private Debtbook _minbook;

        public WindowViewModel(Debtbook minbook)
        {
            _minbook = Debtbook.getDebts();
        }


        

        public void AddNewDebt(TextBox Name, TextBox Amount, object DC)
        {
            if (Name.Text == "dummy" && Amount.Text == "dummy")
            {
                for (int i = 0; i < 99; i++)
                {
                   
                }

                return;
            }

            if (Name.Text != "" && Amount.Text != "")
            {

                debts.Add(new Debt(Name.Text, Amount.Text + " kr", DateTime.Now));
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
            debts.RemoveAt(index);
            return;
        }
    }
};


