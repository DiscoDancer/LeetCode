class Solution {
    public int searchInsert(int[] nums, int target) {

        var n = nums.length;

        var l = 0;
        var r = n - 1;

        // нужно найти последний меньше или равный, да
        // навеное где-то не надо делать +1-1

        while (l <= r) {
            var m = l + (r - l) / 2;
            // нашли точно
            if (nums[m] == target) {
                return m;
            }
            // нашли место вставки
            else if (nums[m] < target && (m == n - 1 || nums[m + 1] > target)) {
                return m + 1;
            }
            // если он меньше, он нам точно не подходит, смело делаем +1
            // не подходит потому что если бы подходил, условие сверху бы выполнилось
            else if (nums[m] < target) {
                l = m + 1;
            }
            // если он больше, он нам точно не подходит, смело делаем -1
            else if (nums[m] > target) {
                r = m - 1;
            }
        }

        return 0;
    }
}