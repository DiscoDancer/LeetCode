// проходит, но квадрат
public class Solution {
    // нужно делать что-то типа priority queue BFS, пытаться улететь на одном прыжке
    public int Jump(int[] nums) {
        var table = new int[nums.Length];
        Array.Fill(table, int.MaxValue);
        table[0] = 0;

        for (int i = 0; i < nums.Length; i++) {
            var jumpsToReachI = table[i];
            for (int j = 0; j < nums[i] && j+i+1 < nums.Length; j++) {
                table[j+i+1] = Math.Min(table[j+i+1], jumpsToReachI + 1); 
            }
        }

        return table.Last();
    }
}