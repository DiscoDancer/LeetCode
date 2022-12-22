public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var res = new List<IList<int>>();

        var prev = new List<int>() {1};
        res.Add(prev);

        for (int i = 2; i <= numRows; i++) {
            var curList = new List<int>();
            for (int j = 0; j < i; j++) {
                if (j == 0 || j == i -1) {
                    curList.Add(1);
                }
                else {
                    curList.Add(prev.ElementAt(j - 1) + prev.ElementAt(j));
                }
            }

            res.Add(curList as IList<int>);
            prev = curList;
        }

        return res;
    }
}