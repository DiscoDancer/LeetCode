public class Solution {
    /*
        Roadmap:
        + генерировать подстроки для каждой буквы
        + генерировать подстроки один раз
        + генерировать меньше подстрок (бинарный поиск по длине)
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

    public int CharacterReplacement(string s, int k) {
        // first bad version

        var a = Math.Max(k, 1);
        var b = s.Length;

        while (a <= b) {
            var m = a + (b-a)/2;
            var isMValid = GenerateSubstringsOfLength(s, m)
                            .Any(x => IsSubstringValid(x, k));
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