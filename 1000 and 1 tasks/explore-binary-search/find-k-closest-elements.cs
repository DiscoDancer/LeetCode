public class Solution {

    // в комментах написали, что это хуйня дает l или l - 1
    // почему - непонятно
    public int FindBestIndex(int[] arr, int x) {
        var l = 0;
        var r = arr.Length;

        while (l < r) {
            var m = l + (r-l)/2;

            if (arr[m] >= x) {
                r = m;
            }
            else {
                l = m + 1;
            }
        }

        if (l == 0) {
            return l;
        }
        if (l == arr.Length) {
            return l - 1;
        }

        if (Math.Abs(arr[l-1] - x) <= Math.Abs(arr[l]-x)) {
            return l-1;
        }
        return l;
    }

    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        var bestIndex = FindBestIndex(arr, x);
        var l = bestIndex - 1;
        var r = bestIndex + 1;
        
        var resultCount = 1;

        while (resultCount < k)
        {
            if (l >= 0 && r <= arr.Length - 1)
            {
                if (Math.Abs(arr[l] - x) <= Math.Abs(arr[r] - x))
                {
                    l--;
                }
                else
                {
                    r++;
                }
            }
            else if (l >= 0)
            {
                l--;
            }
            else
            {
                r++; 
            }
            
            resultCount++;
        }

        var result = new List<int>();

        l += 1;
        r -= 1;

        while (l <= r)
        {
            result.Add(arr[l]);
            l++;
        }

        return result;
    }
}