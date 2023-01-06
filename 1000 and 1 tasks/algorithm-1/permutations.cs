public class Solution {

    /*
    * Дерево или итераттвно, ()-(123) # (1)-(23) (2)-(13) (3)-(12) . Во второй скобке подядлк не важен, а первой важен. # (12)-(3) (13)-(2) и тд. И тут можно оптимизировать, потому что (1) не даёт вариантов во второй скобке
    */

    public IList<IList<int>> Permute(int[] nums) {
        var cur0 = new List<int>();
        var pool0 = nums.ToList();

        var queue = new Queue<(List<int> cur, List<int> pool)>();
        queue.Enqueue((cur0, pool0));

        var result = new List<IList<int>>();

        while (queue.Any()) {
            var (cur, pool) = queue.Dequeue();

            foreach (var p in pool) {
                var newCur = cur.ToList();
                newCur.Add(p);

                if (newCur.Count() == nums.Count()) {
                    result.Add(newCur);
                    continue;
                }

                var newPool = pool.Where(x => x != p).ToList();
                queue.Enqueue((newCur, newPool));
            }
        }

        return result;
    }
}