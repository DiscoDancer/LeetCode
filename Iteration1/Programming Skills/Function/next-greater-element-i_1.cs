public class Solution {
    // в лоб
    // оптимизация hash table
    // динамич программирование, сколько больше, чем N
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var table = new Dictionary<int, int>();
        var stack = new Stack<int>();
        
        for (int i = 0; i < nums2.Length; i++) {
            while (stack.Any() && nums2[i] > stack.Peek()) {
                table[stack.Pop()] = nums2[i];
            }
            stack.Push(nums2[i]);
        }
        
        while (stack.Any()) {
            table[stack.Pop()] = -1;
        }
        
        return nums1.Select(x => table[x]).ToArray();
    }
}