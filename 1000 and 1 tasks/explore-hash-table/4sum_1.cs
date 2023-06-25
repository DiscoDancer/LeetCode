public class Solution
{
    private IList<IList<int>>  EMPTY_RESULT = new List<IList<int>>();

    // TL
    public IList<IList<int>> FourSum(int[] nums, int target) {
        if (nums.Length < 4) {
            return EMPTY_RESULT;
        }

        var sumToPair = new Dictionary<int, List<(int, int)>>();
        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                var sum = nums[i] + nums[j];
                if (!sumToPair.ContainsKey(sum)) {
                    sumToPair[sum] = new ();
                }
                sumToPair[sum].Add((i,j));
            }
        }

        var result = new Dictionary<string, IList<int>>();

        foreach (var firstHalf in sumToPair.Keys) {
            var secondHalf = target - firstHalf;
            // 3 + 5 -- 1 + 7
            // 2 + 2 + 2 + 2
            if (firstHalf == secondHalf) {
                var list = sumToPair[firstHalf];
                if (list.Count() == 1) {
                    continue;
                }

                for (int i = 0; i < list.Count(); i++) {
                    for (int j = i + 1; j < list.Count(); j++) {
                        var (a,b) = list[i];
                        var (c,d) = list[j];
                        // if no intersection
                        if (a != c && a != d && b != c && b != d) {
                            var key = (new int[] {nums[a],nums[b],nums[c],nums[d]})
                                .OrderBy(x => x)
                                .Select (x => x.ToString())
                                .Aggregate((x,y) => x + y);
                            if (!result.ContainsKey(key)) {
                                result[key] = new List<int>() {nums[a],nums[b],nums[c],nums[d]};
                            }
                        }
                    }
                }
            }
            else if (!sumToPair.ContainsKey(secondHalf)) {
                continue;
            }
            else {
                var list1 = sumToPair[firstHalf];
                var list2 = sumToPair[secondHalf];
                for (int i = 0; i < list1.Count(); i++) {
                    for (int j = 0; j < list2.Count(); j++) {
                        var (a,b) = list1[i];
                        var (c,d) = list2[j];
                        // if no intersection
                        if (a != c && a != d && b != c && b != d) {
                            var key = (new int[] {nums[a],nums[b],nums[c],nums[d]})
                                .OrderBy(x => x)
                                .Select (x => x.ToString())
                                .Aggregate((x,y) => x + y);
                            if (!result.ContainsKey(key)) {
                                result[key] = new List<int>(){nums[a],nums[b],nums[c],nums[d]};
                            }
                        }
                    }
                }
            }
        }

        return result.Values.ToList();
    }
}