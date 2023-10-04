public class Solution {
    public bool ValidWordSquare(IList<string> words) {
        var n = words.Count();

        for (var lineIndex = 0; lineIndex < n; lineIndex++) {
            var lineLength = words[lineIndex].Length;
            if (lineLength > n) {
                return false;
            }
            for (int i = 0; i < lineLength; i++) {
                if (words[lineIndex].Length <= i || words[i].Length <= lineIndex) {
                    return false;
                }
                var a = words[lineIndex][i];
                var b = words[i][lineIndex];

                if (a != b) {
                    return false;
                }
            }
        }

        return true;
    }
}