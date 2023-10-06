public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        var max = candies.Max();

        var result = new List<bool>();
        foreach (var c in candies) {
            result.Add(c + extraCandies >= max);
        }

        return result;
    }
}