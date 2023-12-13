public class Solution {
    public IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper) {
        var result = new List<IList<int>>();

        // его может и не быть
        // null - пустой, иначе минимум уже включенный
        int? current = null;

        for (int i = 0; i < nums.Length; i++) {
            // слишком маленькие и слишком большие номера нас не интересуют
            if (nums[i] < lower || nums[i] > upper) {
                continue;
            }
            else if (nums[i] == lower) {
                current = nums[i];
            }
            else if (nums[i] > lower) {
                if (current == null) {
                    result.Add(new List<int>() {lower, nums[i]-1});
                    current = nums[i];
                }
                else if (nums[i] > current.Value) {
                    if (nums[i] - current.Value > 1) {
                        result.Add(new List<int>() {current.Value + 1, nums[i]-1});
                    }
                    current = nums[i];
                }
            }
        }

        // не одно число не подошло
        if (current == null) {
            result.Add(new List<int>() {lower, upper});
        }
        else if (current.Value < upper) {
            result.Add(new List<int>() {current.Value + 1 , upper});
        }

        return result;
    }
}