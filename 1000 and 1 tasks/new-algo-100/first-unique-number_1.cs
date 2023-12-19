public class FirstUnique
{
    // хранить уникальные отдельно
    // hash table
    // naive

    public class Node {
        public Node(int v) {
            Value = v;
        }
        public int Value {get; set;}
        public Node Next {get; set;}
        public Node Prev {get; set;}
    }

    private List<int> _listUnique = new();
    private Dictionary<int, int> _tableCount = new();
    private Node _head = null;
    private Node _tail = null;
    private Dictionary<int, Node> _tableValToNode = new();

    public FirstUnique(int[] nums)
    {
        foreach (var n in nums)
        {
            Add(n);
        }
    }

    public int ShowFirstUnique()
    {
        if (_head == null) {
            return -1;
        }
        return _head.Value;
        // if (!_listUnique.Any())
        // {
        //     return -1;
        // }
        // return _listUnique.First();
    }


    // O(1) !!!
    public void Add(int n)
    {
        if (!_tableCount.ContainsKey(n))
        {
            _tableCount[n] = 1;
            _listUnique.Add(n);

            // new list
            if (_tail == null) {
                _tail = new Node(n);
                _head = _tail;
            }
            // append
            else {
                var newNode = new Node(n);
                _tail.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;

            }
            // always index
            _tableValToNode[n] = _tail;
        }
        else if (_tableCount[n] == 1)
        {
            _tableCount[n]++;
            // _listUnique.Remove(n);

            var nodeToRemove = _tableValToNode[n];
            // можно удалять, можно и не удалять
            // _tableValToNode.Remove(n);
            var prev = nodeToRemove.Prev;
            var next = nodeToRemove.Next;

            if (nodeToRemove == _head || nodeToRemove == _tail) {
                if (nodeToRemove == _head) {
                    _head = _head.Next;
                    if (_head == null) {
                        _tail = null;
                    } else {
                        _head.Prev = null;
                    }
                }
                else if (nodeToRemove == _tail) {
                    _tail = _tail.Prev;
                    if (_tail == null) {
                        _head = null;
                    } else {
                        _tail.Next = null;
                    }
                }
            }
            else {
                prev.Next = next;
                if (next != null) {
                    next.Prev = prev;
                }
            }

        }
        else
        {
            // можно и ничего не делать
            _tableCount[n]++;
        }
    }
}

/**
 * Your FirstUnique object will be instantiated and called as such:
 * FirstUnique obj = new FirstUnique(nums);
 * int param_1 = obj.ShowFirstUnique();
 * obj.Add(value);
 */