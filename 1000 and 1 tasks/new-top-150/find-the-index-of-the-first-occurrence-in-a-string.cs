public class Solution {
    // naiive, sum sliding
    public int StrStr(string haystack, string needle) {
        if (needle.Length > haystack.Length) {
            return -1;
        }

        var leftIndex = 0;
        var rightIndex = leftIndex + needle.Length - 1;
        while (rightIndex < haystack.Length) {

            var i = leftIndex;
            var eq = true;
            while (i <= rightIndex && eq) {
                eq &= needle[i-leftIndex] == haystack[i];
                i++;
            }
            if (eq) {
                return leftIndex;
            }

            leftIndex++;
            rightIndex++;
        }

        return -1;
    }
}