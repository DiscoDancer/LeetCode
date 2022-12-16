public class Solution {
    /*
        Roadmap:
        + генерировать подстроки для каждой буквы
        + генерировать подстроки один раз
        + генерировать меньше подстрок (бинарный поиск по длине)
        + оптимизация sliding window (отойти от подстрок и пересчитывать таблицу; second maximum ?)
    */

    private List<string> GenerateSubstringsOfLength(string s, int length) {
        var list = new List<string>();
        for (int position = 0; position + length <= s.Length; position++) {
                list.Add(s.Substring(position, length));
        }

        return list;
    }
    
    private bool IsSubstringValid(string sub, int k) {
        var mostPopularCount = GetMostPopularCount(sub);
        var countRest = sub.Length - mostPopularCount;
        return countRest <= k;
    }

    private int GetMostPopularCount (string s) {
        var table = new char[26];

        var max = 0;

        foreach(var c in s) {
            var i = c - 'A';
            table[i]++;
            if (table[i] > max) {
                max = table[i];
            }
        }

        return max;
    }

    private bool GenerateSubstringsOfLengthAndValidate(string s, int length, int k) {
        var table = new int[26];
        var max = 0;
        int curCharIndex;
        int prevCharIndex;
        for (int position = 0; position + length <= s.Length; position++) {
            var sub = s.Substring(position, length);
            if (position == 0) {
                foreach (var c in sub) {
                    curCharIndex = c - 'A';
                    table[curCharIndex]++;
                    
                    if (table[curCharIndex] > max) {
                        max = table[curCharIndex];
                    }
                }
            }
            else {
                prevCharIndex = s[position - 1] - 'A';
                curCharIndex = sub.Last() - 'A';
                table[prevCharIndex]--;
                table[curCharIndex]++;

                if (table[curCharIndex] > max) {
                    max = table[curCharIndex];
                }
            }

            if (sub.Length - max <= k) {
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