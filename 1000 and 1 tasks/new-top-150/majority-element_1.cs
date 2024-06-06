public class Solution {
    // для бинарного нету сортировки, но мб все равно можно
    // вероятно можно посчитать сумму или среднее
    public int MajorityElement(int[] nums) {
        var dictionary = new Dictionary<int,int>();
        var max = 0;
        foreach (var x in nums) {
            if (!dictionary.ContainsKey(x)) dictionary[x] = 0;
            dictionary[x]++;
            max = Math.Max(max, dictionary[x]);
        }

        foreach (var (k,v) in dictionary) {
            if (v == max) {
                return k;
            }
        }

        return -1;
    }
}