public class Solution {
    // no adjacent

    private int[] _nums;
    private Dictionary<(int i, bool t), int> _table = new ();

    private int F(int index, bool tookLast) {
        if (index >= _nums.Length) {
            return 0;
        }
        else if (_table.ContainsKey((index, tookLast))) {
            return _table[(index, tookLast)];
        }
        
        int result;
        if (!tookLast) {  
            var take = _nums[index] + F(index + 1, true);
            var notTake = F(index + 1, false);
            result =  Math.Max(take, notTake);
        }
        else {
            result = F(index + 1, false);
        }

        _table[(index, tookLast)] = result;
        return result;
    }

    // memorization, accepted
    public int Rob(int[] nums) {
        _nums = nums;
        return F(0, false);
    }
}