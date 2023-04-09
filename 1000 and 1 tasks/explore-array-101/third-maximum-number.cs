public class Solution {
    // 1 1 2

    private int? max1 = null;
    private int? max2 = null;
    private int? max3 = null;

    private void Proccess(int num) {
            if (max1 == null || num > max1) {
                var tmp = max1;
                max1 = num;
                if (tmp != null)
                    Proccess(tmp.Value);
            }
            else if ((max2 == null ||  num > max2) && max1 != num) {
                var tmp = max2;
                max2 = num;
                                if (tmp != null)
                    Proccess(tmp.Value);
            }
            else if ((max3 == null ||  num > max3) && max2 != num && max1 != num) {
                max3 = num;
            }
    }

    public int ThirdMax(int[] nums) {
        if (nums.Length < 3) {
            return nums.Max();
        }

        foreach (var num in nums) {
            Proccess(num);
        }

        return max3 == null ?  nums.Max() : max3.Value;
    }
}