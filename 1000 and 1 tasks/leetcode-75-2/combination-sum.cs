public class Solution {
    private List<IList<int>> _result = new ();
    private HashSet<string> _hs = new ();
    private int[] _candidates;

    private void AddToResult(int[] nums) {
        var sb = new StringBuilder();
        foreach (var n in nums) {
            sb.Append(n);
        }
        if (_hs.Add(sb.ToString())) {
            _result.Add(Convert(nums));
        }
    }

    private List<int> Convert(int[] nums) {
        var list = new List<int>();
        for (int i = 0; i < nums.Length; i++) {
            while (nums[i] > 0) {
                list.Add(_candidates[i]);
                nums[i]--;
            }
        }

        return list;
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        _candidates = candidates;

        var queue = new Queue<(int[] nums, int sum)>();
        var originalEmpty = new int[candidates.Length];
        queue.Enqueue((originalEmpty, 0));

        while (queue.Any()) {
            var (nums, sum) = queue.Dequeue();

            for (var i = 0; i < candidates.Length; i++) {
                var candidate = candidates[i];
                if (candidate + sum > target) {
                    continue;
                }
                var copy = nums.ToArray();
                copy[i]++;
                if (candidate + sum == target) {
                    AddToResult(copy);
                }
                else {
                    queue.Enqueue((copy, candidate + sum));
                }
            }
        }

        return _result;
    }
}