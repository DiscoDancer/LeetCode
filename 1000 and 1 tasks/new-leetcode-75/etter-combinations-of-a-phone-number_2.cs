public class Solution {
    private char[] GetChars(char x) {
        switch (x) {
            case '2': 
                return new char[] {'a','b','c'};
            case '3': 
                return new char[] {'d','e','f'};
            case '4': 
                return new char[] {'g','h','i'};
            case '5': 
                return new char[] {'j','k','l'};
            case '6': 
                return new char[] {'m','n','o'};
            case '7': 
                return new char[] {'p','q','r', 's'};
            case '8': 
                return new char[] {'t','u','v'};
            case '9': 
                return new char[] {'w','x','y', 'z'};
        }

        throw new Exception();
    }

    public IList<string> LetterCombinations(string digits) {
        var lists = new List<List<char>>();
        if (digits.Length > 0) {
            lists.Add(new List<char>(){});
        }

        for (int i = 0; i < digits.Length; i++) {
            var newLists = new List<List<char>>();

            var chars = GetChars(digits[i]);

            foreach (var list in lists) {
                foreach (var c in chars) {
                    var copy = list.ToList();
                    copy.Add(c);
                    newLists.Add(copy);
                }
            }

            lists = newLists;
        }

        return lists.Select(x => new string(x.ToArray())).ToList();
    }
}