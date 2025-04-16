class Solution {
    public int rob(int[] nums) {
        var table = new int[nums.length+2][2];

        for (var i = nums.length - 1; i >= 0; i--) {
            // order can be vice versa ? must be?
            for (var rob0 = 0; rob0 < 2; rob0++) {

                if (i == 0) {
                    var rob = nums[i]  + table[i+2][1];
                    var notRob = table[i+1][0];
                    table[i][rob0] = Math.max(rob, notRob);
                }
                else if (i == nums.length - 1) {
                    if (rob0 == 0) {
                        // если может, всегда лучше грабить
                        table[i][rob0] = nums[i];
                    }
                    else {
                        table[i][rob0] = 0;
                    }

                }
                else {
                    var rob = nums[i] + table[i+2][rob0];
                    var notRob = table[i+1][rob0];

                    table[i][rob0] = Math.max(rob, notRob);
                }
            }
        }

        return Math.max(table[0][0], table[0][1]);
    }
}
