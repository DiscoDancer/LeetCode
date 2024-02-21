public class Solution {
    private int[] _sweetness;
    private int _k;

    private int F(int sweetIndex, int humanIndex, int currentHumanSum, int min)
    {
        if (sweetIndex == _sweetness.Length)
        {
            if (humanIndex == _k + 1)
            {
                return min;
            }

            return int.MinValue;
        }
        
        // add to current human
        var newSum = currentHumanSum + _sweetness[sweetIndex];
        var addToCurrentHuman = F(sweetIndex + 1, humanIndex, newSum, min);
        var startNewHuman = int.MinValue;
        
        // start new human
        if (humanIndex <= _k)
        {
            startNewHuman = F(sweetIndex + 1, humanIndex + 1, 0, Math.Min(newSum, min)); 
        }

        return Math.Max(addToCurrentHuman, startNewHuman);
    }
    
    public int MaximizeSweetness(int[] sweetness, int k)
    {
        _sweetness = sweetness;
        _k = k;

        return F(0, 0, 0, int.MaxValue);
    }
}