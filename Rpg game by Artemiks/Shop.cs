using System;
using System.Windows.Forms;

namespace Rpg_game_by_Artemiks
{
    public partial class ShopForm : Form
    {
        private Random rnd = new Random();
        private int balance = 0;

        public ShopForm()
        {
            InitializeComponent();
            if (System.IO.File.Exists("coins.txt"))
            {
                int savedCoins;
                if (int.TryParse(System.IO.File.ReadAllText("coins.txt"), out savedCoins))
                {
                    balance = savedCoins;
                }
            }
            else
            {
                balance = 0;
            }

            label3.Text = "Баланс: " + balance + " $";


            label3.Text = "Баланс: " + balance + " $";

            int chance = rnd.Next(1, 101);

            if (chance <= 50)
            {
                label1.Text = "Магазин зброї";
                for (int i = 1; i <= 10; i++)
                {
                    listBox1.Items.Add("Зброя " + i);
                }
            }
            else
            {
                label1.Text = "Магазин захисту";
                for (int i = 1; i <= 10; i++)
                {
                    listBox1.Items.Add("Броня " + i);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("coins.txt", label3.ToString());

            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Виберіть товар зі списку!");
                return;
            }

            if (balance >= 500)
            {
                balance -= 500;
                label3.Text = "Баланс: " + balance + " $";
                MessageBox.Show("Ви купили: " + listBox1.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Не вистачає грошей!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Asterisk.Play();
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Виберіть товар зі списку!");
                return;
            }

            if (balance >= 500)
            {
                balance -= 500;
                label3.Text = "Баланс: " + balance + " $";
                MessageBox.Show("Ви купили: " + listBox1.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Не вистачає грошей!");
            }
        }
    }
}


