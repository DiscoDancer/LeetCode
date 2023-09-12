/**
 * // This is ArrayReader's API interface.
 * // You should not implement it, or speculate about its implementation
 * class ArrayReader {
 *     public int Get(int index) {}
 * }
 */

// найти длину и сделать обычный бинарный поиск

class Solution {
    private int GetLength(ArrayReader arrayReader)
    {
        // todo find length
        
        var r = 1;

        while (arrayReader.Get(r) != int.MaxValue)
        {
            r *= 2;
        }

        var l = 0;

        while (l <= r)
        {
            var m = l + (r - l) / 2;
            if (arrayReader.Get(m) != int.MaxValue && arrayReader.Get(m + 1) == int.MaxValue)
            {
                return m;
            }

            if (arrayReader.Get(m) != int.MaxValue)
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }

        return -1;
    }


    public int Search(ArrayReader reader, int target) {
        var l = 0;
        var r = GetLength(reader);

        while (l <= r) {
            var m = l + (r-l)/2;
            if (reader.Get(m) == target) {
                return m;
            }

            if (reader.Get(m) < target) {
                l = m + 1;
            }
            else {
                r = m - 1;
            }
        }

        return -1;
    }
}