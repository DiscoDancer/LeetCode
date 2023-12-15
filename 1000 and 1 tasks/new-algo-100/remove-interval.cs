public class Solution {
    // [a, b)
    public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved) {
        var result = new List<IList<int>>();

        for (int i = 0; i < intervals.Length; i++) {
            var currentInterval = intervals[i];
            // слишком маленькие -> добавляем
            if (currentInterval[1] <= toBeRemoved[0]) {
                result.Add(currentInterval);
            }
            // слишком большие -> тоже добавляем
            else if (currentInterval[0] >= toBeRemoved[1]) {
                result.Add(currentInterval);
            }
            // полностью внутри -> не добавляем
            else if (currentInterval[0] >= toBeRemoved[0] && currentInterval[1] <= toBeRemoved[1] ) {
                // not to add
            }
            // частично внутри -> можем добавить
            else {
                if (currentInterval[0] < toBeRemoved[0]) {
                    var begin = currentInterval[0];
                    var end = Math.Min(currentInterval[1], toBeRemoved[0]);
                    if (end - begin > 0) {
                        result.Add(new List<int>() {begin, end});
                    }
                }
                if (currentInterval[1] > toBeRemoved[1]) {
                    var begin = toBeRemoved[1];
                    var end = currentInterval[1];
                    if (end - begin > 0) {
                        result.Add(new List<int>() {begin, end});
                    }
                }
            }
        }

        return result;
    }
}