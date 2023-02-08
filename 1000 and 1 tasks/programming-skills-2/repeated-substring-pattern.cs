public class Solution {
    // составить табличку ? НЕТ, опять важен порядок
    // сколько разных? 1 -> true
    // есть нечетные? нету -> true
    public bool RepeatedSubstringPattern(string s) {
        for (int size = 1; size <= s.Length / 2; size++) {
            if (s.Length % size != 0)
            {
                continue;
            }
            var times = s.Length / size - 1;
            var all = true;
            for (int time = 0; time < times; time++) {
                for (int i = 0; i < size; i++) {
                    all = all && (s[i] == s[(time+1)*size + i]);
                }
            }
            if (all) {
                return true;
            }
        }

        return false;
    }
}