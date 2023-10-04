public class Solution {
    // to str
    // если цифры 2,3,4,5,6,7 -> сразу нет
    // должен содержать 6 или 9
    public bool ConfusingNumber(int n) {
        var s = n + "";
        var sb = new StringBuilder();
        foreach (var c in s) {
            if (c == '0' || c == '1' || c == '6' || c == '9' || c == '8') {
                if (c == '6') {
                    sb.Insert(0, '9');
                }
                else if (c == '9') {
                    sb.Insert(0, '6');
                }
                else {
                    sb.Insert(0, c);
                }
            }
            else {
                return false;
            }
        }

        return s != sb.ToString();
    }
}