/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        for (int i = 1; i <= n; i++) {
            if (IsBadVersion(i)) {
                return i;
            }
        }
        
        return -1;
    }
}