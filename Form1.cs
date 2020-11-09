using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomCard
{
    public partial class Form1 : Form
    {
        public int cardNumber = 52;//宣告牌數 

        public Form1()
        {
            InitializeComponent();
            //以下這一段是dataGridView
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "玩家";
            dataGridView1.Columns[1].Name = "手牌";
        }


        private void btnResult_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0) { dataGridView1.Rows.Clear(); } //DataGridView內容重置(判斷有無內容)
            int numPlayer = Int32.Parse(txtPlayer.Text);//取得玩家數量
            List<int> card = new List<int>();//宣告手牌空間
            if (numPlayer <= 52) {
                card = getCard();
                card = Reshuffle(card);
                int getCardNumber = card.Count / numPlayer;
                for (int i = 0; i < numPlayer; i++)
                {
                    if (card.Count - getCardNumber * i >= getCardNumber)
                    {
                        string[] row = new string[2]; //DataGridView 訊息結構   
                        row[0] = $"玩家{(i + 1)}";
                        for (int j = (0 + i) * getCardNumber; j < (1 + i) * getCardNumber; j++)
                        {
                            row[1] += $"{card[j]},";
                        }
                        row[1] += $" 共{getCardNumber}張";
                        dataGridView1.Rows.Add(row);
                    }                   
                }
                //此區寫剩下的牌數
                richTextBox1.Clear();
                if (card.Count % numPlayer != 0)
                {
                    string txtMessage = ""; //顯示訊息
                    txtMessage += $"剩下牌數{card.Count % numPlayer}\n";
                    for (int h = numPlayer * getCardNumber; h < 52; h++)
                    {
                        txtMessage += $"{card[h]},";
                    }
                    richTextBox1.AppendText(txtMessage);
                }
            }
            else { MessageBox.Show("玩家太多，且牌不夠!!!"); }

         }

        //產生52張牌
        public List<int> getCard()
        {
            List<int> card = new List<int>();
            for (int i = 1; i <= cardNumber; i++)
            {
                card.Add(i);
            }
            return card;
        }
        
        //以下為洗牌動作
        public List<int> Reshuffle(List<int> card)
        {
            Random rnd = new Random();//亂數
            List<int> temp = new List<int>();//建立暫存空間
            for (int i = 52; i > 0; i--)
            {               
                int c = rnd.Next(0, i);
                temp.Add(card[c]);
                card.Remove(card[c]);
            }
            return temp;
        }
    }
}
