public class Solution {
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

    public IList<int> AddToArrayForm(int[] num, int k) {
        var list1 = num.ToList();

        var kCopy = k;
        var list2 = new List<int>();
        while (kCopy > 0)  {
            list2.Insert(0, kCopy % 10);
            kCopy /= 10;
        }

        return AddNumBigXY(list1, list2);
    }
}