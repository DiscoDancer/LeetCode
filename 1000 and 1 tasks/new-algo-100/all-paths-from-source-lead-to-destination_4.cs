public class Solution {
    private int[] _state;
    private List<int>[] _outcomingList;
    private int _destination;

    private const int DEFAULT = 0;
    private const int PROCCESSING = 1;
    private const int GOOD = 2;
    private const int BAD = 3;

    private bool Traverse(int curNode) {
        if (curNode == _destination) {
            return true;
        }
        if (!_outcomingList[curNode].Any()) {
            return false;
        }

        var result = true;

        foreach (var option in _outcomingList[curNode]) {
            if (_state[option] == PROCCESSING && option != _destination) {
                return false;
            }
            if (_state[option] == GOOD) {
                continue;
            }
            else if (_state[option] == BAD) {
                result = false;
                break;
            }
            else if (_state[option] == DEFAULT) {
                _state[option] = PROCCESSING;
                result &= Traverse(option);
            }
        }

        _state[curNode] = result ? GOOD : BAD;

        return result;
    }


    public bool LeadsToDestination(int n, int[][] edges, int source, int destination) {
        _destination = destination;
        _state = new int[n];
        _outcomingList = new List<int>[n];
        for (int i = 0; i < n; i++) {
            _outcomingList[i] = new ();
        }
        foreach (var e in edges) {
            // a -> b
            var a = e[0];
            var b = e[1];
            _outcomingList[a].Add(b);
        }

        if (_outcomingList[destination].Any()) {
            return false;
        }

        _state[source] = PROCCESSING;
        return Traverse(source);
    }
}