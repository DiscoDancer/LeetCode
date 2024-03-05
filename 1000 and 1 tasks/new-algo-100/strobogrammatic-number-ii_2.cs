public class Solution {
    public IList<string> FindStrobogrammatic(int n) {
        var bases = n % 2 == 1 ? new List<StringBuilder>()
        {
            new StringBuilder("1"), new StringBuilder("8"), new StringBuilder("0")
        } : new List<StringBuilder>() {new StringBuilder()};
        var length = 1;

        while (length < n) {
            List<StringBuilder> newGen = new();
            foreach (var b in bases)
            {
                var sb1 = new StringBuilder(b.Length);
                sb1.Append(b);
                sb1.Insert(0, '1');
                sb1.Append('1');
                newGen.Add(sb1);
                
                var sb0 = new StringBuilder(b.Length);
                sb0.Append(b);
                sb0.Insert(0, '0');
                sb0.Append('0');
                newGen.Add(sb0);
                
                var sb8 = new StringBuilder(b.Length);
                sb8.Append(b);
                sb8.Insert(0, '8');
                sb8.Append('8');
                newGen.Add(sb8);
                
                var sb69 = new StringBuilder(b.Length);
                sb69.Append(b);
                sb69.Insert(0, '6');
                sb69.Append('9');
                newGen.Add(sb69);
                
                var sb96 = new StringBuilder(b.Length);
                sb96.Append(b);
                sb96.Insert(0, '9');
                sb96.Append('6');
                newGen.Add(sb96);
            }

            bases = newGen;
            length += 2;
        }
        
        // no leading zeroes
        return bases.Where(x => n == 1 || x[0] != '0').Select(x => x.ToString()).ToArray();
    } 
}