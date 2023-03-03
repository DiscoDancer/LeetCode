public class Solution {

    public string Multiply(string a, int b)
    {
        var surplus = 0;
        var result = new List<int>();
        for (int i = a.Length - 1; i >= 0; i--)
        {
            var cur = (a[i] - '0') * b + surplus;
            result.Insert(0, cur % 10);
            surplus = cur / 10;
        }
        
        if (surplus > 0)
        {
            result.Insert(0, surplus);
        }

        return string.Join("", result);
    }
    
    public string Sum(string a, string b)
    {
        var maxLength = Math.Max(a.Length, b.Length);
        var surplus = 0;
        var result = new List<int>();
        for (var i = 0; i < maxLength; i++)
        {
            var aIndex = a.Length - 1 - i;
            var bIndex = b.Length - 1 - i;
            
            var fromA = aIndex >= 0 ? a[aIndex] - '0' : 0;
            var fromB = bIndex >= 0 ? b[bIndex] - '0' : 0;
            var cur = fromA + fromB + surplus;
            result.Insert(0, cur % 10);
            surplus = cur / 10;
        }

        if (surplus > 0)
        {
            result.Insert(0, surplus);
        }

        return string.Join("", result);
    }

    public string Multiply(string a, string b)
    {
        if (a == "0" || b == "0")
        {
            return "0";
        }

        var result = "0";
        
        for (var i = b.Length - 1; i >= 0; i--)
        {
            var currentMultiplication = Multiply(a, b[i] - '0');
            for (var j = 0; j < (b.Length - 1) - i; j++)
            {
                currentMultiplication += '0';
            }
            result = Sum(result, currentMultiplication);
        }

        return result;
    }
}