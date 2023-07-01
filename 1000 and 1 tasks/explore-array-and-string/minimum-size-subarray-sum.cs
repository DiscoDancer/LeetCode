public class Solution {
    // просто перебор
    // суммы посчитать заранее

    // какие свойста вывести. Если массив ок, то его над массив тоже ок.
    // мб если рассмотреть весь, то тогда будем просто отсекать слева и справа по тихоньку
    // должно получиться

    // out of memory
    public int MinSubArrayLen(int target, int[] nums) {
        long sum = 0;
        foreach (var n in nums) {
            sum += n;
        }

        if (sum < target) {
            return 0;
        }

        var result = nums.Length;

        var queue = new Queue<(int l, int r, long s)>();
        queue.Enqueue((0, nums.Length - 1, sum));

        while (queue.Any()) {
            var (l, r, s) = queue.Dequeue();
            result = Math.Min(r-l+1, result);

            // пробуем убрать слева
            if (l+1 <= r && l+1 < nums.Length && s - nums[l] >= target) {
                queue.Enqueue((l+1, r, s - nums[l]));
            }
            // пробуем убрать справа
            if (r-1 >= l && r-1 >= 0 && s - nums[r] >= target) {
                queue.Enqueue((l, r-1, s - nums[r]));
            }
        }

        return result;
    }
}