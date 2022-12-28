public class Solution {
    // стек заменить на очередь?
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var dic = new Dictionary<int, int>();
        var stack = new Stack<int>();
        stack.Push(nums2[0]);

        for (int i = 1; i < nums2.Length; i++) {
            while (stack.Any() && nums2[i] > stack.Peek()) {
                dic[stack.Pop()] = nums2[i];
            }
            stack.Push(nums2[i]);
        }

        while (stack.Any()) {
            dic[stack.Pop()] = -1;
        }

        var res = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++) {
            res[i] = dic[nums1[i]];
        }

        return res;
    }
}