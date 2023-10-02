public class Solution {
    // умножить на число
    public string MultiplyX(string s, int x)
    {
        if (x == 1) return s;
        if (x == 0) return "0";

        var surplus = 0;
        var sb = new StringBuilder();

        for (int i = s.Length - 1; i >= 0; i--)
        {
            var aNum = s[i] - '0';
            var res = surplus + aNum * x;
            sb.Insert(0, res % 10);
            surplus = res / 10;
        }

        if (surplus > 0)
        {
            sb.Insert(0, surplus);
        }

        return sb.ToString();
    }
    
    public string Sum(string a, string b)
    {
        if (b.Length > a.Length) {
            return Sum(b,a);
        }
        
        var minLength = Math.Min(a.Length, b.Length);
        var surplus = 0;

        var sb = new StringBuilder();

        var i = 0;

        for (i = 0; i < minLength; i++) {
            var ai = a.Length - 1 - i;
            var bi = b.Length - 1 - i;

            var aNum = a[ai] - '0';
            var bNum = b[bi] - '0';

            var res = aNum + bNum + surplus;
            sb.Insert(0, res % 10);
            surplus = res / 10;
        }
        
        i = a.Length - minLength - 1;
        while (i >= 0) {

            var aNum = a[i] - '0';
            var res = aNum + surplus;
            sb.Insert(0, res % 10);
            surplus = res / 10;

            i--;
        }
        
        if (surplus > 0) {
            sb.Insert(0, surplus);
        }
        
        return sb.ToString();
    }

    public string AddNZeroes(string s, int n)
    {
        var sb = new StringBuilder(s);
        for (int i = 0; i < n; i++)
        {
            sb.Append('0');
        }

        return sb.ToString();
    }

    // a.length >= b.length
    public string Multiply(string num1, string num2) {
        if (num2.Length > num1.Length) {
            return Multiply(num2,num1);
        }

        if (num2 == "0" || num1 == "0")
        {
            return "0";
        }

        string? res = null;

        for (int i = num2.Length - 1; i >= 0; i--)
        {
            var digit = num2[i] - '0';
            var num1_x_digit = MultiplyX(num1, digit);
            var num1_x_digit_zeroes = AddNZeroes(num1_x_digit, num2.Length - 1 - i);

            if (res == null)
            {
                res = num1_x_digit_zeroes;
            }
            else
            {
                res = Sum(res, num1_x_digit_zeroes);
            }
        }

        return res;
    }
}