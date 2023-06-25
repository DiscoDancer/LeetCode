public class Solution {
    // собрать все возможные суммы за квадрат и положить в табличку
    // пройти по табличке поискать вторую половину
    // собрать все результаты и отфильтровать

    // Суть в том, что за счет HT мы делаем вместо n4 - n3
    public IList<IList<int>> FourSum(int[] nums, int target) {
        if (nums.Length < 4) {
            return new List<IList<int>>();;
        }

        var result = new Dictionary<string, IList<int>>();

        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                long newTarget = (long)target - (long)nums[i] - (long)nums[j];
                var hs = new HashSet<long>();
                for (int k = j + 1; k < nums.Length; k++) {
                    long cur = nums[k];
                    if (hs.Contains(newTarget-cur)) {
                        // add to result
                         var key = (new long[] {nums[i],nums[j],cur,newTarget-cur})
                          .OrderBy(x => x)
                          .Select (x => x.ToString())
                            .Aggregate((x,y) => x + y);
                            if (!result.ContainsKey(key))  {
                                var d = newTarget-cur;
                                result[key] = new List<int>() {nums[i],nums[j],(int)cur,(int)d};
                            }
                    }
                    hs.Add(cur);
                }
            }
        }

        return result.Values.ToList();
    }
}