// khan topology sort
public class Solution {
    public string AlienOrder(string[] words) {
        var letters = new HashSet<char>();
        foreach (var w in words) {
            foreach (var c in w) {
                letters.Add(c);
            }
        }

        var table = new Dictionary<char, (List<char> biggerList, List<char> lesserList)>();
        foreach (var l in letters) {
            table[l] = (new List<char> {}, new List<char>() {});
        }

        var prev = words[0];
        var wasAnyDifferent = false;
        for (int i = 1; i < words.Length; i++) {
            var cur = words[i];

            var minL = Math.Min(prev.Length, cur.Length);
            var pointer = 0; // указывает на разницу
            while (pointer < minL && prev[pointer] == cur[pointer]) {
                pointer++;
            }

            // слова одинаковые
            if (pointer == minL) {
                if (prev.Length > cur.Length) {
                    return "";
                }
                prev = cur;
                continue;
            }
            else {
                table[prev[pointer]].lesserList.Add(cur[pointer]);
                table[cur[pointer]].biggerList.Add(prev[pointer]);
            }

            prev = cur;
        }

        var queue = new Queue<char>();
        foreach (var k in table.Keys)
        {
            // важный момент. Неопознанные буквы считаем за самые большие
            // не обязательно так, в условии они могут быть в любом порядке
            if (!table[k].biggerList.Any())
            {
                queue.Enqueue(k);
            }
        }

        var result = new List<char>();

        while (queue.Any())
        {
            var cur = queue.Dequeue();
            result.Add(cur);
            foreach (var lesser in table[cur].lesserList)
            {
                table[lesser].biggerList.Remove(cur);
                if (!table[lesser].biggerList.Any())
                {
                    queue.Enqueue(lesser);
                }
            }
        }

        if (result.Count() == letters.Count)
        {
            return new string(result.ToArray());
        }

        return "";
    }
}