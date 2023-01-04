public class Solution {

    private bool IsValid(string s) {
        var table = new HashSet<char>();

        foreach (var c in s) {
            if (table.Contains(c)) {
                return false;
            }
            table.Add(c);
        }

        return true;
    }


    /*
        Roadmap:
        + самый тупой перебор
        + оптимизация 1: не смотреть длины больше, если меньшая не проходит
        + оптимизация 2: не смотреть длины меньше максимальной (уже проходит)
    */    

    // сначала перебор
    public int LengthOfLongestSubstring(string s) {
        if (s.Length == 0) {
            return 0;
        }

        var max = 1;

        for (int i = 0; i < s.Length; i++) {
            // пробуем побить рекорд
            for (int l = max + 1; (i + l) <= s.Length ; l++) {
                var sub = s.Substring(i, l);
                if (IsValid(sub)) {
                    max = l;
                }
                else {
                    break;
                }
            }
        }

        return max;
    }
}