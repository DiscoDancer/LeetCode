public class Solution {
    // sliding window (если строка длинная, то тогда 26 операций всего)
    // просто табличка не канает потому последовательность важна
    // я могу хранить индексы и выдать motostic array


    public bool AreSame(string needle, List<char> listHaystack)
    {
        var all = true;
        for (int i = 0; i < needle.Length && all; i++)
        {
            all = all && (needle[i] == listHaystack[i]);
        }

        return all;
    }

    public int StrStr(string haystack, string needle) {
        if (needle.Length > haystack.Length) {
            return -1;
        }

        const int ALPHABET_SIZE = 26;

        var listHaystack = new List<char>();
        for (int i = 0; i < needle.Length; i++) {
            listHaystack.Add(haystack[i]);
        }

        if (AreSame(needle, listHaystack))
        {
            return 0;
        }
        
        var diff = haystack.Length - needle.Length;
        for (int i = 0; i < diff; i++) {
            // удалить первую
            listHaystack.RemoveAt(0);
            // добавить последнюю
            listHaystack.Add(haystack[needle.Length + i]);

            if (AreSame(needle, listHaystack))
            {
                return i + 1;
            }
        }

        return -1;
    }
}