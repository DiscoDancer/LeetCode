public class Solution {
    // editorial
    public int LargestRectangleArea(int[] heights) {
        var stack = new Stack<int>();
        stack.Push(0);
        var max = 0;

        for (int i = 1; i < heights.Length; i++) {
            while (stack.Any() && heights[stack.Peek()] >= heights[i]) {
                var currentHeight = heights[stack.Pop()];
                int currentWidth = !stack.Any() ? i : i - stack.Peek() - 1;
                max = Math.Max(max, currentHeight * currentWidth);
            }
            stack.Push(i);
        }

        while(stack.Any()) {
            int currentHeight = heights[stack.Pop()];
            int currentWidth = !stack.Any() ? heights.Length : heights.Length - stack.Peek() - 1;
            max = Math.Max(max, currentHeight * currentWidth);
        }

        return max;
    }
}