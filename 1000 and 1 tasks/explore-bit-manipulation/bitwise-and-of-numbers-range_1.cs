public class Solution {
    /*
 * Умный метод:
 * первый 0, % 2 == 0, если не левый, то длина минимум 2
 * второй 0, % 4 < 2, если не левый, то считаем сколько надо
 * третий 0, % 8 < 4, если не левый, то считаем сколько надо
 */
    public int RangeBitwiseAnd(int left, int right)
    {
        if (left == 0 || right == 0)
        {
            return 0;
        }
        
        var list = new List<int>();
        var x = left;
        while (x > 0)
        {
            list.Insert(0, x % 2);
            x /= 2;
        }

        for (int i = list.Count() - 1; i >= 0; i--)
        {
            if (list[i] == 0)
            {
                continue;
            }
            
            var cur2 = (long)1 << list.Count() - i;
            var max = (long)1 << list.Count() - i - 1;

            var remaining = left % cur2;
            if (remaining < max)
            {
                list[i] = 0;
            }
            else
            {
                var required = ((long)cur2 - remaining) + left;
                if (required <= right)
                {
                    list[i] = 0;
                }
            }
        }

        var result = 0;
        for (int i = list.Count() - 1; i >= 0; i--)
        {
            result += list[i] * (1 << list.Count() - i - 1);
        }

        return result;
    }
}