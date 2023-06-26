public class ValidWordAbbr {
    private string GetWordAbbr(string word) {
        if (word.Length < 3) {
            return word;
        }

        var sb = new StringBuilder();
        sb.Append(word[0]);
        sb.Append(word.Length - 2);
        sb.Append(word[word.Length - 1]);

        return sb.ToString();
    }

    // can replace list to hashset
    private Dictionary<string, string> _table = new ();

    // если 2 разных слова, то все ломается и можно уже ничего не хранить
    public ValidWordAbbr(string[] dictionary) {
        foreach (var word in dictionary) {
            var abr = GetWordAbbr(word);
            if (!_table.ContainsKey(abr)) {
                _table[abr] = word;
            }
            else if (_table[abr] != word) {
                _table[abr] = null;
            }
        }
    }
    
    public bool IsUnique(string word) {
        var abr = GetWordAbbr(word);
        if (!_table.ContainsKey(abr)) {
            return true;
        }

        return _table[abr] == word;
    }
}

/**
 * Your ValidWordAbbr object will be instantiated and called as such:
 * ValidWordAbbr obj = new ValidWordAbbr(dictionary);
 * bool param_1 = obj.IsUnique(word);
 */