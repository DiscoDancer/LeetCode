public class Solution {
    // мб надо идти от обратного от s3
    // просто запустить 2 раза, чтобы побороть лево право
    // идем по s1 и либо копим, либо отрезаем. Но что тогда с s2


    // идем от s3

    private bool _result = false;

    private string _s1;
    private string _s2;
    private string _s3;

    public const int SCAN_LEFT = 1;
    public const int SCAN_RIGHT = 2;


    // рассматриваем только лево
    private void F (int s1Index, int s2Index, int s3Index, int state) {
        if (s3Index == _s3.Length) {
            _result = s2Index == _s2.Length && s1Index == _s1.Length;
        }
        if (_result) {
            return;
        }

        if (state == SCAN_LEFT) {
            // можно отсканить и закончить, а можно сканить дальше
            while (s1Index < _s1.Length && s3Index < _s3.Length && _s1[s1Index] == _s3[s3Index]) {
                s1Index++;
                s3Index++;

                F(s1Index, s2Index, s3Index, SCAN_RIGHT);
            }
        }
        else {
            while (s2Index < _s2.Length && s3Index < _s3.Length && _s2[s2Index] == _s3[s3Index]) {
                s2Index++;
                s3Index++;
                F(s1Index, s2Index, s3Index, SCAN_LEFT);
            }
        }
    }

    // TL
    // запустить от лева и права || чтобы было
    public bool IsInterleave(string s1, string s2, string s3) {
        _s1 = s1;
        _s2 = s2;
        _s3 = s3;

        F(0,0,0, SCAN_LEFT);

        _s2 = s1;
        _s1 = s2;
        F(0,0,0, SCAN_LEFT);

        return _result;
    }
}