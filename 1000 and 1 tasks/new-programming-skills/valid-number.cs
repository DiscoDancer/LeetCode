public class Solution {
    // editorial
    public bool IsNumber(string s)
    {
        var table = new List<Dictionary<string, int>>()
        {
            new Dictionary<string, int>()
            {
                { "digit", 1 },
                { "sign", 2 },
                { "dot", 3 },
            },
            new Dictionary<string, int>()
            {
                { "digit", 1 },
                { "exponent", 5 },
                { "dot", 4 },
            },
            new Dictionary<string, int>()
            {
                { "digit", 1 },
                { "dot", 3 },
            },
            new Dictionary<string, int>()
            {
                { "digit", 4 },
            },
            new Dictionary<string, int>()
            {
                { "digit", 4 },
                { "exponent", 5 },
            },
            new Dictionary<string, int>()
            {
                { "sign", 6 },
                { "digit", 7 },
            },
            new Dictionary<string, int>()
            {
                { "digit", 7 },
            },
            new Dictionary<string, int>()
            {
                { "digit", 7 },
            },
        };
        
        var currentState = 0;
        var group = "";

        for (int i = 0; i < s.Length; i++)
        {
            var curr = s[i];
            if (char.IsDigit(curr)) {
                group = "digit";
            } else if (curr == '+' || curr == '-') {
                group = "sign";
            } else if (curr == 'e' || curr == 'E') {
                group = "exponent";
            } else if (curr == '.') {
                group = "dot";
            } else {
                return false;
            }
            
            if (!table[currentState].ContainsKey(group))
            {
                return false;
            }
        
            currentState = table[currentState][group];
        }
        
        return currentState == 1 || currentState == 4 || currentState == 7;
    }
}