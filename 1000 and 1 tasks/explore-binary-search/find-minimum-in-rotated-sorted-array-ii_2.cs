public class Solution {
    private int[] _nums;
    private int _min;

    private void F(int l, int r) {
        if (l > r)
        {
            return;
        }
        
        var m = l + (r-l)/2;
        _min = Math.Min(_min, _nums[m]);

        if (l == r)
        {
            return;
        }

        if (_nums[l] == _nums[m] && _nums[m] == _nums[r])
        {
            F(l,m-1);
            F(m+1,r); 
        }
        if (_nums[l] < _nums[m] && _nums[m] == _nums[r])
        {
            F(l,m-1);
            // F(m+1,r); 
        }
        if (_nums[l] > _nums[m] && _nums[m] == _nums[r])
        {
            F(l,m-1);
            // F(m+1,r); 
        }
        
        if (_nums[l] == _nums[m] && _nums[m] > _nums[r])
        {
            // F(l,m-1);
            F(m+1,r); 
        }
        if (_nums[l] < _nums[m] && _nums[m] > _nums[r])
        {
            // F(l,m-1);
             F(m+1,r); 
        }
        if (_nums[l] > _nums[m] && _nums[m] > _nums[r])
        {
            F(l,m-1);
            // F(m+1,r); 
        }
        
        if (_nums[l] == _nums[m] && _nums[m] < _nums[r])
        {
            // F(l,m-1);
            F(m+1,r); 
        }
        if (_nums[l] < _nums[m] && _nums[m] < _nums[r])
        {
            F(l,m-1);
            // F(m+1,r); 
        }
        if (_nums[l] > _nums[m] && _nums[m] < _nums[r])
        {
            F(l,m-1);
            // F(m+1,r); 
        }
    }

    // решил почти подбором
    public int FindMin(int[] nums) {
        _nums = nums;
        _min = nums[0];

        F(0, nums.Length - 1);

        return _min;
    }
}