public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        var dictionary = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            var n = nums[i];
            if (dictionary.ContainsKey(n)) {
                var j = dictionary[n];
                if (Math.Abs(i-j) <= k) {
                    return true;
                }
            }
            dictionary[n] = i;
        }

        /*
            Почему не надо хранить все индексы?
            Потому что индексы строго увеличиваются и разница будет только возрастать.
            То есть она будет минимальна с последним из издексов.
        */

        return false;
    }
}