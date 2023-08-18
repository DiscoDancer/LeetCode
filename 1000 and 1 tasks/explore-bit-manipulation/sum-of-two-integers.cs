using System.Text;

namespace ConsoleApp1;

// знак определить отдельно

public class CurTask
{
    // a-b и a > b
    public int GetAMinusB(int a, int b)
    {
        var listA = new List<int>();
        while (a > 0) {
            listA.Add(a % 2);
            a = a/2;
        }

        var listB = new List<int>();
        while (b > 0) {
            listB.Add(b % 2);
            b = b/2;
        }

        var debt = 0;
        
        var result = new List<int>();
        var i = 0;
        for (i = 0; i < listB.Count(); i++)
        {
            var curDigit =
                listA[i] == 1 && listB[i] == 0 && debt == 0 ||
                listA[i] == 0 && listB[i] == 1 && debt == 0 ||
                listA[i] == 0 && listB[i] == 0 && debt == 1 ||
                listA[i] == 1 && listB[i] == 1 && debt == 1
                    ? 1
                    : 0;
            result.Insert(0, curDigit);
            debt =
                listA[i] == 0 && listB[i] == 1 || 
                listA[i] == 0 && listB[i] == 0 && debt == 1
                    ? 1
                    : 0;
        }

        for (; i < listA.Count(); i++)
        {
            var curDigit =
                listA[i] == 0 && debt == 1 || listA[i] == 1 && debt == 0 ? 1 : 0;
            result.Insert(0, curDigit);
            debt = listA[i] == 0 && debt == 1 ? 1 : 0;
        }
        
        return Convert(result);
    }

    private int Convert(List<int> result)
    {
        var num = 0;
        for (int j = result.Count() - 1; j >= 0; j--)
        {
            num += result[j] * 1 << (result.Count() - 1 - j);
        }

        return num;
    }

    public int GetSum(int a, int b)
    {
        if (a >= 0 && b >= 0)
        {
            return GetSumAB(a, b);
        }
        else if (a < 0 && b < 0)
        {
            return GetSumAB(Math.Abs(a), Math.Abs(b)) * (-1);
        }
        else if (a == 0)
        {
            return b;
        }
        else if (b == 0)
        {
            return a;
        }

        var max = Math.Max(a,b);
        var min = Math.Min(a,b);
        var minus = Math.Abs(min) > Math.Abs(max);

        return GetAMinusB(Math.Max(Math.Abs(a), Math.Abs(b)), Math.Min(Math.Abs(a), Math.Abs(b))) * (minus ? (-1) : 1);
    }
    
    public int GetSumAB(int a, int b) {
        if (b > a) {
            return GetSumAB(b,a);
        }

        var listA = new List<int>();
        while (a > 0) {
            listA.Add(a % 2);
            a = a/2;
        }

        var listB = new List<int>();
        while (b > 0) {
            listB.Add(b % 2);
            b = b/2;
        }

        var surplus = 0;

        var result = new List<int>();

        var i = 0;
        for (i = 0; i < listB.Count(); i++) {
            var curDigit = (listA[i] != listB[i] && surplus == 0) || (listA[i] == listB[i] && surplus == 1) ? 1 : 0;
            result.Insert(0, curDigit);
            surplus = listA[i] != listB[i] && surplus == 1 || listA[i] == 1  && listB[i] == 1 ? 1 : 0; 
        }

        for (; i < listA.Count(); i++)
        {
            var curDigit = (listA[i] ^ surplus) == 1 ? 1 : 0;
            result.Insert(0, curDigit);
            surplus = listA[i] == 1  && surplus == 1 ? 1 : 0;
        }

        if (surplus == 1)
        {
            result.Insert(0,surplus);
        }

        return Convert(result);
    }

}