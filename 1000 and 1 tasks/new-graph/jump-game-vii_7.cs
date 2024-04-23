public class Solution {
    public bool CanReach(string s, int minJump, int maxJump) {
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
            if (isReachable) {
                if (index == s.Length - 1) return true;
                reachableIndexes.Add(index);
            }
        }

        return false;
    }
}