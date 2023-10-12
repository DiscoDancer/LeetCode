public class Solution {
    // sort + 2 pointers
    // hash table
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        var list1 = new List<int>();
        var list2 = new List<int>();
        
        Array.Sort(nums1);
        Array.Sort(nums2);

        var p1 = 0;
        var p2 = 0;

        while (p1 < nums1.Length && p2 < nums2.Length) {
            // мотаем повторения
            while (p1 < nums1.Length - 1 && nums1[p1] == nums1[p1+1]) {
                p1++;
            }
            while (p2 < nums2.Length - 1 && nums2[p2] == nums2[p2+1]) {
                p2++;
            }

            if (nums1[p1] == nums2[p2]) {
                p1++;
                p2++;
            }
            else if (nums1[p1] < nums2[p2]) {
                list1.Add(nums1[p1]);
                p1++;
            }
            else {
                list2.Add(nums2[p2]);
                p2++;
            }
        }

        while (p1 < nums1.Length) {
            if (!list1.Any() || list1.Last() != nums1[p1]) {
                list1.Add(nums1[p1]);
            }
            p1++;
        }

        while (p2 < nums2.Length) {
            if (!list2.Any() || list2.Last() != nums2[p2]) {
                list2.Add(nums2[p2]);
            }
            p2++;
        }

        return new List<IList<int>>() {list1, list2};
    }
}