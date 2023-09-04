public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        var sorted = arr.ToArray();
        Array.Sort(sorted);

        var prev = sorted[0];
        var result = new List<IList<int>>();
        var curDifference = int.MaxValue;

        for (int i = 1; i < sorted.Length; i++) {
            var cur = sorted[i];
            var difference = Math.Abs(prev - cur);

            if (difference < curDifference) {
                curDifference = difference;
                result = new List<IList<int>>();
            }
            if (difference == curDifference) {
                result.Add(new int[] {sorted[i-1], sorted[i]});
            }

            prev = cur;
        }

        return result;
    }
}