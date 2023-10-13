public class Solution {
    // идем по строке, генерим очередь стобови на каждом круге отсекаем
    // но тогда плохая сложность

    // можно кешировать суммами
    // превратить в строки и закешировать
    // мб можно еще и быстро хеш пересчитывать (на вид нет)

    // если я сделаю хеширование, то получу 
    // в лучшем случае O(N) время и O(sqrt(N)) память
    // в худем O(N*N) время и память O(sqrt(N)) память

    public const int AlphabetSize = 10;
    public const int BigPrimeNumber = 1000000033;

    // abc -> a*26^2 + b*26^1 + c*26^0 % MOD
    public long HashValue(int[] arr) {
        long sum = 0;
        long factor = 1;
        for (int i = 0; i < arr.Length; i++) {
            sum += ( (long) (arr[i]) * factor) % BigPrimeNumber;
            factor = (factor * AlphabetSize) % BigPrimeNumber;
        }
        return sum % BigPrimeNumber;
    }

    private bool Check(int[][] grid, int row, int col) {
        for (int i = 0; i < grid.Length; i++) {
            if (grid[row][i] != grid[i][col]) {
                return false;
            }
        }

        return true;
    }

    public int EqualPairs(int[][] grid) {
        var n = grid.Length;

        var hashToLineIndexesTable = new Dictionary<long, List<int>>();
        for (int i = 0; i < n; i++) {
            var hash = HashValue(grid[i]);
            if (!hashToLineIndexesTable.ContainsKey(hash)) {
                hashToLineIndexesTable[hash] = new ();
            }
            hashToLineIndexesTable[hash].Add(i);
        }
        
        var result = 0;

        for (var column = 0; column < n; column++) {
            long sum = 0;
            long factor = 1;
            for (var row = 0; row < n; row++) {
                long num = grid[row][column];
                sum += ( num * factor) % BigPrimeNumber;
                factor = (factor * AlphabetSize) % BigPrimeNumber; 
            }

            var columnHash = sum % BigPrimeNumber;
            var lineIndexesWithTheSameHash = hashToLineIndexesTable.ContainsKey(columnHash) ?
                hashToLineIndexesTable[columnHash] : new List<int>();

            foreach (var lineIndex in lineIndexesWithTheSameHash) {
                if (Check(grid, lineIndex, column)) {
                    result++;
                }
            }
        }

        return result;
    }
}