using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class Game
    {
        public enum Direction { Row1, Row2, Row3, Col1, Col2, Col3, D1, D2, Error, None ,Drow }
        public static char[,] mas = new char[3, 3];

        public static void NewGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mas[i, j] = '\0';
                }
            }
        }
        public static Direction Chek(char c)
        {
            bool emptyCell = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mas[i, j] =='\0')
                    {
                        emptyCell = true;
                    }
                }
            }
            if (!emptyCell)
                return Direction.Drow;

            for (int i = 0; i < 3; i++)
            {
                if (mas[i, 0] == c && mas[i, 1] == c && mas[i, 2] == c)
                    return Direction.Col1+i;
            }
            for (int i = 0; i < 3; i++)
            {
                if (mas[0, i] == c && mas[1, i] == c && mas[2, i] == c)
                    return Direction.Row1+i;

            }
            if (mas[0, 0] == c && mas[1, 1] == c && mas[2, 2] == c)
                return Direction.D1;
            if (mas[0, 2] == c && mas[1, 1] == c && mas[2, 0] == c)
                return Direction.D2;
            return Direction.None;
        }
        public static Direction User(Point point)
        {
            if (mas[point.X, point.Y] == '\0')
                mas[point.X, point.Y] = 'X';
            return Chek('X');
        }
        public static Direction Computer(out int x,out int y)
        {
            Point temp = Comp.MakeMove();
            mas[temp.X, temp.Y] = 'O';
            x = temp.X;
            y = temp.Y;
            return Chek('O');
        }
        public static bool IsEmpty(int x,int y)
        {
            return mas[x, y] == 0;
        }

    }
}
