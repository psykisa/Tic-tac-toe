using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        char[,] mas = new char[3, 3];
        public Form1()
        {
            InitializeComponent();
        }

        private void CheckMove(Game.Direction result, char c)
        {
            bool win = false;
            string msg = "";
            switch (result)
            {
                case Game.Direction.Row1:
                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView1[i, 0].Style.BackColor = Color.Red;
                    }
                    win = true;
                    break;
                case Game.Direction.Row2:
                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView1[i, 1].Style.BackColor = Color.Red;
                    }
                    win = true;
                    break;
                case Game.Direction.Row3:
                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView1[i, 2].Style.BackColor = Color.Red;
                    }
                    win = true;
                    break;
                case Game.Direction.Col1:
                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView1[0, i].Style.BackColor = Color.Red;
                    }
                    win = true;
                    break;
                case Game.Direction.Col2:
                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView1[1, i].Style.BackColor = Color.Red;
                    }
                    win = true;
                    break;
                case Game.Direction.Col3:
                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView1[2, i].Style.BackColor = Color.Red;
                    }
                    win = true;
                    break;
                case Game.Direction.D1:
                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView1[i, i].Style.BackColor = Color.Red;
                    }
                    win = true;
                    break;
                case Game.Direction.D2:
                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView1[2 - i, i].Style.BackColor = Color.Red;
                    }
                    win = true;
                    break;
                case Game.Direction.Drow:
                    win = true;
                    break;
            }

            if (win)
            {
                if (c == 'X')
                    msg = "Вы победили!!!";
                if (c == 'O')
                    msg = "Вы проиграли!!!";
                if (result == Game.Direction.Drow)
                    msg = "Ничья";

                if (MessageBox.Show("Хотите сыграть еще раз?", msg, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Game.NewGame();
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            dataGridView1[j, i].Value = "";
                            dataGridView1[j, i].Style.BackColor = Color.White;
                        }
                    }
                }
                else
                    Close();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 3;
            dataGridView1.ColumnCount = 3;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int x;
            int y;
            Game.Direction result;
            dataGridView1.ClearSelection();
            //x = dataGridView1.CurrentCellAddress.X;
            x = dataGridView1.CurrentCell.ColumnIndex;
            //y = dataGridView1.CurrentCellAddress.Y;
            y = dataGridView1.CurrentCell.RowIndex;

            result = Game.User(new Point(x, y));
            dataGridView1[x, y].Value = 'X';
            CheckMove(result, 'X');
            result = Game.Computer(out x, out y);
            dataGridView1[x, y].Value = 'O';
            CheckMove(result, 'O');

        }
    }
}
