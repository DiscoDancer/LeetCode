// TL
public class Solution {
    public bool CanReach(string s, int minJump, int maxJump) {
        var table = new bool[s.Length];
        table[0] = true;

        var reachableIndexes = new List<int>() {0};

        for (int index = 1; index < s.Length; index++) {
            if (s[index] == '1') continue;
            
            var isReachable = reachableIndexes.Any(i => index - i >= minJump && index - i <= maxJump );
            table[index] = isReachable;
            if (table[index]) {
                reachableIndexes.Add(index);
            }
        }

        return table[s.Length - 1];
    }
}