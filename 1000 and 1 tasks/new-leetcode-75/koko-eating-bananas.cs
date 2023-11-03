public class Solution {
    // TL
    public int MinEatingSpeed(int[] piles, int h) {
        var maxSpeed = piles.Max();
        for (int speed = 1; speed <= maxSpeed; speed++) {
            var copy = piles.OrderBy(x => x).ToArray();
            for (int i = 0; i < h; i++) {
                for (int j = 0; j < piles.Length; j++) {
                    if (copy[j] > 0) {
                        copy[j] -= speed;
                        break;
                    }
                }
            }
            if (copy.All(x => x <= 0)) {
                return speed;
            }
        }

        return -1;
    }
}