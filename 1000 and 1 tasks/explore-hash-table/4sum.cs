public class Solution {
    // собрать все возможные суммы за квадрат и положить в табличку
    // пройти по табличке поискать вторую половину
    // собрать все результаты и отфильтровать
    public IList<IList<int>> FourSum(int[] nums, int target) {
        if (nums.Length < 4) {
            return new List<IList<int>>();;
        }

        var result = new Dictionary<string, IList<int>>();

        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                for (int k = j + 1; k < nums.Length; k++) {
                    for (int m = k + 1; m < nums.Length; m++) {
                        if (nums[i] + nums[j] + nums[k] + nums[m] == target) {
                            var key = (new int[] {nums[i],nums[j],nums[k],nums[m]})
                                .OrderBy(x => x)
                                .Select (x => x.ToString())
                                .Aggregate((x,y) => x + y);
                            if (!result.ContainsKey(key)) {
                                result[key] = new List<int>() {nums[i],nums[j],nums[k],nums[m]};
                            }
                        }
                    }
                }
            }
        }

        return result.Values.ToList();
    }
}