public class Solution {
    // https://leetcode.com/problems/ugly-number-ii/solutions/69372/java-solution-using-priorityqueue/
    public int NthUglyNumber(int n) {
        var set = new SortedSet<long>();
        set.Add(1);

        for (int i = 0; i < n - 1; i++) {
            var first = set.First();
            set.Remove(first);

            set.Add(first*2);
            set.Add(first*3);
            set.Add(first*5);
        }

        return (int) set.First();
    }
}