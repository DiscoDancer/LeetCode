public class Solution {
    private List<IList<int>> InsertAllPositions(IList<int> list, int x) {
        var result = new List<IList<int>>();
        
        // between
        for (int i = 0; i <= list.Count(); i++) {
            var copy = list.ToList();
            copy.Insert(i, x);
            result.Add(copy);
        }

        return result;
    }

    public IList<IList<int>> Permute(int[] nums) {
        var result = new List<IList<int>> ();
        result.Add(new List<int>());

        foreach (var n in nums) {
            var list3 = new List<IList<IList<int>>>();
            foreach (var list in result) {
                var inserted = InsertAllPositions(list, n);
                list3.Add(inserted);
            }

            result = list3.SelectMany(x => x).ToList();
        }

        return result;
    }
}