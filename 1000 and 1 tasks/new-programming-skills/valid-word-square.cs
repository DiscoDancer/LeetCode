public class Solution {
    public bool ValidWordSquare(IList<string> words) {
        var n = words.Count();
        foreach (var w in words) {
            if (w.Length > n) {
                return false;
            }
        }

        for (var lineIndex = 0; lineIndex < n; lineIndex++) {
            var lineLength = words[lineIndex].Length;
            for (int i = 0; i < lineLength; i++) {
                try {
                    var a = words[lineIndex][i];
                    var b = words[i][lineIndex];

                    if (a != b) {
                        return false;
                    }
                }
                catch (IndexOutOfRangeException e) {
                    return false;
                }
            }
        }

        return true;
    }
}