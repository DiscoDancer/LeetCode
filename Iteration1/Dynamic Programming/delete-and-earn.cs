public class Solution {
    // сортируем, собираем окрестности и удаляем
    // таблица удаляем элемент -> результат
    
    // динамич программирование как с домами
    // идем по массиву с суммами
    // [3,4,2] -> [2, 3, 4] -> 6
    // [2,2,3,3,3,4] -> [4,9,4] -> 9
    
    // как сделать сверточку
    public int DeleteAndEarn(int[] nums) {
        var dic = new Dictionary<int, int>();
        
        foreach (var n in nums) {
            if (!dic.ContainsKey(n)) {
                dic[n] = n;
            }
            else {
                dic[n] = dic[n] + n;
            }
        }
        
        var res = 0;
        // сортируем
        var keys = dic.Keys.OrderBy(x => x).ToArray();
        
        var prev = -1;
        var prevSum = 0;
        var prevprev = -1;
        var prevprevSum = 0;
        var cur = 0;
        var curSum = 0;
        
        for (int i = 0; i < keys.Length; i++) {
            cur = keys[i];
            
            if (Math.Abs(cur - prev) > 1) {
                curSum = dic[cur] + prevSum;
            } else {
                curSum = Math.Max(prevSum, dic[cur] + prevprevSum);
            }
            
            // update previous
            prevprev = prev;
            prevprevSum = prevSum;
            prev = cur;
            prevSum = curSum;
        }
        
        return curSum;
        
    }
}