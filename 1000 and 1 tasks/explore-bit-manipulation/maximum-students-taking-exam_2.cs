public class Solution {
    private char[][] _seats;
    public const char BROKEN = '#';
    public const char NOT_BROKEN = '.';
    
    private int F(int index, bool[] table)
    {
        var X = _seats.Length;
        var Y = _seats[0].Length;

        var row = index / Y;
        var col = index % Y;

        bool canPlaced = _seats[row][col] == NOT_BROKEN;
        if (canPlaced && col > 0 && table[row * Y + col - 1])
        {
            canPlaced = false;
        }
        
        if (canPlaced && row > 0 && col > 0 && table[(row - 1) * Y + col - 1])
        {
            canPlaced = false;
        }

        if (canPlaced && row > 0 && col < Y - 1 && table[(row - 1) * Y + col + 1])
        {
            canPlaced = false;
        }
        
        if (index == X * Y - 1)
        {
            // какой-то грязный фикс, но с ним работает
            table[row * Y + col] = canPlaced;
            return Calc1(table);
        }

        if (canPlaced)
        {
            table[row * Y + col] = true;
            var v1 = F(index + 1, table);
            table[row * Y + col] = false;

            return Math.Max(v1, F(index + 1, table));
        }

        return F(index + 1, table);
    }

    private int Calc1(bool[] table)
    {
        var count = 0;

        foreach (var a in table)
        {
            if (a)
            {
                count++;
            }
        }

        return count;
    }
    
    public int MaxStudents(char[][] seats)
    {
        _seats = seats;

        var X = seats.Length;
        var Y = seats[0].Length;

        var table = new bool[X * Y];

        return F(0, table);
    }
}