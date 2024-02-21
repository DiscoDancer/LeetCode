public class Solution {
    private int[] _sweetness;
    private int _k;
    private int _result = int.MinValue;

    private void F(int sweetIndex, int humanIndex, int currentHumanSum, int min)
    {
        if (sweetIndex == _sweetness.Length)
        {
            if (humanIndex == _k + 1)
            {
                if (currentHumanSum != 0)
                {
                    min = Math.Min(min, currentHumanSum);
                }

                _result = Math.Max(_result, min);
            }
            return;
        }
        
        // add to current human
        var newSum = currentHumanSum + _sweetness[sweetIndex];
        F(sweetIndex + 1, humanIndex, newSum, min);
        
        // start new human
        if (humanIndex <= _k)
        {
            F(sweetIndex + 1, humanIndex + 1, 0, Math.Min(newSum, min)); 
        }
    }
    
    public int MaximizeSweetness(int[] sweetness, int k)
    {
        _sweetness = sweetness;
        _k = k;

        F(0, 0, 0, int.MaxValue);

        return _result;
    }
}