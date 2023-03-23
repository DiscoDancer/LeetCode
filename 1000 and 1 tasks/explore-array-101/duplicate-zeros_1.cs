public class Solution {
    public void DuplicateZeros(int[] arr) {
        var list = new List<int>();
        for (int i = 0; i < arr.Length && list.Count() < arr.Length; i++) {
            list.Add(arr[i]);
            if (arr[i] == 0) {
                list.Add(arr[i]);
            }
        }

        var min = Math.Min(list.Count(), arr.Length);
        for (int i = 0; i < min; i++) {
            arr[i] = list[i];
        }
    }
}