public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var result = new int[rowIndex + 1];
        for (int i = 0; i < rowIndex + 1; i++)
        {
            var prev = result[0];
            for (int j = 1; j < i; j++)
            {
                var cur = result[j];
                var res = cur + prev;
                prev = cur;
                result[j] = res;
            }
            result[i] = 1;
        }

        return result;
    }
}