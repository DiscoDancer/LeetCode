public class Solution {

    public int gcd(int x, int y) {
        if (y == 0) {
            return x;
        } else {
            return gcd(y, x % y);
        }    
    }

    // editorial
    public string GcdOfStrings(string str1, string str2) {
        // Check if they have non-zero GCD string.
        if (!(str1 + str2).Equals(str2 + str1)) {
            return "";
        }
        
        // Get the GCD of the two lengths.
        int gcdLength = gcd(str1.Length, str2.Length);
        return str1.Substring(0, gcdLength);
    }
}