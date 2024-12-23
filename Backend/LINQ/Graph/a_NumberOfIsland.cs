namespace LINQ._2D_DP
{
    public class a_NumberOfIsland
    {
        public a_NumberOfIsland()
        {
            char[][] grid = new char[][]
            {
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'1', '1', '0', '0', '0'},
            };
            Console.WriteLine(NumIslands(grid));
        }

        // Time Complexity: O(m x n) each cell visited once
        // Space Complexity: O(m x n) worst case due to recursion stack (in case the grid is one large island).
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            int numRows = grid.Length;
            int numCols = grid[0].Length;

            int islandCount = 0;

            for (int row = 0; row < numRows; row++) {
                for (int col = 0; col < numCols; col++)
                {
                    if (grid[row][col] == '1')
                    {
                        islandCount++;
                        MarkVisited(grid, row, col);
                    }
                }
            }
            return islandCount;

        }

        private void MarkVisited(char[][] grid, int row, int col)
        {
            if (row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length || grid[row][col] == '0')
                return;

            grid[row][col] = '0';

            MarkVisited(grid, row + 1, col); // Down
            MarkVisited(grid, row - 1, col); // Up
            MarkVisited(grid, row, col + 1); // Right
            MarkVisited(grid, row, col - 1); // Left

        }
    }
}
