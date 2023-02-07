public class Solution {
    // n cources: 0..n-1
    // prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
    public bool CanFinish(int numCourses, int[][] prerequisites) {
       var table = new (List<int> inV, int outVCount)[numCourses];
       for (int i = 0; i < numCourses; i++) {
           table[i] = (new List<int>(), 0);
       }

       foreach (var pr in prerequisites) {
            var slave = pr[0];
            var master = pr[1];
            table[slave] = (table[slave].inV, table[slave].outVCount + 1);
            table[master].inV.Add(slave);
       }

       var queue = new Queue<int>();
       for (int i = 0; i < numCourses; i++) {
           if (table[i].outVCount == 0) {
               queue.Enqueue(i);
           }
       }

       while (queue.Any()) {
           var cur = queue.Dequeue();

           foreach (var x in table[cur].inV) {
               table[x] = (table[x].inV, table[x].outVCount - 1);
               if (table[x].outVCount == 0) {
                   queue.Enqueue(x);
               }
           }
       }

       return table.All(x => x.outVCount == 0);
    }
}