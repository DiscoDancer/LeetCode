/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int L = 1;
        int R = n;
        
        while (L <= R) {
            if (IsBadVersion(L)) return L;
            
            int M = L + (R- L) / 2;
            
            
            if (!IsBadVersion(M)) {
                L = M + 1;
            }
            else {
                R = M;
            }
        }
        
        return -1;
    }
}