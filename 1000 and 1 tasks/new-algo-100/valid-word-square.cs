public class Solution {
    public bool ValidWordSquare(IList<string> words) {
        for (int wordIndex = 0; wordIndex < words.Count(); wordIndex++) {
            var currentWord = words[wordIndex];
            for (int charIndex = 0; charIndex < currentWord.Length; charIndex++) {
                // точно есть
                var charFromLine = currentWord[charIndex];
                // мб нету
                if (charIndex >= words.Count()) {
                    return false;
                }
                if (wordIndex >= words[charIndex].Length) {
                    return false;
                }
                var charFromColumn = words[charIndex][wordIndex];
                if (charFromLine != charFromColumn) {
                    return false;
                }
            }
        }

        return true;
    }
}