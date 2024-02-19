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
    // linear, binary
    // not accepted
    public int GetIndex(ArrayReader reader) {
        var length = reader.Length();
        
        for (int i = 0; i < length - 1; i++) {
            var cmp = reader.CompareSub(i,i, i+1, i+1);
            if (cmp == 1) {
                return i;
            }
            else if (cmp == -1) {
                return i + 1;
            } 
        }

        return -1;
    }
}