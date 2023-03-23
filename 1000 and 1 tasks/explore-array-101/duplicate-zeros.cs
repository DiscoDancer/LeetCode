public class Solution {
    public void DuplicateZeros(int[] arr) {
        var list = new List<int>();
        foreach (var n in arr) {
            list.Add(n);
            if (n == 0) {
                list.Add(n);
            }
        }

        var min = Math.Min(list.Count(), arr.Length);
        for (int i = 0; i < min; i++) {
            arr[i] = list[i];
        }
    }
}