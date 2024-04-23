// passes

public class Solution {
    public bool CanReach(string s, int minJump, int maxJump) {
        var table = new bool[s.Length];
        table[0] = true;

        // наши индексы будут строга возрастать
        var reachableIndexes = new List<int>() {0};

        for (int index = 1; index < s.Length; index++) {
            if (s[index] == '1') continue;

            // remove not reachable from top
            while (reachableIndexes.Any() && index - reachableIndexes.First() > maxJump)
            {
                reachableIndexes.RemoveAt(0);
            }
            
            var isReachable = reachableIndexes.Any(i => index - i >= minJump && index - i <= maxJump );
            table[index] = isReachable;
            if (table[index]) {
                reachableIndexes.Add(index);
            }
        }

        return table[s.Length - 1];
    }
}