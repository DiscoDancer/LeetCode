public class Solution {
    // префиксы, сортировка
    // решить в лоб

    private int[] _nums;
    private bool _result = false;

    private void F(int index, List<int> list1, List<int> list2, int sum1, int sum2) {
        if (_result) {
            return;
        }
        if (index == _nums.Length) {
            if (sum1 == sum2) {
                _result = true;
            }
            return;
        }

        var curNumber = _nums[index];

        // put in 1
        list1.Add(curNumber);
        F(index + 1, list1, list2, sum1 + curNumber, sum2);
        list1.RemoveAt(list1.Count() - 1);

        // put in 2
        list2.Add(curNumber);
        F(index + 1, list1, list2, sum1, sum2 + curNumber);
        list2.RemoveAt(list2.Count() - 1);
    }


    // TL
    public bool CanPartition(int[] nums) {
        if (nums.Sum() % 2 == 1) {
            return false;
        }

        _nums = nums;

        F(0, new List<int>(), new List<int>(), 0, 0);

        return _result;
    }
}