using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    public partial class Form1 : Form
    {
        private Form board;
        private Button[] fields = new Button[9];
        private string sign = "";
        private string player = "";
        private Label playerWhich;
        private Label gameProgress;

        public Form1()
        {
            InitializeComponent();
        }

        private void disableFields()
        {
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i].Enabled = false;
            }
        }

        private void win(string signCopy, string playerCopy)
        {
            bool winner = false;
            if ((fields[1].Text == fields[0].Text && fields[2].Text == fields[1].Text && fields[1].Text != "")
                || (fields[4].Text == fields[3].Text && fields[5].Text == fields[4].Text && fields[3].Text != "")
                || (fields[7].Text == fields[6].Text && fields[8].Text == fields[7].Text && fields[6].Text != ""))
            {
                gameProgress.Text += "\n\nAnd the winner is: " + playerCopy + " who wins putting " + signCopy + " in a row";
                winner = true;
            }
            else if ((fields[3].Text == fields[0].Text && fields[6].Text == fields[3].Text && fields[3].Text != "")
                || (fields[4].Text == fields[1].Text && fields[7].Text == fields[4].Text && fields[4].Text != "")
                || (fields[5].Text == fields[2].Text && fields[8].Text == fields[5].Text && fields[2].Text != ""))
            {
                gameProgress.Text += "\n\nAnd the winner is: " + playerCopy + " who wins putting " + signCopy + " in a column";
                winner = true;
            }
            else if ((fields[4].Text == fields[0].Text && fields[8].Text == fields[4].Text && fields[4].Text != "")
                || (fields[2].Text == fields[4].Text && fields[6].Text == fields[4].Text && fields[2].Text != ""))
            {
                gameProgress.Text += "\n\nAnd the winner is: " + playerCopy + " who wins putting " + signCopy + " diagonally";
                winner = true;
            }
            if (winner) {
                disableFields();
                playerWhich.Text = "GAME OVER";
                player = "";
            }
            else
            {
                bool draw = true;
                for (int i = 0; i < fields.Length; i++)
                {
                    if (fields[i].Text == "")
                    {
                        draw = false;
                        break;
                    }
                }
                if (draw)
                {
                    disableFields();
                    gameProgress.Text += "\n\nDraw!";
                    playerWhich.Text = "GAME OVER";
                    player = "";
                }
                else
                {
                    playerWhich.Text = "Turn: " + player + " - " + sign;
                    if (player == "Computer" || player == "Player")
                    {
                        insertSignPCPlayer();
                    }
                }
            }
        }

        private void insertSign(Button button, string player1, string player2)
        {
            string signCopy = sign, playerCopy = player;
            if (button.Text == "")
            {
                gameProgress.Text += "\n" + player + " placed: " + signCopy;
                if (player == player1) player = player2;
                else player = player1;
            }
            if (sign == "O" && button.Text == "")
            {
                sign = "X";
                button.Text = "O";
            }
            else if (sign == "X" && button.Text == "")
            {
                sign = "O";
                button.Text = "X";
            }
            if (player != "") win(signCopy, playerCopy);
        }

        private void insertSign2Players(Object sender, EventArgs e, string player1, string player2)
        {
            Button button = (Button)sender;
            insertSign(button, player1, player2);
        }

        private int closeToWin(string SIGN)
        {
            if (fields[0].Text == fields[1].Text && fields[0].Text == SIGN && fields[2].Text == "") return 2;
            if (fields[0].Text == fields[2].Text && fields[0].Text == SIGN && fields[1].Text == "") return 1;
            if (fields[1].Text == fields[2].Text && fields[1].Text == SIGN && fields[0].Text == "") return 0;
            if (fields[3].Text == fields[4].Text && fields[3].Text == SIGN && fields[5].Text == "") return 5;
            if (fields[3].Text == fields[5].Text && fields[3].Text == SIGN && fields[4].Text == "") return 4;
            if (fields[4].Text == fields[5].Text && fields[4].Text == SIGN && fields[3].Text == "") return 3;
            if (fields[6].Text == fields[7].Text && fields[6].Text == SIGN && fields[8].Text == "") return 8;
            if (fields[6].Text == fields[8].Text && fields[6].Text == SIGN && fields[7].Text == "") return 7;
            if (fields[7].Text == fields[8].Text && fields[7].Text == SIGN && fields[6].Text == "") return 6;
            if (fields[0].Text == fields[3].Text && fields[0].Text == SIGN && fields[6].Text == "") return 6;
            if (fields[0].Text == fields[6].Text && fields[0].Text == SIGN && fields[3].Text == "") return 3;
            if (fields[3].Text == fields[6].Text && fields[3].Text == SIGN && fields[0].Text == "") return 0;
            if (fields[1].Text == fields[4].Text && fields[1].Text == SIGN && fields[7].Text == "") return 7;
            if (fields[1].Text == fields[7].Text && fields[1].Text == SIGN && fields[4].Text == "") return 4;
            if (fields[4].Text == fields[7].Text && fields[4].Text == SIGN && fields[1].Text == "") return 1;
            if (fields[2].Text == fields[5].Text && fields[2].Text == SIGN && fields[8].Text == "") return 8;
            if (fields[2].Text == fields[8].Text && fields[2].Text == SIGN && fields[5].Text == "") return 5;
            if (fields[5].Text == fields[8].Text && fields[5].Text == SIGN && fields[2].Text == "") return 2;
            if (fields[0].Text == fields[4].Text && fields[0].Text == SIGN && fields[8].Text == "") return 8;
            if (fields[0].Text == fields[8].Text && fields[0].Text == SIGN && fields[4].Text == "") return 4;
            if (fields[4].Text == fields[8].Text && fields[4].Text == SIGN && fields[0].Text == "") return 0;
            if (fields[2].Text == fields[4].Text && fields[2].Text == SIGN && fields[6].Text == "") return 6;
            if (fields[2].Text == fields[6].Text && fields[2].Text == SIGN && fields[4].Text == "") return 4;
            if (fields[4].Text == fields[6].Text && fields[4].Text == SIGN && fields[2].Text == "") return 2;
            return -1;
        }

        private void PCMove(string playerSign)
        {
            if (closeToWin(sign) != -1) insertSign(fields[closeToWin(sign)], "Player", "Computer");
            else if (closeToWin(playerSign) != -1) insertSign(fields[closeToWin(playerSign)], "Player", "Computer");
            else
            {
                bool inserted = false;
                do
                {
                    int random = new Random().Next(0, 9);
                    if (fields[random].Text == "")
                    {
                        insertSign(fields[random], "Player", "Computer");
                        inserted = true;
                    }
                } while (!inserted);
            }
        }

        private void insertSignPCPlayer()
        {
            if (player == "Player")
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    fields[i].Click += new EventHandler((sender, e) => insertSign2Players(sender, e, "Player", "Computer"));
                }
            }
            else if (player == "Computer")
            {
                string playerSign = "";
                if (sign == "X") playerSign = "O";
                else playerSign = "X";
                PCMove(playerSign);
            }
        }

        private void initializeGame()
        {
            if (new Random().Next(0, 2) == 0) sign = "O";
            else sign = "X";
            board = new Form();
            board.Size = new Size(1000, 680);
            int marginTop = 1, marginLeft = 1;
            for (int i = 0; i < 9; i++)
            {
                Button button = new Button();
                button.Size = new Size(80, 80);
                if (i % 3 == 0)
                {
                    marginTop++;
                    marginLeft = 1;
                }
                button.Top = marginTop * 80 - 80;
                button.Left = marginLeft * 80;
                button.Cursor = Cursors.Hand;
                button.Font = new Font("Arial", 36.0f);
                board.Controls.Add(button);
                fields[i] = button;
                marginLeft++;
            }
            playerWhich = new Label();
            playerWhich.Top = 80;
            playerWhich.Left = 400;
            playerWhich.Font = new Font("Arial", 12.0f);
            playerWhich.Height = 50;
            playerWhich.Width = 400;
            board.Controls.Add(playerWhich);
            gameProgress = new Label();
            gameProgress.Top = 130;
            gameProgress.Left = 400;
            gameProgress.Font = new Font("Arial", 12.0f);
            gameProgress.Height = 400;
            gameProgress.Width = 400;
            gameProgress.Text = "Progress: ";
            board.Controls.Add(gameProgress);
            board.Show();
        }

        private void gameMode(string player1, string player2)
        {
            if (new Random().Next(0, 2) == 0) player = player1;
            else player = player2;
            playerWhich.Text += "Turn: " + player + " - " + sign;
        }

        private void PLAYERS_Click(object sender, EventArgs e)
        {
            initializeGame();
            gameMode("Player 1", "Player 2");
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i].Click += new EventHandler((sender2, e2) => insertSign2Players(sender2, e2, "Player 1", "Player 2"));
            }
        }

        private void PC_Click(object sender, EventArgs e)
        {
            initializeGame();
            gameMode("Player", "Computer");
            insertSignPCPlayer();
        }
    }
}
