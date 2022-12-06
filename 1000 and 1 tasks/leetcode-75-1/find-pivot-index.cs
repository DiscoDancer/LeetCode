public class Solution {
    // посчитать 2 суммы отдельно и выбрать
    // 2 pointers
    // значения маленькие
    // решить same
    // что там с четностью?

    /*
        Roadmap:
        - посчитать 2 суммы отдельно и выбрать
        - 2 pointers
    */
    public int PivotIndex(int[] nums) {
        int n = nums.Length;

        var beg = new int[n];
        var end = new int[n];

        beg[0] = nums[0];
        end[n-1] = nums[n - 1];

        for (int i = 1; i < n; i++ ) {
            beg[i] = nums[i] + beg[i-1];
        }
        for (int i = n - 2; i >= 0; i--) {
            end[i] = nums[i] + end[i+1];
        }

        for (int i = 0; i < n; i++) {
            if (beg[i] == end[i]) {
                return i;
            }
        }

        return -1;
    }
}