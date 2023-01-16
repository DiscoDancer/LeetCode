public class Solution {

    private string Word1;
    private string Word2;

    private int MinDistanceInner(int index1, int index2) {
        if (index1 >= Word1.Length) {
            // сколько осталось во втором
            return Word2.Length - index2;
        }
        if (index2 >= Word2.Length) {
            // сколько осталось в первом, если второй кончился
            return Word1.Length - index1;
        }


        // если одинаковые пропускаем
        if (Word1[index1] == Word2[index2]) {
            return MinDistanceInner(index1 + 1, index2 + 1);
        }

        // здесь они точно разные

        // пробуем удалить
        var deleteResult = 1 + MinDistanceInner(index1 + 1, index2);
        // меняем и соотвественно сдвигаемся
        var replaceResult = 1 + MinDistanceInner(index1 + 1, index2 + 1);
        // пробуем добавить
        var addResult = 1 + MinDistanceInner(index1, index2 + 1);

        var result = Math.Min(deleteResult, replaceResult);
        result = Math.Min(result, addResult);

        return result;
    }

    public int MinDistance(string word1, string word2) {
        Word2 = word2;
        Word1 = word1;
        // var dp = new int[word1.Length + 1][];
        // for (int i = 0; i <= word1.Length; i++) {
        //     dp = new int[word2.Length + 1];
        // }



        return MinDistanceInner(0, 0);
    }
}