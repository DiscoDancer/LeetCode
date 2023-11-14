public class Solution {
    public const int BigNum = 1_000_000_007;

    // таблицу можно заменить на 4 переменных, но этого делать я конечно же не буду
    public int NumTilings(int n) {
        var table = new int[n+1, 2, 2];
        table[n,1,1] = 1;

        for (int i = n-1; i >= 0; i--) {
            for (int filledTop = 0; filledTop < 2; filledTop++) {
                for (int filledBottom = 0; filledBottom < 2; filledBottom++) {
                    var result = 0;
                    if (filledTop == 1 && filledBottom == 1) {
                        // ставлю :
                        result += table[i+1, 1, 1];
                        result %= BigNum;
                        // ничего не ставлю
                        result += table[i+1, 0, 0];
                        result %= BigNum;
                    }
                    else if (filledTop == 0 && filledBottom == 0) {
                        // ставлю ::
                        result += table[i+1, 1, 1];
                        result %= BigNum;
                        // ставлю :.
                        result += table[i+1, 0, 1];
                        result %= BigNum;
                        // ставлю :'
                        result += table[i+1, 1, 0];
                        result %= BigNum;
                    }
                    else if (filledTop == 1 && filledBottom == 0) {
                        // ставлю .:
                        result += table[i+1, 1, 1];
                        result %= BigNum;
                        // ставлю ..
                        result += table[i+1, 0, 1];
                        result %= BigNum;
                    }
                    else if (filledTop == 0 && filledBottom == 1) {
                        // ставлю ':
                        result += table[i+1, 1, 1];
                        result %= BigNum;
                        // ставлю ..
                        result += table[i+1, 1, 0];
                        result %= BigNum;
                    }

                    result %= BigNum;

                    table[i, filledTop, filledBottom] = result;
                }
            }
        }

        return table[0,1,1];
    }
}