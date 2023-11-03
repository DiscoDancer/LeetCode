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
        for (int speed = 1; speed <= maxSpeed; speed++) {
            if (IsSpeedEnough(piles, h, speed)) {
                return speed;
            }
        }

        return -1;
    }
}