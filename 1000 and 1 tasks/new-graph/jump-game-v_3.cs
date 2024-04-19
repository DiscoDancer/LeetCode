public class Solution {
    private int _d;
    private int[] _arr;


    private int?[] _mem;


    private int F(int index) {
        if (_mem[index] != null)
        {
            return _mem[index]!.Value;
        }
        
        var forwardResult = 0;
        for (var i = 1; i <= _d && index + i < _arr.Length; i++)
        {
            if (_arr[index + i] >= _arr[index]) {
                break;
            }

            forwardResult = Math.Max(forwardResult, 1 + F(index + i));
        }

        var backwardResult = 0;
        for (var i = 1; i <= _d && index - i >= 0 ; i++)
        {
            if (_arr[index - i] >= _arr[index]) {
                break;
            }

            backwardResult = Math.Max(backwardResult, 1 + F(index - i));
        }

        _mem[index] = Math.Max(1, Math.Max(forwardResult, backwardResult));

        return _mem[index]!.Value;
    }

    public int MaxJumps(int[] arr, int d) {
        _arr = arr;
        _d = d;
        _mem = new int?[arr.Length];

        var max = 0;

        for (int i = 0; i < arr.Length; i++) {
            max = Math.Max(F(i), max);
        }

        return max;
    }
}