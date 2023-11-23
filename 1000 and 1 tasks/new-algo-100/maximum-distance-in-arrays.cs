public class Solution {
    // sorted  -> bin search


    // TL
    public int MaxDistance(IList<IList<int>> arrays) {
        var max = 0;
        for (int i = 0; i < arrays.Count(); i++) {
            for (int j = i + 1; j < arrays.Count(); j++) {
                foreach (var a in arrays[i]) {
                    foreach (var b in arrays[j]) {
                        max = Math.Max(max, Math.Abs(a-b));
                    }
                }
            }
        }

        return max;
    }
}