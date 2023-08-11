public class Solution {
    // будут квадраты и мы будем пропускать или не пропускать

    private int _result = 0;
    private int _n;

    private void F(int index, int saveLine1, int saveLine2) {
        if (index == _n) {
            if (saveLine1 == 0 && saveLine2 == 0) {
                _result++;
            }
            return;
        }

        if (saveLine1 == 0 && saveLine2 == 0) {
            // втыкаем :
            F(index + 1, 0, 0);
            // не втыкаем
            F(index + 1, 1, 1);
        }
        else if (saveLine1 == 1 && saveLine2 == 1) {
            // втыкаю ::
            F(index + 1, 0, 0);
            // втыкаю :.
            F(index + 1, 1, 0);
            /*
                втыкаю:

                ..
                .
            */
            F(index + 1, 0, 1);
        }
        else if (saveLine1 == 1 && saveLine2 == 0) {
            // втыкаю ..
            F(index + 1, 0, 1);
            // втыкаю 
            // ..
            //  .
            F(index + 1, 0, 0);
        }
        else if (saveLine1 == 0 && saveLine2 == 1 ) {
            // втыкаю ..
            F(index + 1, 1, 0);

            // втыкаю :.
            F(index + 1, 0, 0);
        }
    }

    // TL
    public int NumTilings(int n) {
        _n = n;
        
        F(0, 0, 0);

        return _result;
    }
}