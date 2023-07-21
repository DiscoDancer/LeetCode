public class Solution {
    public IList<IList<int>> GetSkyline(int[][] buildings)
    {
        // идем по оси Х
        // список текущих зданий


        var result = new List<IList<int>>();

        var currentIndexes = new List<int>();
        var currentHeight = 0;
        var currentTopIndex = -1;

        var whoStartedTable = new Dictionary<int, List<int>>();
        var whoEndedTable = new Dictionary<int, List<int>>();

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
            if (!whoEndedTable.ContainsKey(b[1]))
            {
                whoEndedTable[b[1]] = new List<int>();
            }
            
            whoStartedTable[b[0]].Add(i);
            whoEndedTable[b[1]].Add(i);
        }
        
        var arr = list.Distinct().OrderBy(x => x).ToArray();
        foreach (var x in arr)
        {
            var whoStartedIndexes = whoStartedTable.ContainsKey(x) ? whoStartedTable[x] : new List<int>();
            var whoEndedIndexes = whoEndedTable.ContainsKey(x) ? whoEndedTable[x] : new List<int>();

            var isHeightIncreased = false;
            // optimize with while
            foreach (var i in whoStartedIndexes)
            {
                currentIndexes.Add(i);
                if (buildings[i][2] > currentHeight)
                {
                    currentHeight = buildings[i][2];
                    currentTopIndex = i;
                    isHeightIncreased = true;
                }
            }

            var isTopEnded = false;
            foreach (var i in whoEndedIndexes)
            {
                currentIndexes.Remove(i);
                if (i == currentTopIndex)
                {
                    isTopEnded = true;
                }
            }

            if (isHeightIncreased)
            {
                var b = buildings[currentTopIndex];
                result.Add(new List<int>() { b[0], b[2] });
            }
            else if (isTopEnded)
            {
                var prevHeight = currentHeight;
                currentHeight = 0;
                currentTopIndex = -1;
                foreach (var i in currentIndexes)
                {
                    if (buildings[i][2] > currentHeight)
                    {
                        currentHeight = buildings[i][2];
                        currentTopIndex = i;
                    }
                }

                if (prevHeight != currentHeight)
                {
                    result.Add(new List<int>() { x, currentHeight });
                }
            }
        }

        return result;
    }
}