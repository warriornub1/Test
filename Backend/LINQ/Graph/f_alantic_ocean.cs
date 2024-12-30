using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Graph
{
    public class f_alantic_ocean
    {
        public f_alantic_ocean()
        {
            
        }

        //public List<List<int>> pacificAtlantic(int[][] heights)
        //{
        //    int ROWS = heights.Length;
        //    int COLS = heights[0].Length;

        //    HashSet<(int, int)> pac = new HashSet<(int, int)> ();
        //    HashSet<(int, int)> alt = new HashSet<(int, int)> ();

        //    void dfs(int x, int y, HashSet<(int, int)> visit, int prevHeight)
        //    {
        //        if(visit.Contains((x, y)) || x < 0 || y < 0 ||
        //            x >= ROWS || y >= COLS || heights[x][y] < prevHeight)
        //            return;

        //        visit.Add((x, y));
        //        dfs(x + 1, y, visit, heights[x][y]);
        //        dfs(x - 1, y, visit, heights[x][y]);
        //        dfs(x, y + 1, visit, heights[x][y]);
        //        dfs(x, y - 1, visit, heights[x][y]);
        //    }

        //    for (int c = 0; c < COLS; c++)
        //    {
        //        dfs(0, c, pac, heights[0][c]);
        //        dfs(ROWS - 1, c, alt, heights[ROWS - 1][c]);
        //    }

        //    for (int r = 0; r < ROWS; r++)
        //    {
        //        dfs(r, 0, pac, heights[r][0]);
        //        dfs(r, COLS - 1, alt, heights[r][COLS - 1]);
        //    }

        //    var res = new List<IList<int>>();
        //    for(int r = 0; r < ROWS; r++)
        //    {
        //        for(int c = 0; c < COLS; c++)
        //        {
        //            if(pac.Contains((r, c)) && alt.Contains((r, c)))
        //                res.Add(new List<int> { r, c });
        //        }
        //    }
        //}
    }
}
