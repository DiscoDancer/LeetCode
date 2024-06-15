public class Solution {
    public int FirstMissingPositive(int[] nums) {
        var sortedList = new List<int>();
        foreach (var x in nums)
        {
            if (x > 0)
            {
                sortedList.Add(x);
            }
        }
        
        sortedList.Sort();

        if (sortedList.Count == 0)
        {
            return 1;
        }
        
        var prev = sortedList[0];
        if (prev > 1)
        {
            return 1;
        }

        for (var i = 1; i < sortedList.Count; i++)
        {
            var cur = sortedList[i];
            if (cur - prev > 1)
            {
                return prev + 1;
            }

            prev = cur;
        }
        
        return prev + 1;
    }
}