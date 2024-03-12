public class Solution {

    // предположим, что контейнер всегда включает правую границу
    // граница одна, пусть идет в оевый всегда
    public int[] PlatesBetweenCandles(string s, int[][] queries) {
        var pointToContainerIndex = new List<int>[s.Length];

        var containerCount = 0;
        var buffer = 0;
        var sum = 0;
        var containerSizes = new List<int>();
        var containerSums = new List<int>();
        for (int i = 0; i < s.Length; i++) {
            pointToContainerIndex[i] = new List<int>() {containerCount};
            if (s[i] == '|') {
                containerSizes.Add(buffer);
                containerSums.Add(sum);
                containerCount++;
                pointToContainerIndex[i].Add(containerCount);
                buffer = 0;
            }
            else
            {
                buffer++;
                sum++;
            }
        }
        containerSizes.Add(buffer);
        containerSums.Add(sum);


        var result = new List<int>();
        foreach (var query in queries)
        {
            var left = query[0];
            var right = query[1];
            
            var leftContainerIndex = pointToContainerIndex[left].First();
            var rightContainerIndex = pointToContainerIndex[right].First();
                
            // todo optimize with range queries
            var i = leftContainerIndex + 1;
            var sumRes = 0;

            if (s[left] == '*' && s[right] == '*' || s[left] == '|' && s[right] == '*')
            {
                while (i < rightContainerIndex)
                {
                    sumRes += containerSizes[i];
                    i++;
                }
            }
            else if (s[left] == '*' && s[right] == '|' || s[left] == '|' && s[right] == '|')
            {
                sumRes += containerSums[rightContainerIndex] - containerSums[leftContainerIndex];
                /*
                    while (i <= rightContainerIndex)
                    {
                        sumRes += containerSizes[i];
                        i++;
                    }
                */
            }
            
            result.Add(sumRes);
        }
        
        return result.ToArray();
    }
}