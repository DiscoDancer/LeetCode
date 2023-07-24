public class Solution {
    // полный перебор
    // порядок не важен

    private int _max = 0;

    private void F(List<int> list, int acc) {
        if (!list.Any()) {
            _max = Math.Max(_max, acc);
        }

        foreach (var n in list) {
            var newList = new List<int>();
            var sum = 0;
            foreach (var i in list) {
                if (Math.Abs(i-n) > 1) {
                    newList.Add(i);
                }
                if (i == n) {
                    sum += n;
                }
            }
            F(newList, sum + acc);
        }
    }

    // TL
    public int DeleteAndEarn(int[] nums) {
        F(nums.ToList(), 0);

        return _max;
    }
}