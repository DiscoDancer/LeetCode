public class Solution {
    private char[][] _seats;
    public const char BROKEN = '#';
    public const char NOT_BROKEN = '.';

    private bool Read(ulong table, int index)
    {
        return ((table >> index) & 1) == 1;
    }


    private void Write(ref ulong table, int index, bool val)
    {
        if (val)
        {
            table |= ((ulong)1 << index);
        }
        else {
            table &= (~((ulong)1 << index));
        }
    }

    private Dictionary<(int, ulong), int> _mem = new();
    
    private int F(int index, ulong table)
    {
        if (_mem.ContainsKey((index, table)))
        {
            return _mem[(index, table)];
        }
        
        var X = _seats.Length;
        var Y = _seats[0].Length;

        var row = index / Y;
        var col = index % Y;

        bool canPlaced = _seats[row][col] == NOT_BROKEN;
        if (canPlaced && col > 0 && Read(table, row * Y + col - 1))
        {
            canPlaced = false;
        }
        
        if (canPlaced && row > 0 && col > 0 && Read(table, (row - 1) * Y + col - 1))
        {
            canPlaced = false;
        }

        if (canPlaced && row > 0 && col < Y - 1 && Read(table, (row - 1) * Y + col + 1))
        {
            canPlaced = false;
        }
        
        if (index == X * Y - 1)
        {
            // какой-то грязный фикс, но с ним работает
            Write(ref table, row * Y + col, canPlaced);
            return Calc1(table);
        }

        if (canPlaced)
        {
            Write(ref table, row * Y + col, true);
            var v1 = F(index + 1, table);
            Write(ref table, row * Y + col, false);
            
            _mem[(index, table)] = Math.Max(v1, F(index + 1, table));

            return _mem[(index, table)];
        }
        
        _mem[(index, table)] = F(index + 1, table);

        return _mem[(index, table)];
    }

    private int Calc1(ulong table)
    {
        var count = 0;
        while (table > 0)
        {
            if (table % 2 == 1)
            {
                count++;
            }

            table /= 2;
        }

        return count;
    }
    
    // out of mem
    public int MaxStudents(char[][] seats)
    {
        _seats = seats;
        
        return F(0, 0);
    }
}