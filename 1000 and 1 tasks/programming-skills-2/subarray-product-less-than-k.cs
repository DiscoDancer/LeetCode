// TL
public class Solution {
    // полный перебор куб
    // если идти с конца = лучше? хз
    // мелкие все равно надо проверять
    // оптимизация sliding window (пересчет / первый * последний)
    // если мы нашли массив длины какой-то, то по формуле прибавить и нахуй выкинуть?
    // потому что 2 2 2 2 2 2 и 8 я могу наслонять их друг на друга
    // форумула f(3) = 1 + 2 + 3

    /*
        Roadmap:
        - n3
        - n3 optimized calc
    */

    public bool IsValid(int[] nums, int k, int a, int b) {
        var product = 1;
        for (int i = a; i <= b; i++) {
            product *= nums[i];
            if (product >= k) {
                return false;
            }
        }

        return product < k;
    }

    // так, не ебемся и просто находим все, потом оптимизируем
    // наслоение = ОК 
    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        var count = 0;
        // 1 2 3 n = 3 length = 2 maxStart = 1 (n - length)   
        var n = nums.Length;
        for (var length = n; length > 0; length--) {
            for (var startIndex = 0; startIndex <= n - length; startIndex++) {
                var endIndex = startIndex + length - 1;
                if (IsValid(nums, k, startIndex, endIndex)) {
                    count++;
                }
            }
        }

        return count;
    }
}