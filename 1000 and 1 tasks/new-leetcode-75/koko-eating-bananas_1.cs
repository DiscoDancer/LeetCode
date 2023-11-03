public class Solution {
    // TL still
    public int MinEatingSpeed(int[] piles, int h) {
        var maxSpeed = piles.Max();
        for (int speed = 1; speed <= maxSpeed; speed++) {
            // is enough?

            long minReuired = 0;
            foreach (var p in piles) {
                double x = p;
                x /= speed;
                minReuired += (int)Math.Ceiling(x);
            }

            if (h >= minReuired) {
                return speed;
            }
        }

        return -1;
    }
}