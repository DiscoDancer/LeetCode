public class Solution {
public IList<IList<int>> GetSkyline(int[][] buildings)
    {
        var result = new List<IList<int>>();
        
        var whoStartedTable = new Dictionary<int, List<int>>();

        var list = new List<int>();
        for (int i = 0; i < buildings.Length; i++)
        {
            var b = buildings[i];
            list.Add(b[1]);
            list.Add(b[0]);
            if (!whoStartedTable.ContainsKey(b[0]))
            {
                whoStartedTable[b[0]] = new List<int>();
            }
            whoStartedTable[b[0]].Add(i);
        }
        
        // index -> height
        var pq = new PriorityQueue<int, int>();
        var arr = list.Distinct().OrderBy(x => x).ToArray();
        foreach (var x in arr)
        {
            var whoStartedIndexes = whoStartedTable.ContainsKey(x) ? whoStartedTable[x] : new List<int>();

            foreach (var i in whoStartedIndexes)
            {
                pq.Enqueue(i, -buildings[i][2]);
            }
            
            while (pq.Count > 0 && buildings[pq.Peek()][1] <= x)
            {
                pq.Dequeue();
            }
            
            var currentHeight = pq.Count > 0 ? buildings[pq.Peek()][2] : 0;

            if (!result.Any() || currentHeight > result.Last()[1])
            {
                var b = buildings[pq.Peek()];
                result.Add(new List<int>() { b[0], b[2] });
            }
            else if (result.Any() && currentHeight < result.Last()[1])
            {
                if (currentHeight == 0)
                {
                    result.Add(new List<int>() { x, 0 });
                }
                else
                {
                    result.Add(new List<int>() { x, currentHeight });
                }
            }
        }

        return result;
    }
}