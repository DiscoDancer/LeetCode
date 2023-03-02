public class Solution {
    // следующее здание ниже или такое же -> ничего не надо, переходим
    // мб можно перебором

    public class State {
        public State(int i, int b, int l) {
            Index = i;
            Bricks = b;
            Ladders = l;
        }

        public int Index { get; set; }
        public int Bricks { get; set; }
        public int Ladders { get; set; }
    }

    // Time limit
    public int FurthestBuilding(int[] heights, int bricks, int ladders) {
        var queue = new Queue<State>();
        queue.Enqueue(new State(0, bricks, ladders));

        var max = 0;

        while (queue.Any()) {
            var cur = queue.Dequeue();
            max = Math.Max(max, cur.Index);

            // last
            if (cur.Index == heights.Length - 1) {
                continue;
            }

            if (heights[cur.Index] >= heights[cur.Index + 1]) {
                queue.Enqueue(new State(cur.Index + 1, cur.Bricks, cur.Ladders));
            }
            else {
                if (cur.Ladders > 0) {
                    queue.Enqueue(new State(cur.Index + 1, cur.Bricks, cur.Ladders - 1));
                }
                if (cur.Bricks >= (heights[cur.Index + 1] - heights[cur.Index]) ) {
                    queue.Enqueue(new State(cur.Index + 1, cur.Bricks - heights[cur.Index + 1] + heights[cur.Index], cur.Ladders));
                }
            }
        }

        return max;
    }
}