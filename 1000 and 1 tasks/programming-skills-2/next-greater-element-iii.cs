public class Solution {
    // цифры можно табличкой посчитать
    // two pointers {L, R}
    // smallest -> начинаем с конца (последняя и предпоследняя)
    // валидная перестановка = digits[L] < digits[R]

    private string MinimizeString(string str)
    {
        var table = new int[10];
        foreach (var c in str)
        {
            table[c - '0']++;
        }

        var intList = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            while (table[i] > 0)
            {
                intList.Add(i);
                table[i]--;
            }
        }
        
        return string.Join("", intList);
    }

    public int NextGreaterElement(int n) {
        if (n < 10) {
            return -1;
        }
        
        var digits = n.ToString().ToCharArray().Select(x => x - '0').ToArray();
        var L = digits.Length - 2;
        var Rs = new List<int>() {digits.Last()};

        while (L >= 0) {
            var found = Rs.Where(x => x > digits[L]).ToArray();
            if (found.Any()) {
                var minR = found.Min();
                var maxIndex = -1;
                for (int i = digits.Length - 1; i >= 0 && maxIndex < 0; i--)
                {
                    if (digits[i] == minR)
                    {
                        maxIndex = i;
                    }
                }
                var tmp = digits[L];
                digits[L] = minR;
                digits[maxIndex] = tmp;
                
                var str = string.Join("", digits);
                // L - индекс, длина с ним = L + 1
                var a = str.Substring(0, L + 1);
                var b = str.Substring(L + 1, str.Length - (L + 1));

                var ab = a + MinimizeString(b);
                if (digits.Length == "2147483647".Length && ab.CompareTo("2147483647") > 0)
                {
                    return -1; // потому что дальше будет только больше
                }
                
                return int.Parse(ab);
            }

            Rs.Add(digits[L]);
            L--;
        }

        return -1;
    }
}