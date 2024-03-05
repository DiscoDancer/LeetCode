public class Solution {
    public IList<string> FindStrobogrammatic(int n) {
        var bases = n % 2 == 1 ? new List<string>() {"1", "8", "0"} : new List<string>() {""};
        var length = 1;

        while (length < n) {
            List<string> newGen = new();
            foreach (var b in bases) {
                newGen.Add($"1{b}1");
                newGen.Add($"0{b}0");
                newGen.Add($"8{b}8");
                newGen.Add($"6{b}9");
                newGen.Add($"9{b}6");
            }

            bases = newGen;
            length += 2;
        }
        
        // no leading zeroes
        return bases.Where(x => n == 1 || x[0] != '0').ToArray();
    } 
}