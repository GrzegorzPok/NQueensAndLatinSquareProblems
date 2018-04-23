using System;
using System.Collections.Generic;
using System.Text;

namespace NQueens
{
    public class Board
    {
        private bool[] diagonalR;
        private bool[] diagonalL;
        private bool[] col;
        private int size;
        public int found = 0;
        public int returns = 0;

        public Board(int size)
        {
            diagonalR = new bool[256];
            diagonalL = new bool[256];
            col = new bool[size];
            this.size = size;
        }

        public void AddQueen_backtracking(int row)
        {
            for (int i = 0; i < size; i++)
            {
                if (!((col[i]) || (diagonalR[i - row + 128]) || (diagonalL[row + i + 128])))
                {
                    diagonalR[i - row + 128] = true;
                    diagonalL[row + i + 128] = true;
                    col[i] = true;
                    if (row < size-1)
                    {
                        AddQueen_backtracking(row + 1);
                    }
                    else
                    {
                        found++;
                    }
                    diagonalR[i - row + 128] = false;
                    diagonalL[row + i + 128] = false;
                    col[i] = false;
                    returns++;
                }
            }
        }

        public void AddQueen_forwardChecking(int row)
        {
            for (int i = 0; i < size; i++)
            {
                if (!((col[i]) || (diagonalR[i - row + 128]) || (diagonalL[row + i + 128])))
                {
                    diagonalR[i - row + 128] = true;
                    diagonalL[row + i + 128] = true;
                    col[i] = true;
                    if (row == size-1 || ForwardChecking(row + 1))
                    {
                        if (row < size - 1)
                        {
                            AddQueen_forwardChecking(row + 1);
                        }
                        else
                        {
                            found++;
                        }
                    }
                    diagonalR[i - row + 128] = false;
                    diagonalL[row + i + 128] = false;
                    col[i] = false;
                    returns++;
                }
            }
        }

        public bool ForwardChecking(int row)
        {
            for (int i = 0; i < size; i++)
            {
                if (!(col[i]) && !(diagonalR[i - row + 128]) && !(diagonalL[row + i + 128]))
                {
                    if (row < size - 1)
                    {
                        return ForwardChecking(row + 1);
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /*public bool ForwardChecking(int row)
        {
            for (int i = 0; i < size; i++)
            {
                if (!(col[i]) && !(diagonalR[i - row + 128]) && !(diagonalL[row + i + 128]))
                {
                    return true;
                }
            }
            return false;
        }*/
    }
}
