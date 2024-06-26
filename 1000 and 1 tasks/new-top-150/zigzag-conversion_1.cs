public class Solution {
    public string Convert(string s, int numRows) {
        var table = new char[numRows, s.Length];

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < s.Length; j++) {
                table[i,j] = '-';
            }
        }

        // full cycle = down + diagonal
        var columnIndex = 0;
        for (int i = 0; i < s.Length; i++) {
            // down
            for (var li = 0; li < numRows && i < s.Length; li++) {
                table[li, columnIndex] = s[i++];
            }
            columnIndex++;
            
            var lineIndex = numRows - 2; // prev last
            while (lineIndex > 0 && columnIndex < s.Length && i < s.Length)
            {
                table[lineIndex--, columnIndex++] = s[i++];
            }
            i--;
        }

        var result = new StringBuilder();
        
        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < s.Length; j++)
            {
                if (table[i, j] != '-')
                    result.Append(table[i, j]);
            }
        }

        return result.ToString();
    }
}