public class Solution {
    // нужно массив переписать как разность и сделать бинарный поиск
    // будет nlog , но мб можно быстрее. Мб можно какие-то выводы делать по m
    // сначала за квадрат решить


    // квадрат
    public int[] TwoSum(int[] numbers, int target) {
        for (int i = 0; i < numbers.Length; i++) {
            for (int j = i + 1; j < numbers.Length; j++) {
                if (numbers[i] + numbers[j] == target) {
                    return new int[] {i + 1, j + 1};
                }
            }
        }
        
        return null;
    }
}