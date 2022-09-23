public class Solution {
    public int MaximumWealth(int[][] accounts) {    
        return accounts.Select(x => x.Aggregate((a,b) => a + b)).Max();
    }
}