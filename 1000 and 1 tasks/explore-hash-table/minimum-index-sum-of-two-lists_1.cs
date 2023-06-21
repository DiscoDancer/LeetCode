public class Solution {
    public string[] FindRestaurant(string[] list1, string[] list2) {
        // это чтобы словарь был меньше
        if (list1.Length > list2.Length) {
            return FindRestaurant(list2, list1);
        }

        var dictionary = new Dictionary<string, int>();
        for (var i = 0; i < list1.Length; i++) {
            var s = list1[i];
            if (!dictionary.ContainsKey(s)) {
                dictionary[s] = i;
            }
        }

        var record = int.MaxValue;
        var result = new List<string>();

        for (var i = 0; i < list2.Length; i++) {
            var s = list2[i];
            if (dictionary.ContainsKey(s)) {
                var newRecord = i + dictionary[s];
                if (newRecord == record) {
                    result.Add(s);
                }
                else if (newRecord < record) {
                    record = newRecord;
                    result = new List<string>() {s};
                }
            }
        }
        
        return result.ToArray();
    }
}