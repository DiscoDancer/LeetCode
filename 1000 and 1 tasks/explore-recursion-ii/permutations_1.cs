public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var lists = new List<IList<int>>() {new List<int>(){}};

        for (int i = 0; i < nums.Length; i++) {
            var newLists = new List<IList<int>>();

            foreach (var list in lists) {
                foreach (var n in nums) {
                    if (!list.Contains(n)) {
                        var copy = list.ToList();
                        copy.Add(n);
                        newLists.Add(copy);
                    }
                }
            }

            lists = newLists;
        }

        return lists;
    }
}