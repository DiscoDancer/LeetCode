public class Solution {
    
    private IList<IList<int>> _output = new List<IList<int>>();
    private int _n;
    private int[] _arr;
    
    public void Swap(int[] nums, int i, int j) {
        var k = nums[i];
        nums[i] = nums[j];
        nums[j] = k;
    }
    
    public void BackTrack(int[] nums, int k) {
        
        if (k == _n) {
            _output.Add(new List<int>(nums));
            return;
        }
        
        for (int i = k; i < _n; i++) {
            // swap
            Swap(nums, k, i);
            
            // call again
            BackTrack(nums, k + 1);
            
            // unswap
            Swap(nums, k, i);
        }
    }
    
    public IList<IList<int>> Permute(int[] nums) {
        _n = nums.Length;
        _arr = nums;
        
        BackTrack(nums, 0);
        
        return _output;
    }
}