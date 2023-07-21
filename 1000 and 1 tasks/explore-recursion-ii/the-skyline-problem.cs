public class Solution {
    // TL
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        // идем по оси Х
        // список текущих зданий

        var start = buildings.First()[0];
        // неправильно ищу
        var end = buildings.Last()[1];
        
        var result = new List<IList<int>>();

        var currentIndexes = new List<int>();
        var currentHeight = 0;
        var currentTopIndex = -1;
        for (int x = start; x <= end; x++)
        {
            var whoStartedIndexes = new List<int>();
            var whoEndedIndexes = new List<int>();

            for (int i = 0; i < buildings.Length; i++)
            {
                var b = buildings[i];
                if (b[0] == x)
                {
                    whoStartedIndexes.Add(i);
                }

                if (b[1] == x)
                {
                    whoEndedIndexes.Add(i);
                }
            }
            
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
                result.Add(new List<int>() {b[0],b[2]});
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
                    result.Add(new List<int>() {x, currentHeight});
                }
            }
        }

        return result;
    }
}