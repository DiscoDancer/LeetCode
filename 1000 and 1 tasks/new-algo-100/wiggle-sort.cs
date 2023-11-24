public class Solution {
    // это сортировка nlog + доп память (не обязательно)
    // min0 max 0 min 1 max 1
    // читать по 2-3 числа
    // toggle state

    public const int LESS_OR_EQUAL = 42;
    public const int BIGGER_OR_EQUAL = 43;

    // passes
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

            var arr = new int[] {a,b,c}.OrderBy(x => x).ToArray();
            if (state == LESS_OR_EQUAL) {
                nums[i] = arr[0];
                nums[i+1] = arr[2];
                nums[i+2] = arr[1];
                state = BIGGER_OR_EQUAL;
            }
            else if (state == BIGGER_OR_EQUAL) {
                nums[i] = arr[2];
                nums[i+1] = arr[0];
                nums[i+2] = arr[1];
                state = LESS_OR_EQUAL;
            }
        }

        // return nums;
    }
}