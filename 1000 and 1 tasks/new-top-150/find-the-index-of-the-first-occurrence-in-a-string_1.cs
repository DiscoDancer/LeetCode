public class Solution {
    // naiive, sum sliding
    public int StrStr(string haystack, string needle) {
        if (needle.Length > haystack.Length) {
            return -1;
        }

        var sumNeedle = needle.Select(c => c-'a').Sum();
        var sumHaystack = 0;
        for (int i = 0; i < needle.Length - 1; i++) {
            sumHaystack += haystack[i] - 'a';
        }

        var leftIndex = 0;
        var rightIndex = leftIndex + needle.Length - 1;
        while (rightIndex < haystack.Length) {

            sumHaystack += haystack[rightIndex] - 'a';
            if (leftIndex > 0) {
                sumHaystack -= haystack[leftIndex-1] - 'a';
            }

            if (sumHaystack == sumNeedle) {
                var i = leftIndex;
                var eq = true;
                while (i <= rightIndex && eq) {
                    eq &= needle[i-leftIndex] == haystack[i];
                    i++;
                }
                if (eq) {
                    return leftIndex;
                }
            }

            leftIndex++;
            rightIndex++;
        }

        return -1;
    }
}