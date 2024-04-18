// TL

public class Solution {

    private int _d;
    private int[] _arr;


    private int F(int index) {
        var result = 1;

        var forwardResult = 0;
        var backwardResult = 0;
        
        // их не всегда можно складывать, но иногда можно
        
        // go forward
        for (var i = 1; i <= _d && index + i < _arr.Length; i++)
        {
            if (_arr[index + i] >= _arr[index]) {
                break;
            }

            forwardResult = Math.Max(forwardResult, 1 + F(index + i));
        }

        // go backward
        for (var i = 1; i <= _d && index - i >= 0 ; i++)
        {
            if (_arr[index - i] >= _arr[index]) {
                break;
            }

            backwardResult = Math.Max(backwardResult, 1 + F(index - i));
        }

        return Math.Max(1, Math.Max(forwardResult, backwardResult));
    }


    public int MaxJumps(int[] arr, int d) {
        _arr = arr;
        _d = d;

        var max = 0;

        for (int i = 0; i < arr.Length; i++) {
            max = Math.Max(F(i), max);
        }

        return max;
    }
}