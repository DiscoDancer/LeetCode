/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        var l = 1;
        var r = n;

        while (l <= r) {
            var m = l + (r-l)/2;

            if (IsBadVersion(m)) {
                if (m == 1 || !IsBadVersion(m-1)) {
                    return m;
                }
                r = m - 1;
            }
            else {
                l = m + 1;
            }
        }

        return -1;
    }
}