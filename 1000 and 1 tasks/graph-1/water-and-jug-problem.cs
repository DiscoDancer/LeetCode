public class Solution {
    // Jug = кувшин
    public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity) {
        var possible = new HashSet<(int jug1, int jug2)>();
        possible.Add((0, 0));

        var queue = new Queue<(int jug1, int jug2)>();
        queue.Enqueue((0,0));

        while (queue.Any()) {
            var (jug1, jug2) = queue.Dequeue();
            if (new [] {jug1, jug2, jug1+jug2}.Contains(targetCapacity)) {
                return true;
            }

            var freeSpace1 = jug1Capacity - jug1;
            var freeSpace2 = jug2Capacity - jug2;

            // очистить 1
            if (jug1 > 0 && !possible.Contains((0, jug2)) ) {
                possible.Add((0, jug2));
                queue.Enqueue((0, jug2));
            }

            // очистить 2
            if (jug2 > 0 && !possible.Contains((jug1, 0)) ) {
                possible.Add((jug1, 0));
                queue.Enqueue((jug1, 0));
            }

            // донабрать в 1 до конца
            if (freeSpace1 > 0 && !possible.Contains((jug1Capacity, jug2))) {
                possible.Add((jug1Capacity, jug2));
                queue.Enqueue((jug1Capacity, jug2));
            }

            // донабрать в 2 до конца
            if (freeSpace2 > 0 && !possible.Contains((jug1, jug2Capacity))) {
                possible.Add((jug1, jug2Capacity));
                queue.Enqueue((jug1, jug2Capacity));
            }

            // перелить первый во второй
            // неверно!
            if (freeSpace2 > 0) {
                // jug1 есть в первом
                // сколько влезет во второй?
                var addTo2 = Math.Min(freeSpace2, jug1);
                var new1 = jug1 - addTo2;
                var new2 = jug2 + addTo2;

                if (!possible.Contains((new1, new2))) {
                    possible.Add((new1, new2));
                    queue.Enqueue((new1, new2));
                }
            }

            // перелить второй в первый
            if (freeSpace1 > 0) {
                var addTo1 = Math.Min(freeSpace1, jug2);
                var new1 = jug1 + addTo1;
                var new2 = jug2 - addTo1;

                if (!possible.Contains((new1, new2))) {
                    possible.Add((new1, new2));
                    queue.Enqueue((new1, new2));
                }
            }
        }

        return false;
    }
}