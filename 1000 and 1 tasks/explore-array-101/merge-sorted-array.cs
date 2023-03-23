public class Solution {
    private static void Shift1(int[] arr)
    {
        var prev = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            var tmp = arr[i];
            arr[i] = prev;
            prev = tmp;
        }
    }

    private static void ShiftN(int[] arr, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Shift1(arr);
        }
    }

    // сдвинуть m до конца, а дальше 2 pointers
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var shiftSize = nums1.Length - m;
        ShiftN(nums1, shiftSize);

        var nums1Index = shiftSize;
        var nums2Index = 0;
        var globalIndex = 0;

        while (nums1Index < nums1.Length && nums2Index < nums2.Length)
        {
            if (m > 0 && nums1[nums1Index] < nums2[nums2Index])
            {
                nums1[globalIndex++] = nums1[nums1Index++];
                m--;
            }
            else if (n > 0)
            {
                nums1[globalIndex++] = nums2[nums2Index++];
                n--;
            }
        }

        while (nums1Index < nums1.Length && m > 0)
        {
            nums1[globalIndex++] = nums1[nums1Index++];
            m--;
        }

        while (nums2Index < nums2.Length && n > 0)
        {
            nums1[globalIndex++] = nums2[nums2Index++];
            n--;
        }
    }
}