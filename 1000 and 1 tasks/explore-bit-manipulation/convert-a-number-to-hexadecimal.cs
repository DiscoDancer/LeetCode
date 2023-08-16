public class Solution {
    // todo negative

    public char GetChar(long x) {
        switch (x) {
            case < 10:
                return (char) (x + (long)'0');
            case 10:
                return 'a'; 
            case 11:
                return 'b'; 
            case 12:
                return 'c'; 
            case 13:
                return 'd'; 
            case 14:
                return 'e';
            case 15:
                return 'f'; 
        }

        throw new Exception();
    }

    // Дополнительный код для отрицательного числа можно получить инвертированием его двоичного модуля и прибавлением к инверсии единицы,

    public string ToHexMinus(long num) {
        var list = new List<long>();
        long x = Math.Abs(num);

        while (x > 0) {
            list.Insert(0, x % 16);
            x /= 16;
        }

        while (list.Count() < 8)
        {
            list.Insert(0, 0);
        }

        list = list.Select( i => 15 - i).ToList();

        // todo +1
        for (int i = 7; i >= 0; i--) {
            list[i]++;
            if (list[i] <= 15) {
                break;
            }
            else
            {
                list[i] = 0;
            }
        }

        var sb = new StringBuilder();

        var k = 0;
        while (list[k] == 0) {k++;}

        for (int i = k; i < 8; i++) {
            sb.Append(GetChar(list[i]));
        }

        return sb.ToString();
    }

    public string ToHex(int num) {
        if (num == 0) {
            return "0";
        }

        if (num < 0) {
            return ToHexMinus(num);
        }

        var sb = new StringBuilder();
        var x = num;

        while (x > 0) {
            sb.Insert(0, GetChar(x % 16));
            x /= 16;
        }

        return sb.ToString();
    }
}