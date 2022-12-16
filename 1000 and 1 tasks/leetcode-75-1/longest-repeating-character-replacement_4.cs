public class Solution {
    /*
        Roadmap:
        + генерировать подстроки для каждой буквы
        + генерировать подстроки один раз
        + генерировать меньше подстрок (бинарный поиск по длине)
        + оптимизация sliding window (отойти от подстрок и пересчитывать таблицу; second maximum ?)
        + оптимизация не хранить подстроку (уже проходит по времени)
    */

    private bool GenerateSubstringsOfLengthAndValidate(string s, int length, int k) {
        var table = new int[26];
        var max = 0;
        int curCharIndex;
        int prevCharIndex;
        for (int position = 0; position + length <= s.Length; position++) {
            if (position == 0) {
                for (int i = 0; i < length; i++) {
                    curCharIndex = s[i] - 'A';
                    table[curCharIndex]++;
                }
                for (int i = 0; i < 26; i++) {
                    max = Math.Max(max, table[i]);
                }
            }
            else {
                prevCharIndex = s[position - 1] - 'A';
                curCharIndex = s[position - 1 + length] - 'A';
                table[prevCharIndex]--;
                table[curCharIndex]++;

                if (table[curCharIndex] > max) {
                    max = table[curCharIndex];
                }
            }

            if (length - max <= k) {
                return true;
            }
        }

        return false;
    }

    public int CharacterReplacement(string s, int k) {
        // first bad version
        var a = Math.Max(k, 1);
        var b = s.Length;

        while (a <= b) {
            var m = a + (b-a)/2;
            var isMValid = GenerateSubstringsOfLengthAndValidate(s, m, k);
            if (isMValid) {
               a = m + 1;  
            }
            else {
               b = m - 1;
            }
        }

        // a - 1 = указывает на последнюю валидную
        return a-1;
    }
}