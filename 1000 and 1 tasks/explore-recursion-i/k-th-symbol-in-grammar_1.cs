public class Solution {
    public int KthGrammar(int n, int k)
    {
        // 0 based now
        n = n - 1;
        k = k - 1;

        var count = Math.Pow(2, n);
        if (k >= count)
        {
            return -1;
        }
        if (k == 0)
        {
            return 0;
        }

        var path = new List<int>();
        var x = k;
        // если делим на 2, то попадаем на правильного родителя, потому что количество всегда умножается на 2
        while (x > 0)
        {
            path.Insert(0, x);
            x /= 2;
        }

        var prev = 0;
        foreach (var node in path)
        {
            // это видно по рисунку
            if (prev == 0)
            {
                if (node % 2 == 1)
                {
                    prev = 1;
                }
                else if (node % 2 == 0)
                {
                    prev = 0;
                }
            }
            else if (prev == 1)
            {
                if (node % 2 == 1)
                {
                    prev = 0;
                }
                if (node % 2 == 0)
                {
                    prev = 1;
                }
            }
        }

        return prev;
    }
}