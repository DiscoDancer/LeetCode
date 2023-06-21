public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        if (nums1.Length > nums2.Length) {
            Intersect(nums2, nums1);
        }

        var arr1 = nums1.OrderBy(x => x).ToArray();
        var arr2 = nums2.OrderBy(x => x).ToArray();

        var i = 0;
        var j = 0;
        var k = 0;

        while (i < nums1.Length && j < nums2.Length) {
            if (arr1[i] < arr2[j]) {
                i++;
            }
            else if (arr1[i] > arr2[j]) {
                j++;
            }
            else {
                j++;
                arr1[k++] = arr1[i++];
            }
        }

        return arr1.Take(k).ToArray();
    }
}