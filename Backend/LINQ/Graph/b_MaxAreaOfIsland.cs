using LINQ.Hashing;

namespace LINQ.Graph
{
    public class b_MaxAreaOfIsland
    {
        public b_MaxAreaOfIsland()
        {
            char[][] grid = new char[][]
            {
                new char[] {'0', '1', '1', '0', '1'},
                new char[] {'1', '0', '1', '0', '1'},
                new char[] {'0', '1', '1', '0', '1'},
                new char[] {'0', '1', '0', '0', '1'},
            };

            Console.WriteLine("MaxAreaOfIsland");
            Console.WriteLine(MaxAreaOfIsland1(grid));
        }

        public int MaxAreaOfIsland1(char[][] grid)
        {
            int row = grid.Length;
            int col = grid[0].Length;
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            int maxArea = 0;

            int dfs(int x, int y)
            {
                if (x < 0 || y < 0 || x >= row || y >= col || visited.Contains((x, y)) ||
                    grid[x][y] == '0')
                {
                    return 0;
                }

                visited.Add((x, y));
                return 1 + dfs(x + 1, y) + dfs(x - 1, y) + dfs(x, y + 1) + dfs(x, y - 1);
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == '1' && !visited.Contains((i, j)))
                    {
                        maxArea = int.Max(dfs(i, j), maxArea);
                    }
                }
            }
            return maxArea;
        }

        public int MaxAreaOfIsland(int[][] grid)
        {
            int area = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            int Dfs(int r, int c)
            {
                if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r][c] == 0 || visited.Contains((r, c)))
                    return 0;

                visited.Add((r, c));
                return 1 + Dfs(r + 1, c) + Dfs(r - 1, c) + Dfs(r, c + 1) + Dfs(r, c - 1);
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for(int j = 0;  j < grid[0].Length; j++)
                {
                    area = int.Max(area, Dfs(i, j));
                }
            }
            return area;
        }
    }
}
