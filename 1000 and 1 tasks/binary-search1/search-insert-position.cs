public class Solution {
    // мб случай когда a = b
    public int SearchInsert(int[] nums, int target) {
        int a = 0;
        int b = nums.Length - 1;
        
        while (a <= b) {
            int m = a + (b-a)/2;
            if (nums[m] > target) {
                b = m - 1;
            }
            else if (nums[m] < target) {
                a = m + 1;
            }
            else {
                return m;
            }
        }
        
        // крайние случаи, не серединка
        // они не могут быть равны? вроде нет
        
        // всегда true
        // if (a > b) {
        //     return b + 1;
        // }
        
        return b + 1;
        
        // и такого быть не может
        // if (a < b) {
        //     return 0;
        // }
        
        // случай, что не найдет
        // a мб больше b, мб равен, а мб меньше
        
        // return -1;
    }
}