﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Hashing
{
    public class h_Valid_Soduku
    {
        public h_Valid_Soduku()
        {
            char[][] validSudoku = new char[][]
            {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            Console.WriteLine("Valid Sudoku");
            Console.WriteLine(isValidSudoku(validSudoku));
        }
        

        public bool isValidSudoku(char[][] board)
        {
            Dictionary<int, HashSet<char>> cols = new Dictionary<int, HashSet<char>>();
            Dictionary<int, HashSet<char>> rows = new Dictionary<int, HashSet<char>>();
            Dictionary<(int, int), HashSet<char>> squares = new Dictionary<(int, int), HashSet<char>>();

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (board[r][c] == '.') 
                        continue;

                    if ( rows.ContainsKey(r) && rows[r].Contains(board[r][c]) || 
                         cols.ContainsKey(c) && cols[c].Contains(board[r][c]) ||
                         squares.ContainsKey((r /3, c / 3)) &&  squares[(r / 3, c / 3)].Contains(board[r][c]))
                        return false;

                    if(cols.ContainsKey(c))
                        cols[c].Add(board[r][c]);
                    else
                        cols[c] = new HashSet<char>();

                    if(rows.ContainsKey(r))
                        rows[r].Add(board[r][c]);
                    else
                        rows[r] = new HashSet<char>();

                    if(squares.ContainsKey((r / 3, c / 3)))
                        squares[(r / 3, c/ 3)].Add(board[r][c]);
                    else
                        squares[(r / 3, c / 3)] = new HashSet<char>();
                }
            }
            return true;
        }
    }

}