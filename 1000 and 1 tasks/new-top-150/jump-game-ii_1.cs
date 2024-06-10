public class Solution {
    // нужно делать что-то типа priority queue BFS, пытаться улететь на одном прыжке
    public int Jump(int[] nums) {
        // на сколько мы можем допрыгнуть за сколько прыжков
        var tableJumpCountToMaxDistanceIncluding = new int[nums.Length];
        tableJumpCountToMaxDistanceIncluding[0] = 0;
        var jumpCount = 0;

        for (int i = 0; i < nums.Length; i++) {
            // если не может добраться до текущего прыгаем еще
            while (tableJumpCountToMaxDistanceIncluding[jumpCount] < i) {
                jumpCount++;
            }

            // update max
            if (jumpCount + 1 < nums.Length) {
                tableJumpCountToMaxDistanceIncluding[jumpCount+1] = Math.Max(
                    tableJumpCountToMaxDistanceIncluding[jumpCount+1],
                    i + nums[i]
                );
            }
        }


        return jumpCount;
    }
}