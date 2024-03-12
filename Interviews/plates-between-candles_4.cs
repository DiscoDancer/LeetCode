public class Solution {

    // предположим, что контейнер всегда включает правую границу
    // граница одна, пусть идет в оевый всегда
    public int[] PlatesBetweenCandles(string s, int[][] queries) {
        var pointToContainerIndex = new int[s.Length];

        var containerCount = 0;
        var sum = 0;
        var containerSums = new List<int>();
        for (int i = 0; i < s.Length; i++) {
            pointToContainerIndex[i] = containerCount;
            if (s[i] == '|') {
                containerSums.Add(sum);
                containerCount++;
            }
            else
            {
                sum++;
            }
        }
        containerSums.Add(sum);

        var result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            var left = query[0];
            var right = query[1];

            var leftContainerIndex = pointToContainerIndex[left];
            var rightContainerIndex = pointToContainerIndex[right];
                
            var sumRes = 0;
            if (leftContainerIndex == rightContainerIndex) {
                // do nothing
            }
            else if (s[left] == '*' && s[right] == '*' || s[left] == '|' && s[right] == '*')
            {
                sumRes += Math.Max(containerSums[rightContainerIndex - 1] - containerSums[leftContainerIndex], 0);
            }
            else if (s[left] == '*' && s[right] == '|' || s[left] == '|' && s[right] == '|')
            {
                sumRes += containerSums[rightContainerIndex] - containerSums[leftContainerIndex];
            }

            result[i] = sumRes;
        }
        
        return result;
    }
}