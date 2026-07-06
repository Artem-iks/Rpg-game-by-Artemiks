using System;
using System.IO;
using System.Windows.Forms;

namespace Rpg_game_by_Artemiks
{
    public partial class Form2 : Form
    {
        public int Coins = 0;

        public void SaveCoins()
        {
            System.IO.File.WriteAllText("coins.txt", Coins.ToString());
        }

        public void LoadCoins()
        {
            if (System.IO.File.Exists("coins.txt"))
            {
                if (int.TryParse(System.IO.File.ReadAllText("coins.txt"), out int savedCoins))
                {
                    Coins = savedCoins;
                }
            }
            else
            {
                Coins = 0;
            }
        }

        private string playerName;



        public Form2(string name)
        {
            InitializeComponent();
            label2.Text = name;
            playerName = name;
            LoadCoins();
            label3.Text = Coins.ToString();
        }
            public int clickCount = 0;

        

        private void button1_Click(object sender, EventArgs e)
        {
            int maxUnlockedLevel = 1;
            string savePath = "save.txt";

            try
            {
                if (File.Exists(savePath))
                {
                    int.TryParse(File.ReadAllText(savePath), out maxUnlockedLevel);
                }
            }
            catch { }

            Form lvlForm = new Form
            {
                Text = "Вибір Рівня",
                Size = new System.Drawing.Size(240, 420),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            for (int i = 1; i <= 10; i++)
            {
                int currentLvl = i;
                Button btn = new Button
                {
                    Text = "Рівень " + i,
                    Size = new System.Drawing.Size(180, 30),
                    Location = new System.Drawing.Point(20, 15 + (i - 1) * 35),
                    Enabled = i <= maxUnlockedLevel
                };

                btn.Click += (s, levelArgs) =>
                {
                    lvlForm.Close();

                    BattleForm battle = new BattleForm();
                    battle.ShowDialog();

                    if (currentLvl == maxUnlockedLevel && maxUnlockedLevel < 10)
                    {
                        maxUnlockedLevel++;
                        try
                        {
                            File.WriteAllText(savePath, maxUnlockedLevel.ToString());
                        }
                        catch { }
                        MessageBox.Show("Відкрито рівень " + maxUnlockedLevel + "!");
                    }
                };

                lvlForm.Controls.Add(btn);
            }

            lvlForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShopForm shop = new ShopForm();
            shop.ShowDialog();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (clickCount >= 10)
            {
                MessageBox.Show("Помилка! Треба зіграти бій!", "Помилка");
                return;
            }

            Coins += 1;
            label3.Text = Coins.ToString();
            SaveCoins();

            clickCount++;
            if (clickCount >= 10)
            {
                button4.Enabled = false;
                button4.Text = "Немає багу, єноте!! іди в бій";
            }
        }

    }
}
