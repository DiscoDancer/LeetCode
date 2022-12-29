public class Solution {
    public int MaximumWealth(int[][] accounts) {
        return accounts.Select(x => x.Sum()).Max();
    }
}