public class Solution {
    // числа либо с плюсом либо с минусом
    // гегерируем все варианты
    // идем бинарным поиском
    // биты байты
    // сортировочка nums чтобы заработало

    // too slow
    public int FindTargetSumWays(int[] nums, int target) {
        var strings = new List<string>() {""};
        for (int i = 0; i < nums.Length; i++) {
            strings = strings.SelectMany(x => new [] {x + "+", x + "-"}).ToList();
        }
        var result = 0;

        foreach (var s in strings) {
            var sum = 0;
            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '+') {
                    sum += nums[i];
                }
                else {
                    sum -= nums[i];
                }
            }
            if (sum == target) {
                result++;
            }
        }

        return result;  
    }
}