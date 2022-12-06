public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        const int AlphabetSize = 128;

        // массив списков
        var tableS = new List<int>[AlphabetSize];
        for (int i = 0; i < AlphabetSize; i++) {
            tableS[i] = new List<int>();
        }
        for (int i = 0; i < s.Length; i++) {
            tableS[s[i] - 0].Add(i);
        }

        // второй можно не считать, а сразу проверять
        var tableT = new List<int>[AlphabetSize];
        for (int i = 0; i < AlphabetSize; i++) {
            tableT[i] = new List<int>();
        }
        for (int i = 0; i < t.Length; i++) {
            tableT[t[i] - 0].Add(i);
        }

        var listsS = tableS.Where(x => x.Any()).ToArray();
        var listsT = tableT.Where(x => x.Any()).ToArray();

        if (listsS.Count() != listsT.Count()) {
            return false;
        }

        for (int i = 0; i < listsS.Length; i++) {
            var foundIndex = -1;
            for (int j = 0; j < listsT.Length && foundIndex < 0; j++) {
                if (listsT[j] != null && Enumerable.SequenceEqual(listsS[i], listsT[j])) {
                    foundIndex = j;
                }
            }
            if (foundIndex < 0) {
                return false;
            }
            listsT[foundIndex] = null;
        }

        return true;
    }
}