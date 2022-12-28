public class Solution {
    public int SumOddLengthSubarrays(int[] arr) {
        var N = arr.Length;
        var list = new List<(int sum, int index)>();

        var total = 0;

        // gen 1
        for (int i = 0; i < N; i++) {
            list.Add((arr[i], i));
            total += arr[i];
        }

        // gen 2 and more
        for (int gen = 2; gen <= N; gen++) {
            var newList = new List<(int sum, int index)>();

            foreach (var p in list) {
                var (sum, index) = p;
                var newIndex = index + (gen - 1);
                if (newIndex <= N - 1) {
                    newList.Add((sum + arr[newIndex], index));
                }
            }

            if (gen % 2 == 1) {
                total += newList.Select(x => x.sum).Sum();
            }

            list = newList;
        }
        
        return total;
    }
}