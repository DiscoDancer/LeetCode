public class Solution {
    public int[] PlusOne(int[] digits) {
        var list = new List<int>();

        var surplus = 1;
        for (int i = digits.Length - 1; i >= 0; i--) {
            var sum = digits[i] + surplus;
            var digit = sum % 10;
            surplus = sum / 10;
            list.Insert(0, digit);
        }

        if (surplus > 0) {
            list.Insert(0, surplus);
        }

        return list.ToArray();
    }
}