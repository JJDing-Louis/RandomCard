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
        public Form1()
        {
            InitializeComponent();
        }

        //string player1, player2, player3, player4;
        int[] card = new int[52];
        object[] reShuffleCard = new object[52];
        int numPlayer; //玩家人數
        int getCardNumber; //分到的牌數
        string txtMessage = ""; //顯示訊息
        //string value = "";

        private void btnResult_Click(object sender, EventArgs e)
        {
            numPlayer = Int32.Parse(txtPlayer.Text);
            if (numPlayer <= 52) { 
            getCard();
            reShuffleCard = Reshuffle(card);
            getCardNumber =card.Length / numPlayer;
            
            for (int i = 0; i < numPlayer; i++)
            {
                if (card.Length - getCardNumber * i > getCardNumber)
                {
                    txtMessage += "玩家" + (i + 1) + ":";
                    for (int j = (0 + i) * getCardNumber; j < (1 + i) * getCardNumber; j++)
                    {
                        txtMessage += reShuffleCard[j] + ",";

                    }
                    txtMessage += "\n";
                }
            }
            
            if (card.Length % numPlayer != 0)
            {
                txtMessage += "剩下牌數" + card.Length % numPlayer + "\n";
                for (int h = numPlayer * getCardNumber; h < 52; h++)
                {
                    txtMessage += reShuffleCard[h] + ",";
                }
            }
            MessageBox.Show(txtMessage);
            txtMessage = ""; //訊息初始化
            }
            else { MessageBox.Show("玩家太多，且牌不夠!!!"); }

            /*顯示牌的內容
            for (int i=0; i< reShuffleCard.Length; i++)
            {
                value += reShuffleCard[i] + ",";
            }*/

            /*for (int i =0; i<52; i++)
            {
                if (i < 13)
                {
                    player1 += reShuffleCard[i] + ",";
                }else if (i < 26)
                {
                    player2 += reShuffleCard[i] + ",";
                }
                else if (i < 39)
                {
                    player3 += reShuffleCard[i] + ",";
                }
                else if (i < 52)
                {
                    player4 += reShuffleCard[i] + ",";
                }
            }*/


            /*MessageBox.Show("玩家1的卡:"+player1+"\n玩家2的卡:"+ player2 + 
                "\n玩家3的卡:" + player3 + "\n玩家4的卡:" + player4);*/
            Array.Clear(card, 0, card.Length);//卡片清除
                                              //value = "";
                /*player1 = "";
                player2 = "";
                player3 = "";
                player4 = "";*/
            
        }

        //產生52張牌
        public void getCard()
        {
            for (int i = 0; i < card.Length; i++)
            {
                card[i] = i + 1;
            }
        }

        public object[] Reshuffle(int[] a)
        {
            object[] temp = new object[52];
            Random rnd = new Random();
            ArrayList list = new ArrayList();

            for (int j=0; j<52; j++)
            {
                list.Add(card[j]);
            }
            //隨機存入資料
            for(int i=52; i>0; i--)
            {
                int c = rnd.Next(0, i);
                temp[i - 1] = list[c];
                list.Remove(list[c]);
            }

            return temp;
        }
    }
}
