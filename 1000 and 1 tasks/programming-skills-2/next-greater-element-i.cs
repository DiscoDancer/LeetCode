public class Solution {
    // nums1 is a subset of nums2
    // сделать этот monotoic для nums2
    // и резы хранить в словаре, чтобы за квадрат не искать
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var ngeTable = new Dictionary<int, int>();
        var stack = new Stack<int>();

        for (int i = 0; i < nums2.Length; i++) {
            while (stack.Any() && stack.Peek() < nums2[i]) {
                ngeTable[stack.Pop()] = nums2[i];
            }

            stack.Push(nums2[i]);
        }

        while (stack.Any()) {
            ngeTable[stack.Pop()] = -1;
        }

        return nums1.Select(x => ngeTable[x]).ToArray();
    }
}