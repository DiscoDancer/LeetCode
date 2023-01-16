public class Solution {

    private string Word2;

    private int MinDistanceInner(List<char> curStr, int index2) {
        if (!curStr.Any()) {
            // сколько осталось во втором
            return Word2.Length - index2;
        }
        if (index2 >= Word2.Length) {
            // сколько осталось в первом, если второй кончился
            return curStr.Count();
        }

        // точно есть
        var curChar1 = curStr.First();

        // если одинаковые пропускаем
        if (curChar1 == Word2[index2]) {
            return MinDistanceInner(curStr.Skip(1).ToList(), index2 + 1);
        }

        // здесь они точно разные

        // пробуем удалить
        var deleteResult = 1 + MinDistanceInner(curStr.Skip(1).ToList(), index2);
        // меняем и соотвественно сдвигаемся
        var replaceResult = 1 + MinDistanceInner(curStr.Skip(1).ToList(), index2 + 1);
        // пробуем добавить
        var addResult = 1 + MinDistanceInner(curStr.ToList(), index2 + 1);

        var result = Math.Min(deleteResult, replaceResult);
        result = Math.Min(result, addResult);

        return result;
    }

    public int MinDistance(string word1, string word2) {
        if (word2.Length == 0) {
            return word1.Length;
        }
        if (word1.Length == 0) {
            return word2.Length;
        }

        // strings are not empty here
        Word2 = word2;
        return MinDistanceInner(word1.Select(x => x).ToList(), 0);
    }
}