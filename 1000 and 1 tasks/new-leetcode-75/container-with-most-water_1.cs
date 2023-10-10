public class Solution {
    // dp решение берем или пропускаем
    // 2nd 1st max (no working)
    // 2 pointers ссудя из названия
    // влкадывать друг в друга

    /*
        - идем слева
            - если следующий ниже или равен прошлого - он хуже
            - если он выше? можно подогнать правый
    */

    private int F(int l, int r) {
        if (l >= r) {
            return 0;
        }

        var cur = Math.Min(_height[l], _height[r]) * (r - l);
        var option1 = F(l+1, r);
        var option2 = F(l, r-1);

        return Math.Max(cur, Math.Max(option1, option2));
    }

    private int[] _height;

    // TL
    public int MaxArea(int[] height) {
        _height = height;

        return F(0, height.Length - 1);
    }
}