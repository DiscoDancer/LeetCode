public class Solution {
    // https://leetcode.com/problems/unique-binary-search-trees/solutions/168911/unique-binary-search-trees/?envType=study-plan&id=dynamic-programming-i&orderBy=most_votes
    public int NumTrees(int n) {
        int[] G = new int[n + 1];
        G[0] = 1;
        G[1] = 1;

        for (int i = 2; i <= n; ++i) {
            for (int j = 1; j <= i; ++j) {
                G[i] += G[j - 1] * G[i - j];
            }
        }
        
        return G[n];
    }
}