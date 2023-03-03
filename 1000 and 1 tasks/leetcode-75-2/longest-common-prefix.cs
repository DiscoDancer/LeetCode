public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (strs.Length == 1) {
            return strs[0];
        }
        if (strs.Length == 0) {
            return "";
        }

        var a = strs[0];
        var b = strs[1];
        var list = new List<char>();

        var min = Math.Min(a.Length, b.Length);
        var i = 0;
        while (i < min && a[i] == b[i]) {
            list.Add(a[i++]);
        }

        for (i = 2; i < strs.Length; i++) {
            min = Math.Min(strs[i].Length, list.Count);
            var j = 0;
            while (j < min && strs[i][j] == list[j]) {
                j++;
            }

            var itemsToRemove = list.Count - j;
            for (int k = 0; k < itemsToRemove; k++) {
                list.RemoveAt(list.Count - 1);
            }
        }

        return new string(list.ToArray());
    }
}