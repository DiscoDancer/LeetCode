public class Solution {
        // backtracking
        // state shrinking (ulong)

        private char[][] _seats;
        private int _max = 0;

        public const char BROKEN = '#';
        public const char NOT_BROKEN = '.';

        // placed выводится из table

        private void F(int index, bool[] table) {
            var X = _seats.Length;
            var Y = _seats[0].Length;

            var row = index / Y;
            var col = index % Y;

            bool canPlaced = _seats[row][col] == NOT_BROKEN;
            if (canPlaced && col > 0 && table[row*Y + col-1]) {
                canPlaced = false;
            }
            // если я иду последовательно, но справа проверять не надо. Точно?

            if (canPlaced && row > 0 && col > 0 && table[(row-1)*Y + col-1]) {
                canPlaced = false;
            }
            if (canPlaced && row > 0 && col < Y - 1  && table[(row-1)*Y + col+1]) {
                canPlaced = false;
            }

            // last
            if (index == X*Y -1) {
                // какой-то грязный фикс, но с ним работает
                table[row * Y + col] = canPlaced;
                UpdateMax(table);
            }
            else {
                if (canPlaced) {
                    table[row * Y + col] = true;
                    F(index +1, table);
                    table[row * Y + col] = false;
                }
                F(index + 1, table);
            }
        }

        private void UpdateMax(bool[] table) {
            var count = 0;

            foreach (var a in table) {
                    if (a) {
                        count++;
                    }
            }

            _max = Math.Max(_max, count);
        }

        public int MaxStudents(char[][] seats) {
            _seats = seats;

            var X = seats.Length;
            var Y = seats[0].Length;

            var table = new bool[X*Y];

            F(0,table);

            return _max;
        }
}