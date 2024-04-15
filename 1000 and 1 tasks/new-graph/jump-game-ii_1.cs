public class Solution {
    public int Jump(int[] nums) {
        // todo сделать за квадрат, потом подумать

        var result = new int[nums.Length];
        Array.Fill(result, int.MaxValue);
        result[0] = 0;

        for (int i = 0; i < nums.Length; i++) {
            var baseResult = result[i];
            for (int j = 1; j <= nums[i] && i + j < nums.Length; j++) {
                // если мы заполнили, то это уже минимум
                // дальше заполняя, мы не улучшим
                if (result[i+j] == int.MaxValue) {
                    result[i+j] = baseResult + 1;
                }
            }
        }

        return result.Last();
    }
}