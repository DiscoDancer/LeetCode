public class Solution {
    // sorted  -> bin search


    // still TL
    public int MaxDistance(IList<IList<int>> arrays) {
        var max = 0;
        for (int i = 0; i < arrays.Count(); i++) {
            for (int j = i + 1; j < arrays.Count(); j++) {
                max = Math.Max(Math.Abs(arrays[i].First() - arrays[j].Last()), max);
                max = Math.Max(Math.Abs(arrays[j].First() - arrays[i].Last()), max);
            }
        }

        return max;
    }
}