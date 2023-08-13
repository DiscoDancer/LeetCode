public class Solution {
    public int NumTilings(int n) {
        var table = new long[n+1, 2, 2];
        table[n,0,0] = 1;

        for (int index = n-1; index >= 0; index--) {
            for (var saveLine1 = 0; saveLine1 < 2; saveLine1++) {
                for (var saveLine2 = 0; saveLine2 < 2; saveLine2++) {
                    if (saveLine1 == 0 && saveLine2 == 0) {
                        table[index, saveLine1, saveLine2] = 
                            table[index+1, 0,0]
                            + table[index+1, 1,1];
                    }
                    else if (saveLine1 == 1 && saveLine2 == 1) {
                        table[index, saveLine1, saveLine2] = 
                            table[index + 1, 0, 0] +
                            table[index + 1, 1, 0] + 
                            table[index + 1, 0, 1];
                    }
                    else if (saveLine1 == 1 && saveLine2 == 0) {
                        table[index, saveLine1, saveLine2] =
                            table[index + 1, 0, 1] 
                            + table[index + 1, 0, 0];
                    }
                    else if (saveLine1 == 0 && saveLine2 == 1) {
                        table[index, saveLine1, saveLine2] =
                            table[index+1,1,0]
                            + table[index+1,0,0];
                    }

                    table[index, saveLine1, saveLine2] %= 1_000_000_007;
                }
            }
        }

        return (int)table[0,0,0];
    }
}