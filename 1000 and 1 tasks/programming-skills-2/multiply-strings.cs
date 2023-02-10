public class Solution {
    public List<int> _num1 = new ();

    public void MultiplyNumX(List<int> num, int index, int x, int surplus = 0) {
        var result = num[index] * x + surplus;

        num[index] = result % 10;
        
        if (index == 0 && result > 9) {
            num.Insert(0, result / 10);
        } else if (index > 0) {
            MultiplyNumX(num, index - 1, x, result / 10);
        }
    }
    
    public List<int> AddNumBigXY(List<int> num1, List<int> num2)
    {
        var big = num1.Count >= num2.Count ? num1 : num2;
        var small = num1 == big ? num2 : num1;

        var bigCopy = big.ToList();
        
        AddNumBigXY(bigCopy.Count - 1, small.Count - 1, bigCopy, small);

        return bigCopy;
    }
    
    public void AddNumBigXY(
        int index1,
        int index2,
        List<int> num1,
        List<int> num2,
        int surplus = 0)
    {
        var fromNum2 = index2 >= 0 ? num2[index2] : 0;

        var result = num1[index1] + surplus + fromNum2;
        num1[index1] = result % 10;

        if (index1 == 0 && result > 9)
        {
            num1.Insert(0, result / 10);
        }
        else if (index1 > 0)
        {
            AddNumBigXY(index1 - 1, index2-1, num1, num2, result / 10);
        }
    }

    public string Multiply(string num1, string num2) {
        if (num1 == "0" || num2 == "0") {
            return "0";
        }

        foreach (var c in num1) {
            _num1.Add(c - '0');
        }
        
        var res = _num1.ToList();
        
        for (int i = num2.Length - 1; i >= 0; i--)
        {
            if (i == num2.Length - 1)
            {
                MultiplyNumX(res, num1.Length - 1, num2[i] - '0');
            }
            else
            {
                var localRes = _num1.ToList();
                MultiplyNumX(localRes, num1.Length - 1, num2[i] - '0');
                for (int j = 0; j < Math.Abs(i - num2.Length + 1); j++)
                {
                    localRes.Add(0);
                }

                res = AddNumBigXY(res, localRes);
            }
        }
        
        return string.Join("", res);
    }
}