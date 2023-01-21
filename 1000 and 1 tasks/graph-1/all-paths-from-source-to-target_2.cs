// https://leetcode.com/problems/all-paths-from-source-to-target/solutions/716919/all-paths-from-source-to-target/?orderBy=most_votes
public class Solution {
    private int target;
    private int[][] graph;
    private List<IList<int>> results;

    private void backtrack(int currNode, List<int> path) {
        if (currNode == this.target) {
            this.results.Add(new List<int>(path));
            return;
        }
        foreach (var nextNode in  this.graph[currNode]) {
            path.Add(nextNode);
            this.backtrack(nextNode, path);
            path.Remove(nextNode);
        }
    }

    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        this.target = graph.Length - 1;
        this.graph = graph;
        this.results = new List<IList<int>>();

        var path = new List<int>();
        path.Add(0);

        this.backtrack(0, path);
        return this.results;
    }
}