public class Solution {

    // Case perm = применяем маски, но их надо сгенерировать. Можно перебирать +1 делая. Плюс подрялк, минус хз как сделать дёшево. Можно генерировать по другому, () - (0) (1) -  00 01 10 11. Просто char перебираем и приписываем и 1 и 0

    private List<bool>[] Generate(List<bool> x) {
        var a = x.ToList();
        a.Add(true);

        var b = x.ToList();
        b.Add(false);

        return new [] {a, b};
    }

    private List<List<bool>> GetMasks(int lettersCount) {
        var masks = new List<List<bool>>();

        masks.Add(new List<bool>() { true });
        masks.Add(new List<bool>() { false });

        for (int i = 1; i < lettersCount; i++) {
            masks = masks.SelectMany(Generate).ToList();
        }

        return masks;
    }

    public IList<string> LetterCasePermutation(string s) {
        var lettersCount = s.ToCharArray().Count(x => Char.IsLetter(x));
        if (lettersCount == 0) {
            return new List<string>() {s};
        }

        var masks = GetMasks(lettersCount);

        var res = new List<string>(); 

        // todo apply masks

        foreach(var mask in masks) {
            var ss = s.ToCharArray();
            var letterIndex = 0;

            for (int i = 0; i < ss.Length; i++) {
                if (!Char.IsLetter(ss[i])) {
                    continue;
                }

                ss[i] = mask.ElementAt(letterIndex) ? Char.ToLower(ss[i]) : Char.ToUpper(ss[i]);

                letterIndex++;
            }

            res.Add(new string(ss));
        }

        return res;
    }
}