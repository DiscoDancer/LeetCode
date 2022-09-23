public class Solution {
    public int SubtractProductAndSum(int n) {
        var s = n.ToString().Select(x => (int)(x - '0')).ToArray();
        
        return s.Aggregate((x,y) => x*y) - s.Aggregate((x,y) => x+y);
    }
}