public class Solution {
    private int _n;

    private long F(int index, int saveLine1, int saveLine2) {
        if (index == _n) {
            if (saveLine1 == 0 && saveLine2 == 0) {
                return 1;
            }
            return 0;
        }

        if (saveLine1 == 0 && saveLine2 == 0) {
            return F(index + 1, 0, 0) + F(index + 1, 1, 1);
        }
        else if (saveLine1 == 1 && saveLine2 == 1) {
            return 
                F(index + 1, 0, 0) +
                F(index + 1, 1, 0) + 
                F(index + 1, 0, 1);
        }
        else if (saveLine1 == 1 && saveLine2 == 0) {
            return F(index + 1, 0, 1) + F(index + 1, 0, 0);
        }
        else if (saveLine1 == 0 && saveLine2 == 1 ) {
            return F(index + 1, 1, 0) + F(index + 1, 0, 0);
        }

        return -1;
    }

    public int NumTilings(int n) {
        _n = n;
        
        return (int)F(0, 0, 0);
    }
}