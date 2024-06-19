public class Solution {
    public int Trap(int[] height) {
        var n = height.Length;
        var sum = 0;

        for (int i = 1; i < n - 1; i++) {
            if (height[i - 1] > height[i]) {
                var leftWallIndex = i - 1;

                // вариант 1 правая стена >= левой
                var rightWallIndex = i;
                while (rightWallIndex < n && height[rightWallIndex] < height[leftWallIndex]) {
                    rightWallIndex++;
                }
                // первый вариант нашел
                if (rightWallIndex < n) {
                    var j = leftWallIndex + 1;
                    var subSum = 0;
                    while (j < rightWallIndex) {
                        subSum += Math.Min(height[rightWallIndex] , height[leftWallIndex]) - height[j];
                        j++;
                    }
                    sum += subSum;
                    i = rightWallIndex - 1;
                }
                else {
                    // второй вариант ищем стенку болье воды
                    rightWallIndex = i;
                    var k = rightWallIndex;
                    while (k < n) {
                        if (height[k] > height[rightWallIndex]) {
                            rightWallIndex = k;
                        }
                        k++;
                    }
                    if (rightWallIndex < n && rightWallIndex != i) {
                        var j = leftWallIndex + 1;
                        var subSum = 0;
                        while (j < rightWallIndex) {
                            subSum += Math.Min(height[rightWallIndex] , height[leftWallIndex]) - height[j];
                            j++;
                        }
                        sum += subSum;
                        i = rightWallIndex - 1;
                    }
                }
            }
        }

        return sum;
    }
}