public class Solution {
    public IList<string> LetterCasePermutation(string s) {
        var lettersCount = s.ToCharArray().Count(x => Char.IsLetter(x));
        if (lettersCount == 0) {
            return new List<string>() {s};
        }


        var res = new List<string>(); 

        // todo apply masks

        var masksCount = 1 << lettersCount;

        for (int mask = 0; mask < masksCount; mask++) {
            var ss = s.ToCharArray();
            var letterIndex = 0;

            for (int i = 0; i < ss.Length; i++) {
                if (!Char.IsLetter(ss[i])) {
                    continue;
                }

                ss[i] = ( (mask >> letterIndex & 1) == 1) ? Char.ToLower(ss[i]) : Char.ToUpper(ss[i]);

                letterIndex++;
            }

            res.Add(new string(ss));
        }

        return res;
    }
}