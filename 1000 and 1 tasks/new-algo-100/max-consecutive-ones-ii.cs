public class Solution {
    // можно переиспользовать мое прошлое решение
    // я имею в виду longest-substring-with-at-most-k-distinct-characters
    // если хотябы два нуля подряд -> сбрасываем прошлые 11111
    // в ответ также пишем возможность добавить +1 от 0 слева или справа


    // отдельно рассматриваем индивидуально (+0) и возможность соединить
    // важно! ноль можно ставить справа или слева


    public int FindMaxConsecutiveOnes(int[] nums) {
        var prev = 2;
        var max = 1;

        var current1Strike = 0;
        var prev1Strike = 0;

        for (int i = 0; i < nums.Length + 1; i++) {
            var cur = i < nums.Length ? nums[i] : 2;

            if (cur == prev) {
                if (cur == 1) {
                    current1Strike++;
                }
                // два нуля подряд превращают предыдущее комбо в тыкву
                else if (cur == 0) {
                    prev1Strike = 0;
                }
            }
            else if (cur != prev) {
                if (cur == 1) {
                    current1Strike = 1;
                }
                // strike оборвался
                else if (cur == 0 && prev == 1) {
                    if (prev1Strike != 0) {
                        max = Math.Max(max, prev1Strike + current1Strike + 1);
                    }
                    // ноль справа точно есть
                    max = Math.Max(max, current1Strike + 1);
                    prev1Strike = current1Strike;
                    current1Strike = 0;
                }
                // нужно проверить на ноль слева
                else if (cur == 2 && prev == 1) {
                    var zeroCandidateIndex = i - current1Strike - 1;
                    if (zeroCandidateIndex >= 0 && nums[zeroCandidateIndex] == 0) {
                        max = Math.Max(max, current1Strike + 1);
                    }
                    if (prev1Strike != 0) {
                        max = Math.Max(max, prev1Strike + current1Strike + 1);
                    }
                }
            }

            max = Math.Max(current1Strike, max);

            prev = cur;
        }

        return max;
    }
}