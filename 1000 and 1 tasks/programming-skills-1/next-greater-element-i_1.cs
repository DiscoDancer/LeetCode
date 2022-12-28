public class Solution {
    // что можно тут ускорить?
    // это квадрат и квадрат медленно
    // можно убрать первый while
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var res = new int[nums1.Length];

        // можно и count table сделать
        var dic = new Dictionary<int, int>();
        for (int i = 0; i < nums2.Length; i++) {
            dic[nums2[i]] = i;
        }

        for (int i = 0; i < res.Length; i++) {
            int j = dic[nums1[i]];
            while(j < nums2.Length && nums2[j] <= nums1[i]) {
                j++;
            }
            res[i] = j < nums2.Length ? nums2[j] : -1;
        }

        return res;
    }
}