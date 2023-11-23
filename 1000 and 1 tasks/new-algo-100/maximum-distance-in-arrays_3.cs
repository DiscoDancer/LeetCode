public class Solution {
    // editorial based
    public int MaxDistance(IList<IList<int>> arrays) {
        var minFoundBefore = arrays[0].First();
        var maxFoundBefore = arrays[0].Last();

        var result = 0;

        for (int i = 1; i < arrays.Count(); i++) {
            var curMin = arrays[i].First();
            var curMax = arrays[i].Last();

            result = Math.Max(Math.Abs(maxFoundBefore-curMin), result);
            result = Math.Max(Math.Abs(curMax-minFoundBefore), result);

            minFoundBefore = Math.Min(minFoundBefore, curMin);
            maxFoundBefore = Math.Max(curMax, maxFoundBefore);
        }

        return result;
    }
}