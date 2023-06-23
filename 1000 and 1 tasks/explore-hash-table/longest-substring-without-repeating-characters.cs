public class Solution {
    // самый тупой способ перебирать все подстроки и проверять их
    // тогда куб, но если не пересчитывать таблицу, то квадрат
    // если окно увеличилось, оно уже не должно уменьшиться то есть пробовать его увеличить
    public int LengthOfLongestSubstring(string s) {
        if (s.Length < 2) {
            return s.Length;
        }

        // can be replace with bool[1024] ?
        // char -> index
        var table = new Dictionary<char, List<int>>();

        var L = 0;
        var R = 0;
        table[s[0]] = new List<int>() {0};
        // оно не будет уменьшаться, поэтому оно ответ
        var windowSize = 1;


        while (R < s.Length - 1) {
            var isWindowValid = table.Count() == windowSize;
            var nextChar = s[R + 1];
             // если окно валидное, то пробуем расширить
            if (isWindowValid && !table.ContainsKey(nextChar)) {
                table[nextChar] = new List<int>() {R+1};
                windowSize++;
                R++;
            }
            // иначе смещаемтся
            else {
                table[s[L]].Remove(L);
                if (table[s[L]].Count() == 0) {
                    table.Remove(s[L]);
                }
                if (table.ContainsKey(nextChar)) {
                    table[nextChar].Add(R+1);
                }
                else {
                    table[nextChar] = new List<int>() {R+1};
                }
                L++;
                R++;
            }
        }

        return windowSize;
    }
}