public class Solution {
    // работники от нуля до n-1
    // headID главный
    // manager[i] = manager для i-го сотрудника, -1 для директора
    // высота дерева = ответ

    // построить дерево и найти максимальную высоту, в теории n (строить) и n обходить
    // мб не обязательно его строить (завести табличку и от менеджера к подчиненным плюсовать (квадрат)) тут же можно словарем ускориться, но это доп память

    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {

        // начальник -> подчиненные
        var dic = new Dictionary<int, List<int>>();

        for (int i = 0; i < manager.Length; i++) {
            if (!dic.ContainsKey(manager[i])) {
                dic[manager[i]] = new List<int>();
            }
            dic[manager[i]].Add(i);
        }

        var queue = new Queue<(int x, int time)>();
        queue.Enqueue((headID, informTime[headID]));

        var max = 0;
        while (queue.Any()) {
            var (x, time) = queue.Dequeue();
            max = Math.Max(max, time);

            if (!dic.ContainsKey(x)) {
                continue;
            }

            foreach (var sub in dic[x]) {
                queue.Enqueue((sub, time + informTime[sub]));
            }
        }

        return max;
    }
}