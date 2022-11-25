public class Solution {
    // это арифмитическая прогрессия, d = 1
    // an = a1 + d *(n-1);
    // опять та же история, ищем куда вставить
    // крайние случаи
    // тут залупа с переполнением была
    
    public long Calc2(long n) {
        long a1 = 1;
        long an = n;
        long sum = a1 + an;
        long p = sum * an;
        long res = p / 2;
        return  res;
    }
    
    public int ArrangeCoins(int n) {
        long a = 1;
        long b = n;
        
        while (a <= b) {
            var m = a + (b-a)/2;
            long sm = Calc2(m);
            if (sm == n) {
                return (int)m;
            }
            if (sm > n) {
                b = m - 1;
            }
            else if (sm < n) {
                a = m + 1;
            }
        }
        
        return (int)b;
    }
}