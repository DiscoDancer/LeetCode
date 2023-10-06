public class Solution {
    // найти отрезки, для каждого отрезка все понятно
    // включая

    // надо подставить доп цифры

    private int Calc(int x) {
        if (x <= 0) {
            return 0;
        }

        return (int)Math.Ceiling( ((double)x) / 2);
    }

    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        var last1Index = -1;
        var max = 0;
        for (int i = 0; i < flowerbed.Length; i++) {
            if (flowerbed[i] == 1) {
                if (last1Index == -1)
                {
                    var range = i-1;
                    max += Calc(range);
                }
                else
                {
                    var range = (i - 1) - (last1Index + 1) - 1;
                    max += Calc(range);
                }

                last1Index = i;
            }
        }

        if (last1Index == -1) {
            return Calc(flowerbed.Length) >= n;
        }

        if (last1Index != flowerbed.Length - 1) {
            max += Calc(flowerbed.Length - 2 - last1Index);
        }

        return max >= n;
    }
}