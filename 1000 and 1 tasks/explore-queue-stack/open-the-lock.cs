public class Solution {
    private int GetPlus(int x) {
        if (x >= 0 && x <= 8) {
            return x + 1;
        }
        return 0;
    }

    private int GetMinus(int x) {
        if (x >= 1 && x <= 9) {
            return x - 1;
        }
        return 9;
    }

    private (int a, int b, int c, int d)[] Generate(int a, int b, int c, int d) {
        var arr = new (int a, int b, int c, int d)[8];

        arr[0] = (GetPlus(a), b, c, d);
        arr[1] = (GetMinus(a), b, c, d);

        arr[2] = (a, GetPlus(b), c, d);
        arr[3] = (a, GetMinus(b), c, d);

        arr[4] = (a, b, GetPlus(c), d);
        arr[5] = (a, b, GetMinus(c), d);

        arr[6] = (a, b, c, GetPlus(d));
        arr[7] = (a, b, c, GetMinus(d));

        return arr;
    }

    private (int a, int b, int c, int d) Parse(string s) {
            var a = s[0] - '0';
            var b = s[1] - '0';
            var c = s[2] - '0';
            var d = s[3] - '0';
            return (a,b,c,d);
    }

    public int OpenLock(string[] deadends, string target)
    {
        var hashSet = new HashSet<(int a, int b, int c, int d)>();
        var parsedTarget = Parse(target);
        foreach (var s in deadends)
        {
            hashSet.Add(Parse(s));
        }

        var start = (0, 0, 0, 0);

        if (start == parsedTarget)
        {
            return 0;
        }

        var queue = new Queue<(int a, int b, int c, int d)>();
        if (!hashSet.Contains(start))
        {
            queue.Enqueue(start);
        }
        
        var steps = 1;
        while (queue.Any())
        {
            var size = queue.Count();
            for (int i = 0; i < size; i++)
            {
                var (a, b, c, d) = queue.Dequeue();

                // a + 1 -> if not in hashSet -> if target return steps | else add into hs 
                // a - 1

                var arr = Generate(a, b, c, d);
                foreach (var combo in arr)
                {
                    if (!hashSet.Contains(combo))
                    {
                        if (combo == parsedTarget)
                        {
                            return steps;
                        }

                        hashSet.Add(combo);
                        queue.Enqueue(combo);
                    }
                }
            }

            steps++;
        }

        return -1;
    }
}