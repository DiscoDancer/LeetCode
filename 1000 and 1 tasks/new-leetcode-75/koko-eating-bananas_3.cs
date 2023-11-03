public class Solution {
    private bool IsSpeedEnough(int[] piles, int h, int speed) {
            long minReuired = 0;
            foreach (var p in piles) {
                double x = p;
                x /= speed;
                minReuired += (int)Math.Ceiling(x);
            }

            return h >= minReuired;               
    }

    public int MinEatingSpeed(int[] piles, int h) {
        var maxSpeed = piles.Max();
        
        var l = 1;
        var r = maxSpeed;

        while (l <= r) {
            var m = l + (r-l)/2;
            var isMEnough = IsSpeedEnough(piles, h, m);
            if (isMEnough) {
                r = m - 1;
            }
            else {
                l = m + 1;
            }
        }



        return l;
    }
}