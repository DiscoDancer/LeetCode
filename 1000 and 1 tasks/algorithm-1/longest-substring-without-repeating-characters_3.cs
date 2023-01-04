public class Solution {
    // i и l проверяются из вне
    private bool IsValid(string s, int i, int l) {
        var table = new HashSet<char>();

        for (var j = i; j < i + l; j++) {
            if (table.Contains(s[j])) {
                return false;
            }
            table.Add(s[j]);
        }

        return true;
    }


    /*
        Roadmap:
        + самый тупой перебор
        + оптимизация 1: не смотреть длины больше, если меньшая не проходит
        + оптимизация 2: не смотреть длины меньше максимальной (уже проходит)
        + оптимизация 3: убрать substring
        - оптимизация 4: dictionary/hs (sliding window)
    */    

    // сначала перебор
    public int LengthOfLongestSubstring(string s) {
        if (s.Length == 0) {
            return 0;
        }

        var max = 1;

        for (int i = 0; i < s.Length; i++) {
            // пробуем побить рекорд
            int l = max + 1;
            while ((i + l) <= s.Length && IsValid(s, i, l)) {
                max = l;
                l++;
            }
        }

        return max;
    }
}