public class Solution {

    // предположим, что контейнер всегда включает правую границу
    // граница одна, пусть идет в оевый всегда
    public int[] PlatesBetweenCandles(string s, int[][] queries) {
        var pointToContainerIndex = new List<int>[s.Length];

        var containerCount = 0;
        var buffer = 0;
        var containerSizes = new List<int>();
        for (int i = 0; i < s.Length; i++) {
            pointToContainerIndex[i] = new List<int>() {containerCount};
            if (s[i] == '|') {
                containerSizes.Add(buffer);
                containerCount++;
                pointToContainerIndex[i].Add(containerCount);
                buffer = 0;
            }
            else
            {
                buffer++;
            }
        }
        containerSizes.Add(buffer);


        var result = new List<int>();
        foreach (var query in queries)
        {
            var left = query[0];
            var right = query[1];

            if (s[left] == '*' && s[right] == '*')
            {
                var leftContainerIndex = pointToContainerIndex[left].First();
                var rightContainerIndex = pointToContainerIndex[right].First();
                
                // todo optimize with range queries
                var i = leftContainerIndex + 1;
                var sumRes = 0;
                while (i < rightContainerIndex)
                {
                    sumRes += containerSizes[i];
                    i++;
                }
                result.Add(sumRes);
            }
            else if (s[left] == '*' && s[right] == '|')
            {
                var leftContainerIndex = pointToContainerIndex[left].First();
                var rightContainerIndex = pointToContainerIndex[right].First();
                
                // todo optimize with range queries
                var i = leftContainerIndex + 1;
                var sumRes = 0;
                while (i <= rightContainerIndex)
                {
                    sumRes += containerSizes[i];
                    i++;
                }
                result.Add(sumRes);
            }
            else if (s[left] == '|' && s[right] == '*')
            {
                var leftContainerIndex = pointToContainerIndex[left].First();
                var rightContainerIndex = pointToContainerIndex[right].First();
                
                // todo optimize with range queries
                var i = leftContainerIndex + 1;
                var sumRes = 0;
                while (i < rightContainerIndex)
                {
                    sumRes += containerSizes[i];
                    i++;
                }
                result.Add(sumRes);
            }
            else if (s[left] == '|' && s[right] == '|')
            {
                var leftContainerIndex = pointToContainerIndex[left].First();
                var rightContainerIndex = pointToContainerIndex[right].First();
                
                // todo optimize with range queries
                var i = leftContainerIndex + 1;
                var sumRes = 0;
                while (i <= rightContainerIndex)
                {
                    sumRes += containerSizes[i];
                    i++;
                }
                result.Add(sumRes);
            }
        }
        
        return result.ToArray();
    }
}