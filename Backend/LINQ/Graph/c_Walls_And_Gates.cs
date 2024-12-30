using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Graph
{
    public class c_Walls_And_Gates
    {
        public c_Walls_And_Gates()
        {
            int[][] rooms = new int[][]
            {
                new int[] { int.MaxValue, -1, 0, int.MaxValue },
                new int[] { int.MaxValue, int.MaxValue, int.MaxValue, -1 },
                new int[] { int.MaxValue, -1, int.MaxValue, -1 },
                new int[] { 0, -1, int.MaxValue, int.MaxValue }
            };

            var result = wallsAndDates1(rooms);

            // Print the updated grid
            foreach (var row in result)
            {
                Console.WriteLine(string.Join(", ", row));
            }
        }

        public int[][] wallsAndDates1(int[][] rooms)
        {
            int ROWS = rooms.Length;
            int COLS = rooms[0].Length;
            Queue<(int, int)> q = new Queue<(int, int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            void bfs(int x, int y)
            {
                if(x < 0 || y < 0 || x >= ROWS || y >= COLS || visited.Contains((x, y)) 
                    || rooms[x][y] == 0 || rooms[x][y] == -1)  
                    return;
                visited.Add((x, y) );
                q.Enqueue((x, y));
            }

            for (int x = 0; x < ROWS; x++)
            {
                for (int y = 0; y < COLS; y++)
                {
                    if (rooms[x][y] == 0)
                        q.Enqueue((x, y));
;                }
            }

            int distance = 0;
            while(q.Count > 0)
            {
                int qLength = q.Count;
                for(int i = 0; i < qLength; i++)
                {
                    (int x, int y) = q.Dequeue();
                    rooms[x][y] = distance;
                    bfs(x + 1, y);
                    bfs(x - 1, y);
                    bfs(x, y + 1);
                    bfs(x, y - 1);
                }
                distance++;
            }
            return rooms;
        }

        public int[][] wallsAndGates(int[][] rooms)
        {


            int rows = rooms.Length;
            int cols = rooms[0].Length;
            HashSet<(int, int)> visited = new HashSet<(int, int)> ();
            Queue<(int, int)> queue = new Queue<(int, int)> ();


            void addRoom(int r, int c)
            {
                if (r < 0 || r == rows || c < 0 || c == cols || visited.Contains((r, c)) || rooms[r][c] == -1)
                    return;
                visited.Add((r, c));
                queue.Enqueue((r, c));
            }

            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    if (rooms[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                        visited.Add((i, j));
                    }
                }    
            }

            int dist = 0;
            while(queue.Count > 0)
            {
                int queueCount = queue.Count;
                for(int i = 0; i < queueCount; i++)
                {
                    (int r, int c) = queue.Dequeue();
                    rooms[r][c] = dist;
                    addRoom(r + 1, c);
                    addRoom(r - 1, c);
                    addRoom(r, c + 1);
                    addRoom(r, c - 1);
                }
                dist++;
            }

            return rooms;
        }
    }
}
