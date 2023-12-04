public class Solution {
    public int[] AnagramMappings(int[] nums1, int[] nums2) {
        var valToAnyIndexTable = new Dictionary<int, int>();

        for (int i = 0; i < nums2.Length; i++) {
            valToAnyIndexTable[nums2[i]] = i;
        }

        var result = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++) {
            result[i] = valToAnyIndexTable[nums1[i]];
        }

        return result;
    }
}