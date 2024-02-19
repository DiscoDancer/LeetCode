/**
 * // This is ArrayReader's API interface.
 * // You should not implement it, or speculate about its implementation
 * class ArrayReader {
 *     // Compares the sum of arr[l..r] with the sum of arr[x..y] 
 *     // return 1 if sum(arr[l..r]) > sum(arr[x..y])
 *     // return 0 if sum(arr[l..r]) == sum(arr[x..y])
 *     // return -1 if sum(arr[l..r]) < sum(arr[x..y])
 *     public int CompareSub(int l, int r, int x, int y) {}
 *
 *     // Returns the length of the array
 *     public int Length() {}
 * }
 */

class Solution {
    public int GetIndex(ArrayReader reader) {
        var length = reader.Length();
        var L = 0;
        var R = length - 1;

        while (L <= R)
        {
            if (L == R)
            {
                return L;
            }
            if (R - L == 1)
            {
                var cmp = reader.CompareSub(L, L, R, R);
                if (cmp == 1)
                {
                    return L;
                }
                if (cmp == -1)
                {
                    return R;
                }
                
                return -1;
            }
            else
            {
                var M = L + (R-L)/2;
                var leftSize = (M - 1) - L;
                var rightSize = (R) - (M + 1);
                if (leftSize == rightSize)
                {
                    var cmp = reader.CompareSub(L, M-1, M + 1, R);
                    if (cmp == 0) {
                        return M;
                    }
                    else if (cmp == 1) {
                        R = M -1;
                    }
                    else if (cmp == -1) {
                        L = M + 1;
                    }
                }
                else if (leftSize < rightSize)
                {
                    var cmp = reader.CompareSub(L, M, M + 1, R);
                    if (cmp == 1)
                    {
                        R = M;
                    }
                    else
                    {
                        L = M;
                    }
                }
                else if (rightSize > leftSize)
                {
                    var cmp = reader.CompareSub(L, M-1, M, R);
                    if (cmp == 1)
                    {
                        R = M;
                    }
                    else
                    {
                        L = M;
                    }
                }
            }
        }
        
        return -1;
    }
}