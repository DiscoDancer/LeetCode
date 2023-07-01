public class Solution {
    public int StrStr(string haystack, string needle) {
        if (haystack.Length < needle.Length) {
            return -1;
        }

        var cyclesCount = haystack.Length - needle.Length + 1;
        for (int i = 0; i < cyclesCount; i++) {
            var result = true;
            for (int j = 0; j < needle.Length && result; j++) {
                result = needle[j] == haystack[j + i];
            }
            if (result) {
                return i;
            }
        }

        return -1;
    }
}