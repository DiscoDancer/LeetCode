public class Solution {
    // такая же формула, только res[i] = costs[i] + min(neigh a, neigh b);
    public int MinimumTotal(IList<IList<int>> triangle) {
        var N = triangle.Count();
        var prevRowCalculated = new int[N];
        foreach(var row in triangle) {
            if (row == triangle.First()) {
                prevRowCalculated[0] = row[0];
            }
            else {
                // один сосед есть всегда
                var rowArr = row.ToArray();
                var curRowCalculated = new int[N];
                for (int i = 0; i < rowArr.Length; i++) {
                    if (i == 0) { // есть только правый
                        curRowCalculated[i] = rowArr[i] + prevRowCalculated[i];
                    }
                    else if (i == rowArr.Length - 1) { // есть только левый
                        curRowCalculated[i] = rowArr[i] + prevRowCalculated[i-1];
                    }
                    else { // есть оба
                        curRowCalculated[i] = rowArr[i] + Math.Min(prevRowCalculated[i-1], prevRowCalculated[i]);
                    }
                }

                prevRowCalculated = curRowCalculated;
            }
        }

        return prevRowCalculated.Min();
    }
}