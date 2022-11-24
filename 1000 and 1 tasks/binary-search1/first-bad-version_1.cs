/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        var a = 1;
        var b = n;
        
        while (a <= b) {
            var m = a + (b-a)/2;
            if (!IsBadVersion(m)) {
                a = m + 1;
            }
            else {
                b = m - 1;
            }
        }
        
        return b + 1;
    }
}