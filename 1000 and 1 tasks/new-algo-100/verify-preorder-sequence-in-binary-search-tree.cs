public class Solution {
    // pre order
    /* 
        cur
        left
        right
    */

    // in order
    /*
        left
        cur
        right
    */

    // arrows
    // preorder -> inorder -> inc == true

    /*
        read x: read all < x, then read all > x left: nothing

        for all x: firstly < x or empty, then > x or empty
    */

    public bool VerifyPreorder(int[] preorder) {
        for (int i = 0; i < preorder.Length; i++) {
            var x = preorder[i];
            var j = i + 1;
            while (j < preorder.Length && preorder[j] < x) {
                j++;
            }
            while (j < preorder.Length && preorder[j] > x) {
                j++;
            }
            if (j < preorder.Length) {
                return false;
            }
        }

        return true;
    }
}