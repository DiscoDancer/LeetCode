public class Solution {

    private List<char> _digits;

    public List<int> AddNumBigXY(List<int> num1, List<int> num2) {
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
        num1[index1] = result % 2;

        if (index1 == 0 && result > 1)
        {
            num1.Insert(0, result / 2);
        }
        else if (index1 > 0)
        {
            AddNumBigXY(index1 - 1, index2-1, num1, num2, result / 2);
        }
    }



    public string AddBinary(string a, string b) {
        var list1 = a.ToCharArray().Select(x => x - '0').ToList();
        var list2 = b.ToCharArray().Select(x => x - '0').ToList();

        var res = AddNumBigXY(list1, list2);
        return string.Join("", res);
    }
}