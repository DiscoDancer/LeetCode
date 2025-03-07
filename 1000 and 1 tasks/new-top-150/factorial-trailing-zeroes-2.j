class Solution {
    public int trailingZeroes(int n) {

        // 5 1
        // 25 2
        // 125 3
        // 625 4
        // 3125 5
        // 15625 6

        return (n/5)*1 + (n/25)*1 + (n/125)*1 + (n/625)*1 + (n/3125)*1 + (n/15625)*1;
    }
}