public class Solution {
    // бить на тройки
    // сортировка
    // хеш таблица
    public int MajorityElement(int[] nums) {
        var sorted = nums.OrderBy(x => x).ToArray();
        return sorted[nums.Length / 2];
    }
}