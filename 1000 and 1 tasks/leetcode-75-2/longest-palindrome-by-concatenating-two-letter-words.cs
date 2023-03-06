public class Solution {
    public int LongestPalindrome(string[] words) {
        var result = 0;
        var table = new Dictionary<string,int>();
        var sameTable = new Dictionary<string,int>();

        foreach(var word in words) {
            var ab = word;
            var a = ab[0];
            var b = ab[1];

            if (a == b) {
                if (sameTable.ContainsKey(ab)) {
                    sameTable[ab]++;
                }
                else {
                    sameTable[ab] = 1;
                }

                if (sameTable[ab] >= 2) {
                    result += 4;
                    sameTable[ab] -= 2;

                    if (sameTable[ab] == 0) {
                        sameTable.Remove(ab);
                    }
                }
                continue;
            }

            var ba = b.ToString() + a.ToString();
            if (table.ContainsKey(ba)) {
                table[ba] -= 1;
                if (table[ba] == 0) {
                    table.Remove(ba);
                }
                result += 4;
                continue;
            }

            if (table.ContainsKey(ab)) {
                table[ab]++;
            } else {
                table[ab] = 1;
            }
        }

        if (sameTable.Values.Any(x => x >= 1)) {
            result += 2;
        }

        return result;
    }
}