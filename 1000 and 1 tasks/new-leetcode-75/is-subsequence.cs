public class Solution {
    // dp перебор вариантов
    // таблица всех индексов
    // или просто итерироваться по этой табличке
    // хотя с dp мне вообще не нужна таблица и просто могу идти по строке

    // удалить тех, кого нет и дубликатов -> просто ищем подстроку
    // как будто бы нет. accbc abc

    // так все хуйня, просто 2 pointers
    public bool IsSubsequence(string s, string t) {
        var ps = 0;
        var pt = 0;

        while (ps < s.Length) {
            while (pt < t.Length && s[ps] != t[pt]) {
                pt++;
            }
            if (pt == t.Length) {
                return false;
            }
            ps++;
            pt++;
        }

        return true;
    }
}