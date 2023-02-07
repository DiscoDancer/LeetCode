public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
       var table = new (List<int> inV, List<int> outV)[numCourses];
       for (int i = 0; i < numCourses; i++) {
           table[i] = (new List<int>(), new List<int>());
       }

       foreach (var pr in prerequisites) {
            var slave = pr[0];
            var master = pr[1];
            table[slave].outV.Add(master);
            table[master].inV.Add(slave);
       }

       var visited = new bool[numCourses];

       var queue = new Queue<int>();
       for (int i = 0; i < numCourses; i++) {
           if (!table[i].outV.Any()) {
               queue.Enqueue(i);
           }
       }

       var result = new List<int>();

       while (queue.Any()) {
           var cur = queue.Dequeue();
           result.Add(cur);
           visited[cur] = true;

           foreach (var x in table[cur].inV) {
               table[x].outV.Remove(cur);
               if (!visited[x] && !table[x].outV.Any()) {
                   queue.Enqueue(x);
               }
           }
       }

       return result.Count() == numCourses ? result.ToArray() : new int[] {};
    }
}