public class Solution {
    // нужно написать правила сокращения и до этого преобразовать в операции и константы
    // const */ const -> const
    // (const) -> const
    // const +- const -> const (но надо смотреть, чтобы не было рядом * и /)

    // а если дерево выражений
    // обратная польская
    // видим закрывающуюся скобку или конец -> начинаем считать


    // TODO этого мало, нужно смотреть следующую операцию. Потому что рекурсивно могут сократиться
    // с этим можно бороться так: не сокращать выражение во время чтения, а сокращать после
    /*
        while (tokens.Count() != 1) {
            var newTokens = []
            foreach (var t in tokens) {
                newTokens.Add(t);
                Resolve(newTokens);
            }
            tokens = newTokens;
        }
        return tokens.First().v
    */

    public const int Constant = 1;
    public const int Multiply = 2;
    public const int Divide = 3;
    public const int Plus = 4;
    public const int Minus = 5;
    public const int OpenBracket = 6;
    public const int CloseBracket = 7;

    private bool TryResolveMulDiv(List<(int v, int type)> list) {
        if (list.Count() >= 3) {
            var length = list.Count();
            var a = list[length-3];
            var b = list[length-2];
            var c = list[length-1];

            if (
                a.type == Constant &&
                c.type == Constant &&
                (b.type == Multiply || b.type == Divide) ) {
                    list.RemoveAt(list.Count()-1);
                    list.RemoveAt(list.Count()-1);
                    list.RemoveAt(list.Count()-1);
                    if (b.type == Multiply) {
                        list.Add((a.v*c.v, Constant));
                    }
                    else {
                        list.Add((a.v/c.v, Constant));
                    }
                    return true;
                }
        }
        return false;
    }

    
    private bool TryResolveBrackets (List<(int v, int type)> list) {
        if (list.Count() >= 3) {
            var length = list.Count();
            var a = list[length-3];
            var b = list[length-2];
            var c = list[length-1];

            if (
                a.type == OpenBracket &&
                c.type == CloseBracket &&
                b.type == Constant ) {
                    list.RemoveAt(list.Count()-1);
                    list.RemoveAt(list.Count()-1);
                    list.RemoveAt(list.Count()-1);
                    list.Add((b.v, Constant));
                    return true;
                }
        }
        return false;
    }

    // TODO этого мало, нужно смотреть следующую операцию. Потому что рекурсивно могут сократиться
    private bool TryResolvePlusMinus(List<(int v, int type)> list) {
        if (list.Count() < 3) {
            return false;
        }

        var length = list.Count();
        var a = list[length-3];
        var b = list[length-2];
        var c = list[length-1];

        var leftOk = length < 4 || (list[length-4].type != Multiply && list[length-4].type != Divide);
        if (!leftOk) {
            return false;
        }

        if (
                a.type == Constant &&
                c.type == Constant &&
                (b.type == Plus || b.type == Minus) ) {
                    list.RemoveAt(list.Count()-1);
                    list.RemoveAt(list.Count()-1);
                    list.RemoveAt(list.Count()-1);
                    if (b.type == Plus) {
                        list.Add((a.v+c.v, Constant));
                    }
                    else {
                        list.Add((a.v-c.v, Constant));
                    }
                    return true;
        }

        return false;
    }

    private void ResolveList(List<(int v, int type)> list, bool canResolvePlusMinus) {
        var resolved = false;
        resolved |= TryResolveMulDiv(list);
        resolved |= TryResolveBrackets(list);
        if (canResolvePlusMinus) {
            resolved |= TryResolvePlusMinus(list);
        }
        if (resolved) {
            ResolveList(list, false);
        }
    }

    public int Calculate(string s) {
        var list = new List<(int v, int type)>();

        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '*') {
                list.Add((0, Multiply));
            }
            else if (s[i] == '/') {
                list.Add((0, Divide));
            }
            else if (s[i] == '+') {
                list.Add((0, Plus));
            }
            else if (s[i] == '-') {
                list.Add((0, Minus));
            }
            else if (s[i] == '(') {
                list.Add((0, OpenBracket));
            }
            else if (s[i] == ')') {
                list.Add((0, CloseBracket));
            }
            else {
                var sb = new StringBuilder();
                while (i < s.Length && Char.IsDigit(s[i])) {
                    sb.Append(s[i]);
                    i++;
                }
                list.Add((int.Parse(sb.ToString()), Constant));
                i--;
            }
        }

        while (list.Count() != 1) {
            var newList = new List<(int v, int type)>();
            for (int i = 0; i < list.Count(); i++) {
                newList.Add(list[i]);
                var canResolvePlusMinus = i == list.Count() - 1 ||
                    list[i+1].type != Multiply && list[i+1].type != Divide;
                ResolveList(newList, canResolvePlusMinus);
            }
            list = newList;
        }

        return list.First().v;
    }
}