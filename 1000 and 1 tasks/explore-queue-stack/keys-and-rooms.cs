public class Solution {
    // BFS + array, sorry

    private IList<IList<int>> _rooms;
    private bool[] _visited;

    private void F(int index) {
        foreach (var child in _rooms[index]) {
            if (!_visited[child]) {
                _visited[child] = true;
                F(child);
            }
        }
    }

    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        _rooms = rooms;
        _visited = new bool[rooms.Count()];

        _visited[0] = true;
        F(0);

        return _visited.All(x => x);
    }
}