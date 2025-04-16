class Solution {
    public int rob(int[] nums) {
        // var table = new int[nums.length+2][2];

        var prevPrevRob = 0;
        var prevRob = 0;
        var prevPrevNotRob = 0;
        var prevNotRob = 0;

        for (var i = nums.length - 1; i >= 0; i--) {
            // order can be vice versa ? must be?
            for (var rob0 = 0; rob0 < 2; rob0++) {
                var cur = 0;

                if (i == 0) {
                    var rob = nums[i]  + prevPrevRob;
                    var notRob = prevNotRob;
                    cur = Math.max(rob, notRob);
                }
                else if (i == nums.length - 1) {
                    if (rob0 == 0) {
                        // если может, всегда лучше грабить
                        cur = nums[i];
                    }
                    else {
                        cur = 0;
                    }

                }
                else {
                    var rob = nums[i] + (rob0 == 0 ? prevPrevNotRob : prevPrevRob);
                    var notRob = (rob0 == 0 ? prevNotRob : prevRob);

                    cur = Math.max(rob, notRob);
                }

                // not rob
                if (rob0 == 0) {
                    prevPrevNotRob = prevNotRob;
                    prevNotRob = cur;
                }
                // rob
                else {
                    prevPrevRob = prevRob;
                    prevRob = cur;
                }
            }
        }

        return Math.max(prevRob, prevNotRob);
    }
}
