public class Solution {
    public class Node {
        public int value {get; set;}
        public Node zero {get; set;}
        public Node one {get; set;}
    }

    public Node _root = new Node();

    private int GetMaxLength(int x)
    {
        if (x == 0)
        {
            return 1;
        }
        
        var i = 0;
        while (x > 0)
        {
            x /= 2;
            i++;
        }

        return i;
    }

    private List<char> GetChars(int x, int min)
    {
        var result = new List<char>();
        while (x > 0)
        {
            result.Insert(0, x % 2 == 1 ? '1' : '0');
            x /= 2;
        }

        var diff = min - result.Count();
        for (int i = 0; i < diff; i++)
        {
            result.Insert(0,'0');
        }

        return result;
    }

    private void InsertIntoTree(List<char> chars, int num)
    {
        var cur = _root;
        foreach (var c in chars)
        {
            if (c == '0')
            {
                cur.zero ??= new Node();

                cur = cur.zero;
            }
            else
            {
                cur.one ??= new Node();
                cur = cur.one;
            }
        }

        cur.value = num;
    }
    
    public int FindMaximumXOR(int[] nums)
    {
        var max = nums.Max();
        var maxLength = GetMaxLength(max);
        
        
        foreach (var num in nums)
        {
            var chars = GetChars(num, maxLength);
            InsertIntoTree(chars, num);
        }

        var result = 0;
        
        var queue = new Queue<(Node, Node)>();
        queue.Enqueue((_root, _root));

        while (queue.Any())
        {
            var (pointerA, pointerB) = queue.Dequeue();
            
            // так может быть только на последнем уровне
            if (pointerA.value != 0)
            {
                result = Math.Max(pointerA.value ^ pointerB.value, result);
            }
            
            // 11 01 10 00
            if (pointerA.zero != null)
            {
                if (pointerB.one != null)
                {
                    queue.Enqueue((pointerA.zero, pointerB.one));
                }
                else if (pointerB.zero != null)
                {
                    queue.Enqueue((pointerA.zero, pointerB.zero));
                }
            }
            if (pointerA.one != null)
            {
                if (pointerB.zero != null)
                {
                    queue.Enqueue((pointerA.one, pointerB.zero));
                }
                else if (pointerB.one != null)
                {
                    queue.Enqueue((pointerA.one, pointerB.one));
                }
            }
        }
        
        return result;
    }
}