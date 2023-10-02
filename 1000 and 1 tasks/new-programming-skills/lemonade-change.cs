public class Solution {
    public bool LemonadeChange(int[] bills) {
        var money5 = 0;
        var money10 = 0;

        foreach (var b in bills) {
            if (b == 5) {
                money5++;
            }
            else if (b == 10) {
                if (money5 < 1) {
                    return false;
                }
                money5--;
                money10++;
            }
            else if (b == 20) {
                if (money5 >= 3 || money10 >= 1 && money5 >= 1) {
                    if (money10 >= 1 && money5 >= 1) {
                        money10--;
                        money5--;
                    }
                    else {
                        money5 -= 3;
                    }
                }
                else {
                    return false;
                }
            }
        }

        return true;
    }
}