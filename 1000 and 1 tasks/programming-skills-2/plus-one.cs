public class Solution {
    private List<int> _digits;

    private void Increment(int index) {
        if (_digits[index] != 9) {
            _digits[index]++;
        }
        else {
             _digits[index] = 0;
            if (index == 0) {
                _digits.Insert(0,1);
            }
            else {
                Increment(index - 1);
            }
        }
    }

    public int[] PlusOne(int[] digits) {
        _digits = digits.ToList();
        Increment(digits.Length - 1);

        return _digits.ToArray();
    }
}