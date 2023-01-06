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
                var rowArr = row.ToArray();
                int? prevPrev = null;
                int? prev = null;
                for (int i = 0; i < rowArr.Length; i++) {
                    prevPrev = prev;
                    prev = prevRowCalculated[i];

                    if (i == 0) { // есть только правый
                        prevRowCalculated[i] += rowArr[i];
                    }
                    else if (i < rowArr.Length - 1) { // есть оба
                        prevRowCalculated[i] = rowArr[i] + Math.Min(prevPrev.Value, prev.Value);
                    }
                    else { // есть только левый
                        prevRowCalculated[i] = rowArr[i] + prevPrev.Value;
                    }
                }
            }
        }

        return prevRowCalculated.Min();
    }
}