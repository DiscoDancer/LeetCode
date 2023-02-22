public class Solution {
    // each lemonade costs $5
    // customer pays: 5 or 10 or 20
    // у меня нету сдачи

    // Алгоритм: 
    public bool LemonadeChange(int[] bills) {
        var table = new Dictionary<int, int>();
        table[5] = 0;
        table[10] = 0;
        table[20] = 0;

        foreach (var b in bills) {
            table[b]++;
            if (b != 5) {
                if (b == 20) {
                    if (table[10] > 0) {
                        table[10]--;
                        if (table[5] > 0) {
                            table[5]--;
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        if (table[5] >= 3) {
                            table[5] -=3;
                        }
                        else {
                            return false;
                        }
                    }
                }
                else if (b == 10) {
                    if (table[5] > 0) {
                        table[5]--;
                    }
                    else {
                        return false;
                    }
                }
            }
        }

        return true;
    }
}