public class Solution {
    // четный = основа ""
    // нечетный = основа 0 1 8
    // дальаше навешиваем буквы
    public IList<string> FindStrobogrammatic(int n) {
        var bases = n % 2 == 1 ? 
            new List<(string s, bool allZeroes)>() {("1", false), ("8", false), ("0", true)} :
            new List<(string s, bool allZeroes)>() {("", false)};
        var length = 1;

        while (length < n) {
            List<(string s, bool allZeroes)> newGen = new();
            foreach (var (s, allZeroes) in bases) {
                newGen.Add(($"1{s}1", false));
                newGen.Add(($"0{s}0", s == "" ? true : allZeroes)); // ???
                newGen.Add(($"8{s}8", false));
                newGen.Add(($"6{s}9", false));
                newGen.Add(($"9{s}6", false));
            }

            bases = newGen;
            length += 2;
        }

        // todo filter out only zeroes
        // todo sb and meta info for zeroes

        return bases.Where(x => n == 1 || (x.s[0] != '0')).Select(x => x.s).ToArray();
    } 
}