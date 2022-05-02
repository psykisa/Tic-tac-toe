using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
   public static class Comp
    {
        static Random rnd = new Random();

        public static Point MakeMove()
        {
            int x=0;
            int y=0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(Game.IsEmpty(i,j))
                    {
                        if (CheckRow('O', i))
                            return new Point(i, j);
                        if (CheckCol('O', j))
                            return new Point(i, j);
                        if (CheckD1('O'))
                            return new Point(i, j);
                        if (CheckD2('O'))
                            return new Point(i, j);

                        if (CheckRow('X', i))
                            return new Point(i, j);
                        if (CheckCol('X', j))
                            return new Point(i, j);
                        if ((i == 0 && j == 0) || (i == 2 && j == 2) || (i == 1 && j == 1))
                        {
                            if (CheckD1('X'))
                                return new Point(i, j);
                        }
                        if ((i == 0 && j == 2) || (i == 2 && j == 0) || (i == 1 && j == 1))
                        {
                            if (CheckD2('X'))
                                return new Point(i, j);
                        }
                        
                        do
                        {
                            x = rnd.Next(0, 3);
                            y = rnd.Next(0, 3);
                        } while (!Game.IsEmpty(x, y));
                    }
                }
            }
            return new Point(x,y);
        }

        private static bool CheckRow(char c,int row)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                if (Game.mas[row, i] == c)
                    count++;
            }
            return count==2;
        }
        private static bool CheckCol(char c, int col)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                if (Game.mas[i, col] == c)
                    count++;
            }
            return count == 2;
        }

        private static bool CheckD1(char c)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                if (Game.mas[i, i] == c)
                    count++;
            }
            return count == 2;
        }
        private static bool CheckD2(char c)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                if (Game.mas[i, 2-i] == c)
                    count++;
            }
            return count == 2;
        }
    }
}
