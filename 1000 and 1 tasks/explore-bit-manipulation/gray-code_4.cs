public class Solution {
    // editorial
    public List<int> GrayCode(int n) {
        List<int> result = new List<int>();
        grayCodeHelper(result, n);
        return result;
    }

    private void grayCodeHelper(List<int> result, int n) {
        if (n == 0) {
            result.Add(0);
            return;
        }
        // we derive the n bits sequence from the (n - 1) bits sequence.
        grayCodeHelper(result, n - 1);
        int currentSequenceLength = result.Count();
        // Set the bit at position n - 1 (0 indexed) and assign it to mask.
        int mask = 1 << (n - 1);
        for (int i = currentSequenceLength - 1; i >= 0; i--) {
            // mask is used to set the (n - 1)th bit from the LSB of all the numbers present in the current sequence.
            result.Add(result[i] | mask);
        }
    }
}