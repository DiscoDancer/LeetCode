public class Solution {
    // мб надо идти от обратного от s3
    // просто запустить 2 раза, чтобы побороть лево право
    // идем по s1 и либо копим, либо отрезаем. Но что тогда с s2


    // идем от s3

    private string _s1;
    private string _s2;
    private string _s3;

    public const int SCAN_LEFT = 1;
    public const int SCAN_RIGHT = 2;

    private bool?[,,,] _mem;


    // рассматриваем только лево
    private bool F (int s1Index, int s2Index, int s3Index, int state) {
        if (s3Index == _s3.Length) {
            return s2Index == _s2.Length && s1Index == _s1.Length;
        }
        if (_mem[s1Index, s2Index, s3Index, state] != null) {
            return _mem[s1Index, s2Index, s3Index, state].Value;
        }

         var result = false;

        if (state == SCAN_LEFT) {
           

            // можно отсканить и закончить, а можно сканить дальше
            while (s1Index < _s1.Length && s3Index < _s3.Length && _s1[s1Index] == _s3[s3Index]) {
                s1Index++;
                s3Index++;

                result = result || F(s1Index, s2Index, s3Index, SCAN_RIGHT);
            }
        }
        else {
            while (s2Index < _s2.Length && s3Index < _s3.Length && _s2[s2Index] == _s3[s3Index]) {
                s2Index++;
                s3Index++;
                result = result || F(s1Index, s2Index, s3Index, SCAN_LEFT);
            }
        }

        _mem[s1Index, s2Index, s3Index, state] = result;

        return result;
    }

    // запустить от лева и права || чтобы было
    public bool IsInterleave(string s1, string s2, string s3) {
        _s1 = s1;
        _s2 = s2;
        _s3 = s3;

        _mem = new bool?[s1.Length +1, s2.Length +1, s3.Length +1, 3];

        return F(0,0,0, SCAN_LEFT) || F(0,0,0, SCAN_RIGHT);
    }
}