public class Solution {
    // https://leetcode.com/problems/word-break/solutions/127450/word-break/?envType=study-plan&id=dynamic-programming-i
    public bool WordBreak(string s, IList<string> wordDict) {
        var wordDictSet = new HashSet<string>(wordDict);
        var queue = new Queue<int>();
        var visited = new bool[s.Length];
        queue.Enqueue(0);

        while(queue.Any()) {
            var start = queue.Dequeue();
            if (visited[start]) {
                continue;
            }
            for (int end = start + 1; end <= s.Length; end++) {
                if (wordDictSet.Contains(s.Substring(start, end - start))) {
                    queue.Enqueue(end);
                    if (end == s.Length) {
                        return true;
                    }
                }
            }
            visited[start] = true;
        }

        return false;
    }
}