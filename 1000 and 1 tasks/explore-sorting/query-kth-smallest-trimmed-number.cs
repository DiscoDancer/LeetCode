public class Solution {
    // https://leetcode.com/problems/query-kth-smallest-trimmed-number/solutions/3257828/java-solution-with-counting-radix-sort/
    private string[] countingSort(string[] nums, int byRank)
    {
        var n = nums[0].Length;
        var digits = new int[10];
        foreach (var num in nums)
        {
            digits[num[n - byRank] - '0']++;
        }

        for (var i = 1; i < 10; i++)
        {
            digits[i] += digits[i - 1];
        }

        for (var i = 9; i > 0; i--)
        {
            digits[i] = digits[i - 1];
        }

        digits[0] = 0;
        var result = new string[nums.Length];
        foreach (var num in nums)
        {
            result[digits[num[n - byRank] - '0']] = num;
            digits[num[n - byRank] - '0']++;
        }

        return result;
    }

    public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
    {
        var n = nums[0].Length;
        var sortedArrays = new string[n+1][];
        sortedArrays[0] = nums;
        for (int i = 1; i <= n; i++){
            sortedArrays[i] = countingSort(sortedArrays[i-1], i);
        }
        int[] result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++){
            int subRes=0;
            int numOfEqualsDigits=0;
            for (int j = 0; j < nums.Length; j++){
                if (nums[j] == sortedArrays[queries[i][1]][queries[i][0]-1]){
                    subRes = j;
                    numOfEqualsDigits++;
                    if (numOfEqualsDigits == queries[i][0]) break;
                }
            }
            result[i]=subRes;
        }
        return result;
    }
}