public class Solution {
    // trie of dic, дальше перебор
    // перебор: дошли до конца слова: 1. рекурсивно вызвались от подстроки остатка 2. продолжили идти
    // если кто-то из них дошел, то true

    public const int Size = 26;

    public class Node {
        public Node[] Children {get; set;} = new Node[Size];
        public bool IsWord {get; set;} = false;
    }

    public Node Root {get; set;}

    private void FillTrie(IList<string> wordDict) {
        var root = new Node();
        foreach (var word in wordDict) {
            var p = root;
            for (int i = 0; i < word.Length; i++) {
                var letter = word[i];
                if (p.Children[letter-'a'] == null) {
                    p.Children[letter-'a'] = new Node();
                }
                p = p.Children[letter-'a'];
                if (i == word.Length - 1) {
                    p.IsWord = true;
                }
            }
        }

        Root = root;
    }

    private bool Result {get; set;} = false;
    private bool[] Mem {get; set; }

    private void Check(string s, int start) {
        if (Result || Mem[start]) {
            return;
        }

        Mem[start] = true;
        var p = Root;

        for (int i = start; i < s.Length; i++) {
            var c = s[i];
            if (p.Children[c - 'a'] == null) {
                return;
            }
            p = p.Children[c - 'a'];
            if (i == s.Length - 1 && p.IsWord) {
                Result = true;
            }
            else if (p.IsWord) {
                Check(s, i + 1);
            }
        }
    }

    public bool WordBreak(string s, IList<string> wordDict) {
        // без меморизации считается по несколько раз и TL
        Mem = new bool[s.Length];
        FillTrie(wordDict);
        Check(s, 0);
        

        return Result;
    }
}