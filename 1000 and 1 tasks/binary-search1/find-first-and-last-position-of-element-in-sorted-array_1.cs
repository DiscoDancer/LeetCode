public class Solution {
    // a идет вверх, b идет вниз
    // задачу с 1 я уже решал
    
    // нет смысла отправлять а или b обратно, это будет сложнее
    // можно рассмтреть как задача куда вставить 2 раза.
    public int[] SearchRange(int[] nums, int target) {
        var a = 0;
        var b = nums.Length - 1;
        
        var found = false;
        
        while (a <= b) {
            var m = a + (b-a)/2;
            
            if (!found && nums[m] == target) {
                found = true;
            }

            if (nums[m] >= target) {
                b = m - 1;
            }
            else if (nums[m] < target) {
                a = m + 1;
            }
        }
        
        if (!found) {
            return new int[] {-1, -1};
        }
        
        var y = b +1;
        
        a = 0;
        b = nums.Length - 1;
        
        while (a <= b) {
            var m = a + (b-a)/2;
            
            if (nums[m] <= target) {
                a = m + 1;
            }
            else if (nums[m] > target) {
                b = m - 1;
            }
        }
        
        var x = a - 1;
        
        return new int[] {y, x};
        
    }
}