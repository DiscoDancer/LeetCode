public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        var table = new bool[nums.Length + 1];
        foreach (var num in nums) {
            table[num] = true;
        }

        var list = new List<int>();
        for (int i = 1; i < table.Length; i++) {
            if (!table[i]) {
                list.Add(i);
            }
        }

        return list;
    }
}