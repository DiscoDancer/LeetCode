public class Solution {
    // мб хранить индексы?
    public int[] NextGreaterElements(int[] nums) {
        var n = nums.Length;
        var res = new int[n];
        Array.Fill(res, -1);
        var stack = new Stack<(int num, int index)>();

        // для 5 4 3 2 1 в стеке будет все
        // по мере Pop() элементы будут возрастать индексы тоже
        for (int i = 0; i < n; i++) {
            while (stack.Any() && stack.Peek().num < nums[i]) {
                res[stack.Pop().index] = nums[i];
            }
            stack.Push((nums[i], i));
        }

        for (int i = 0; i < n; i++) {
            while (stack.Any() && stack.Peek().num < nums[i]) {
                res[stack.Pop().index] = nums[i];
            }
        }

        return res;
    }
}