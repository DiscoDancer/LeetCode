public class Solution {
    public uint reverseBits(uint n) {
        var list = new List<int>();

        var x = n;

        while (x > 0)
        {
            list.Insert(0, x % 2 == (uint)1 ? 1 : 0);
            x /= 2;
        }

        while (list.Count() < 32)
        {
            list.Insert(0, 0);
        }

        uint result = 0;

        list.Reverse();
        for (int i = 0; i < 32; i++)
        {
            if (list[i] == 1)
            {
                result += ((uint)1) << 32-i -1 ;
            }
        }

        return result;
    }
}