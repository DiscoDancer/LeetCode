public class Solution {
    private int FindFirstBigger(int[] sortedPotions, long x) {
        var l = 0;
        var r = sortedPotions.Length - 1;

        while (l <= r) {
            var m = l + (r-l)/2;
            if (sortedPotions[m] < x) {
                l = m + 1;
            }
            else if (sortedPotions[m] >= x) {
                if (m == 0 || sortedPotions[m - 1] < x) {
                    return m;
                }
                r = m - 1;
            }
        }

        if (l >= sortedPotions.Length) {
            return -1;
        }
        return l;
    }

    // в каждом массиве сила
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        var n = spells.Length;
        var m = potions.Length;

        var sortedPotions = potions.OrderBy(x => x).ToArray();

        var result = new int[n];
        for (int i = 0; i < n; i++) {
            var required = success / spells[i];
            if (required * spells[i] != success) {
                required++;
            }

            var foundIndex = FindFirstBigger(sortedPotions, required);
            if (foundIndex == -1) {
                result[i] = 0;
            }
            else {
                result[i] = potions.Length - (foundIndex);
            }
        }

        return result;
    }
}