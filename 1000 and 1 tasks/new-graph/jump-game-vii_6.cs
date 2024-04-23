
public class Solution {
    public bool CanReach(string s, int minJump, int maxJump) {
        var table = new bool[s.Length];
        table[0] = true;

        // строго возрастают
        var reachableIndexes = new List<int>() {0};

        for (int index = 1; index < s.Length; index++) {
            if (s[index] == '1') continue;

            // слишком далекие больше не нужны
            while (reachableIndexes.Any() && index - reachableIndexes.First() > maxJump)
            {
                reachableIndexes.RemoveAt(0);
            }

            // первый самый дальний, поэтому проверяем минимум по нему
            var isReachable = reachableIndexes.Any() && index - reachableIndexes.First() >= minJump;
            table[index] = isReachable;
            if (table[index]) {
                reachableIndexes.Add(index);
            }
        }

        return table[s.Length - 1];
    }
}