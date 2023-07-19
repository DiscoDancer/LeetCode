public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        if (n == 1) {
            return new List<string>() {"()"};
        }
        var queue = new Queue<(List<char>, int)>();
        queue.Enqueue( (new List<char>() {'(', ')'},0) );
        var result = new List<string>();

        while (queue.Any()) {
            var (list, start) = queue.Dequeue();
            for (int i = start; i < list.Count(); i++) {
                var copy = list.ToList();
                copy.Insert(i+1, '(');
                copy.Insert(i+2, ')');

                if (copy.Count() == n*2) {
                    result.Add(new string(copy.ToArray()));
                }
                else if(copy.Count() < n*2) {
                    queue.Enqueue((copy, i+1));
                }
            }
        }

        return result;
    }
}