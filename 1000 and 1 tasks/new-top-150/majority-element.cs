public class Solution {
    // для бинарного нету сортировки, но мб все равно можно
    // вероятно можно посчитать сумму или среднее
    public int MajorityElement(int[] nums) {
        // no mem square

        foreach (var x in nums) {
            var count = 0;
            foreach (var y in nums) {
                if (x == y) count++;
            }
            if (count > nums.Length/2) {
                return x;
            }
        }

        return -1;
    }
}