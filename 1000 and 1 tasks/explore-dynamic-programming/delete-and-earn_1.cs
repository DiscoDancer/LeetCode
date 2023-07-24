public class Solution {
    /*
        Roadmap:
        - top
        - bottom
    */

    private Dictionary<int, int> _points = new ();
    private Dictionary<int, int> _mem = new ();

    private int F(int num) {
        if (num == 0) {
            return 0;
        }
        if (num == 1) {
            return _points.ContainsKey(num) ? _points[num] : 0;
        }
        if (_mem.ContainsKey(num)) {
            return _mem[num];
        }

        var gain = _points.ContainsKey(num) ? _points[num] : 0;
        var result = Math.Max(F(num-1), F(num-2) + gain);
        _mem[num] = result;

        return result;
    }

    // editorial
    public int DeleteAndEarn(int[] nums) {
        var max = 0;

        foreach (var n in nums) {
            if (!_points.ContainsKey(n)) {
                _points[n] = 0;
            }
            _points[n] += n;
            max = Math.Max(max, n);
        }

        

        return F(max);
    }
}