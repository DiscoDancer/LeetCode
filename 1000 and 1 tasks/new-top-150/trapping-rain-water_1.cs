public class Solution {
    public int Trap(int[] height) {
        var n = height.Length;
        var sum = 0;

        // префиксные суммы и maxim стек могу довести до  линейки

        for (int i = 1; i < n - 1; i++) {
            if (height[i - 1] > height[i]) {
                var leftWallIndex = i - 1;

                // вариант 1 правая стена >= левой
                var rightWallIndex = i;
                while (rightWallIndex < n && height[rightWallIndex] < height[leftWallIndex]) {
                    rightWallIndex++;
                }
                // вариант 2, самый большой отеносительно текущей воды
                if (rightWallIndex == n) {
                    rightWallIndex = i;
                    var k = rightWallIndex;
                    while (k < n) {
                        if (height[k] > height[rightWallIndex]) {
                            rightWallIndex = k;
                        }
                        k++;
                    }
                }
                if (rightWallIndex < n && rightWallIndex != i) {
                    var j = leftWallIndex + 1;
                    var subSum = 0;
                    var min = Math.Min(height[rightWallIndex] , height[leftWallIndex]);
                    while (j < rightWallIndex) {
                        subSum += min - height[j];
                        j++;
                    }
                    sum += subSum;
                    i = rightWallIndex - 1;
                }
            }
        }

        return sum;
    }
}