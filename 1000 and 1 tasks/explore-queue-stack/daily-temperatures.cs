public class Solution {
    // monothoic stack
    // заполняем с конца
    // там была идея в том, что мы копим, а потом пишем
    // всего 2 варианта, когда-то мы пишем, а когда-то копим
    // если массив кончился то мб forced запись
    public int[] DailyTemperatures(int[] temperatures) {
        var result = new int[temperatures.Length];

        // что класть значение или индекс?
        // индекс, потому что значение можно восстановить по temperatures
        var stack = new Stack<int>();
        for (int i = 0; i < temperatures.Length; i++) {
            while (stack.Any() && temperatures[stack.Peek()] < temperatures[i]) {
                var cur = stack.Pop();
                result[cur] = i - cur;
            }
            stack.Push(i);
        }

        return result;
    }
}