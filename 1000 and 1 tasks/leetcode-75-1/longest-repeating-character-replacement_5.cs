public class Solution {
    // сори я просто копипастнул их решение, но оно пока не очень
    public int CharacterReplacement(string s, int k) {
        var letters = s.ToCharArray().Distinct();

        var maxLength = 0;
        foreach (var letter in letters) {
            var start = 0;
            var count = 0;

            for (int end = 0; end < s.Length; end++) {
                if (s[end] == letter) {
                    count++;
                }

                while (!IsWindowValid(start, end, count, k)) {
                    if (s[start] == letter) {
                        count--;
                    }
                    start++;
                }
                maxLength = Math.Max(maxLength, end + 1 - start);
            }
        }

        return maxLength;
    }

    private bool IsWindowValid(int start, int end, int count, int k) {
        return end + 1 - start - count <= k;
    }

}