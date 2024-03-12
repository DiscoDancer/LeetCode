public class Solution {

    // предположим, что контейнер всегда включает правую границу
    // граница одна, пусть идет в оевый всегда
    public int[] PlatesBetweenCandles(string s, int[][] queries) {
        var pointToContainerIndex = new List<int>[s.Length];

        var containerCount = 0;
        var sum = 0;
        var containerSums = new List<int>();
        for (int i = 0; i < s.Length; i++) {
            pointToContainerIndex[i] = new List<int>() {containerCount};
            if (s[i] == '|') {
                containerSums.Add(sum);
                containerCount++;
                pointToContainerIndex[i].Add(containerCount);
            }
            else
            {
                sum++;
            }
        }
        containerSums.Add(sum);

        var result = new List<int>();
        foreach (var query in queries)
        {
            var left = query[0];
            var right = query[1];

            var leftContainerIndex = pointToContainerIndex[left].First();
            var rightContainerIndex = pointToContainerIndex[right].First();
                
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
            
            result.Add(sumRes);
        }
        
        return result.ToArray();
    }
}