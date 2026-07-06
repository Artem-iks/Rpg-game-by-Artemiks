using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rpg_game_by_Artemiks
{
    public partial class BattleForm : Form
    {
        public BattleForm()
        {
            InitializeComponent();


            progressBar1.Value = 100;
            progressBar2.Value = 100;
            progressBar3.Value = 100;
        }
        private bool isVictory = false;


        private void button1_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value <= 0 || progressBar3.Value <= 0) return;

            if (progressBar2.Value >= 10)
            {
                progressBar2.Value -= 10;
                progressBar3.Value = Math.Max(0, progressBar3.Value - 5);
                listBox1.Items.Add("Ви використали Атаку (-10 MP) і нанесли 5 урону!");

                if (progressBar3.Value <= 0)
                {
                    MessageBox.Show("Ви перемогли!");
                    isVictory = true;


                    Form2 mainMenu = (Form2)Application.OpenForms["Form2"];
                    if (mainMenu != null)
                    {
                        mainMenu.clickCount = 0;
                    }
                    this.Close();

                   
                }
                else
                {
                    EnemyTurn();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value <= 0 || progressBar3.Value <= 0) return;

            if (progressBar2.Value >= 30)
            {
                progressBar2.Value -= 30;
                progressBar3.Value = Math.Max(0, progressBar3.Value - 15);
                listBox1.Items.Add("Ви використали Супер Атаку (-30 MP) і нанесли 15 урону!");

                if (progressBar3.Value <= 0)
                {
                    MessageBox.Show("Ви перемогли!");
                    this.Close();
                }
                else
                {
                    EnemyTurn();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value <= 0 || progressBar3.Value <= 0) return;

            progressBar1.Value = Math.Min(100, progressBar1.Value + 20);
            listBox1.Items.Add("Ви полікувалися на +20 HP!");
            EnemyTurn();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value <= 0 || progressBar3.Value <= 0) return;

            progressBar2.Value = Math.Min(100, progressBar2.Value + 40);
            listBox1.Items.Add("Ви відпочили і відновили +40 MP!");
            EnemyTurn();
        }

        private void EnemyTurn()
        {
            Random rand = new Random();

            if (progressBar3.Value < 30)
            {
                int chance = rand.Next(1, 101);

                if (chance <= 40)
                {
                    progressBar3.Value = Math.Min(100, progressBar3.Value + 15);
                    listBox1.Items.Add("Монстр вирішив полікуватися на +15 HP!");
                }
                else
                {
                    int damage = rand.Next(1, 3) == 1 ? 8 : 18;
                    progressBar1.Value = Math.Max(0, progressBar1.Value - damage);

                    if (damage == 8)
                        listBox1.Items.Add("Монстр проігнорував хіл і наніс 8 урону!");
                    else
                        listBox1.Items.Add("Монстр проігнорував хіл і вліпив СУПЕР АТАКУ на 18 урону!");
                }
            }
            else
            {
                int damage = rand.Next(1, 3) == 1 ? 8 : 18;
                progressBar1.Value = Math.Max(0, progressBar1.Value - damage);

                if (damage == 8)
                    listBox1.Items.Add("Монстр атакував вас і наніс 8 урону!");
                else
                    listBox1.Items.Add("Монстр використав СУПЕР АТАКУ і вліпив 18 урону!");
            }

            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }

            if (progressBar1.Value <= 0)
            {
                MessageBox.Show("Ви програли!");
                isVictory = false;
                Form2 mainMenu = (Form2)Application.OpenForms["Form2"];
                if (mainMenu != null)
                {
                    mainMenu.clickCount = 0;
                    mainMenu.LoadCoins();

                    if (mainMenu.Controls["button4"] is Button btnClick)
                    {
                        btnClick.Enabled = true;
                    }
                    if (mainMenu.Controls["label3"] is Label lblCoins)
                    {
                        lblCoins.Text = mainMenu.Coins.ToString();
                    }
                    mainMenu.Show();
                }
                

                this.Close();
               



            }
        }

        private void BattleForm_Load(object sender, EventArgs e)
        {

        }
    }
}