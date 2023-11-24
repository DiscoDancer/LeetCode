public class Solution {
    // это сортировка nlog + доп память (не обязательно)
    // min0 max 0 min 1 max 1
    // читать по 2-3 числа
    // toggle state

    public const int LESS_OR_EQUAL = 42;
    public const int BIGGER_OR_EQUAL = 43;

    public void WiggleSort(int[] nums) {
        if (nums.Length == 1) {
            return;
        }

        if (nums.Length == 2) {
            if (nums[1] < nums[0]) {
                var tmp = nums[1];
                nums[1] = nums[0];
                nums[0] = tmp;
            }
            return;
        }


        // читаем по 3
        var state = LESS_OR_EQUAL;
        for (int i = 0; i < nums.Length - 2; i++) {
            var a = nums[i];
            var b = nums[i+1];
            var c = nums[i+2];

            var max = Math.Max(Math.Max(a,b), c);
            var min = Math.Min(Math.Min(a,b), c);
            var middle = a + b + c - max - min;

            // var arr = new int[] {a,b,c}.OrderBy(x => x).ToArray();
            if (state == LESS_OR_EQUAL) {
                nums[i] = min;
                nums[i+1] = max;
                nums[i+2] = middle;
                state = BIGGER_OR_EQUAL;
            }
            else if (state == BIGGER_OR_EQUAL) {
                nums[i] = max;
                nums[i+1] = min;
                nums[i+2] = middle;
                state = LESS_OR_EQUAL;
            }
        }

        // return nums;
    }
}