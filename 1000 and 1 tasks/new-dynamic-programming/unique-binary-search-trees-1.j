import java.util.*;

/**
Почему это вообще работает?
 
 С базовыми кейсами все ок.
 Дальше корень может быть любым числом от 1 до n. Он и им и будет.
 Влево уходит то, что меньше корня, вправо то, что больше. Значит мы можем замкнуть систему рекурсией.
 
 То есть пример с 3.
 
 корень 1
    слева будет 0
    справа будет 2: 2,3
 
 F(0) должен быть 1, иначе все сломается. Для корня 1, будет F(0)*F(2)
 Дальше идем по остальным корням.
 
 Умножение потому что перебор всех вариантов.
 */

class Solution {
    private int F(int n) {
        if (n == 1) {
            return 1;
        }
        if (n == 2) {
            return 2;
        }
        if (n == 3) {
            return 5;
        }

        var result = 0;

        for (var i = 1; i <= n; i++) {
            var leftCount = i - 1;
            var rightCount = n - i;
            result += Math.max(F(leftCount), 1) * Math.max(F(rightCount), 1);
        }

        return result;
    }

    public int numTrees(int n) {
        return F(n);
    }
}