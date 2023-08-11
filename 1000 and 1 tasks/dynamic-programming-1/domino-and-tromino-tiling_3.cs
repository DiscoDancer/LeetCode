public class Solution {
    public int NumTilings(int n) {
        var row = new long[2,2];
        row[0,0] = 1;

        for (int index = n-1; index >= 0; index--) {
            var newRow = new long[2,2];
            for (var saveLine1 = 0; saveLine1 < 2; saveLine1++) {
                for (var saveLine2 = 0; saveLine2 < 2; saveLine2++) {
                    if (saveLine1 == 0 && saveLine2 == 0) {
                        newRow[saveLine1, saveLine2] = 
                            row[0,0]
                            + row[1,1];
                    }
                    else if (saveLine1 == 1 && saveLine2 == 1) {
                        newRow[saveLine1, saveLine2] = 
                            row[0,0] +
                            row[1,0] + 
                            row[0,1];
                    }
                    else if (saveLine1 == 1 && saveLine2 == 0) {
                        newRow[saveLine1, saveLine2] =
                            row[0,1] 
                            + row[0,0];
                    }
                    else if (saveLine1 == 0 && saveLine2 == 1) {
                        newRow[saveLine1, saveLine2] =
                            row[1,0]
                            + row[0,0];
                    }

                    newRow[saveLine1, saveLine2] %= 1_000_000_007;
                }
            }

            row = newRow;
        }

        return (int)row[0,0];
    }
}