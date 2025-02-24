class Solution {
    // editorial
    public int findPeakElement(int[] nums) {
        var l = 0;
        var r = nums.length - 1;

        while (l < r) {
            var m = l + (r-l)/2;
            if (m == nums.length - 1) {
                return m;
            }

            // если текущий больше, значит он может быть пиком. Не делаем -1
            if (nums[m] > nums[m+1]) {
                r = m;
            }
            // если есть больше, значит текущий точно не подходит
            else if (nums[m] < nums[m+1]) {
                l = m + 1;
            }
            else {
                throw new RuntimeException("Invalid input cant be equals consecutive");
            }
        }

        // почему l показывает ответ? потому что если r = l, то это значит что мы нашли пик
        // l = r иначе мы в цикле
        // можно и r вернуть
        return l;
    }
}