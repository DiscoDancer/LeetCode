public class Solution {    
    public bool HasAnyBetweenIncluding(int[] arr, int min, int max) {
        var l = 0;
        var r = arr.Length - 1;
        
        var res = false;
        
        while (l <= r && !res) {
            var m = l + (r - l) / 2;
            if (arr[m] >= min && arr[m] <= max) {
                res = true;
            }
            else if (arr[m] > max) {
                r = m - 1;
            }
            else if (arr[m] < min) {
                l = m + 1;
            }
        }
        
        return res;
    }
        
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) {
        var bb = arr2.ToList();
        bb.Sort();
        
        var arr2Sorted = bb.ToArray();
        
        int total = arr1.Length;
        
        // просто ищем в окрестности каждой точки
        for (int i = 0; i < arr1.Length; i++) {
            var res = HasAnyBetweenIncluding(arr2Sorted, arr1[i] - d,arr1[i] + d);
            if (res) {
                total--;
                continue;
            }
        }
        
        return total;
    }
}