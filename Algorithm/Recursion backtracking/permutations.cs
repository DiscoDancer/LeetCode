public class Solution {
    
    private IList<IList<int>> _output = new List<IList<int>>();
    private int _n;
    private int[] _arr;
    
    public void BackTrack(List<int> list) {
        if (list.Count() == _n) {
            _output.Add(new List<int>(list));
            return;
        }
        
        // find valid numbers
        var diff = _arr.Except(list).ToArray();
        
        for (int i = 0; i < _n; i++) {
            if (diff.Contains(_arr[i])) {
                list.Add(_arr[i]);
                BackTrack(list);
                list.RemoveAt(list.Count() - 1);
            }
        }
    }
    
    public IList<IList<int>> Permute(int[] nums) {
        _n = nums.Length;
        _arr = nums;
        
        BackTrack(new List<int>());
        
        return _output;
    }
}