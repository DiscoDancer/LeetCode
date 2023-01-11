public class Solution {

    // нужно считать сверху сначала
    // сначала brute force, потом dp

    // wrong
    public static int Trap(int[] height) {
        var totalCount = 0;
        var max = height.Max();

        bool[] prevWater = null;
        for (int level = max; level > 0; level--) {
            var lastWallIndex = -1;
            var curWater = new bool[height.Length];
            for (int i = 0; i < height.Length; i++) {
                if (height[i] >= level) {
                    if (lastWallIndex == -1) {
                        lastWallIndex = i;
                    }
                    else {
                        // так просто только на верхнем уровне
                        if (level == max) {
                            for (var j = lastWallIndex + 1; j < i; j++) {
                                curWater[j] = true;
                                totalCount++;
                            }
                        }
                        else {
                            // нужно свеху найти воздух или воду
                            var waterOrAir = false;
                            for (var j = lastWallIndex + 1; j < i && !waterOrAir; j++) {
                                if (prevWater[j] || height[j] == level - 1) {
                                    waterOrAir = true;
                                }
                            }

                            if (waterOrAir) {
                                for (var j = lastWallIndex + 1; j < i; j++) {
                                    curWater[j] = true;
                                    totalCount++;
                                }
                            }
                        }
 
                        lastWallIndex = i;
                    }
                }
            }
            prevWater = curWater;
        }

        return totalCount;
    }
    
    public static void Main()
    {
        Console.WriteLine(Trap(new []{0,1,0,2,1,0,1,3,2,1,2,1}));
    }
}