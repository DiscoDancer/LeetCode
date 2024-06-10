public class Solution {
    // наивный квадрат
    public int HIndex(int[] citations) {
        for (int i = citations.Length; i >= 0; i--) {
            var count = citations.Where(x => x >= i).Count();
            if (count >= i) {
                return i;
            }
        }

        return -1;
    }
}