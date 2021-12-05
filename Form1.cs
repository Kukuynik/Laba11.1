using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba11._1
{
    public partial class Form1 : Form
    {
        BankAccount account1 = new BankAccount(1200, TypeOfAccount.DEBIT);
        Song mySong = new Song();
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add(account1.accountNumber);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            account1.PutMoney(Convert.ToInt32(textBox4.Text));  
            textBox3.Text = Convert.ToString(account1.accountBalance);
            foreach(BankTransaction bank in account1.accountTransactions)
            {
                richTextBox1.Text += bank.showInfo();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                textBox2.Text = Convert.ToString(account1.accountType);
                textBox3.Text = Convert.ToString(account1.accountBalance);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (account1.accountBalance >= Convert.ToInt32(textBox4.Text))
            {
                richTextBox1.Clear();
                account1.TakeMoney(Convert.ToInt32(textBox4.Text));
                textBox3.Text = Convert.ToString(account1.accountBalance);
                foreach (BankTransaction bank in account1.accountTransactions)
                {
                    richTextBox1.Text += bank.showInfo();
                }
            }
            else MessageBox.Show("Недостаточно средсв");
        }
    }
}
