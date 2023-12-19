public class FirstUnique {
    // хранить уникальные отдельно
    // hash table
    // naive

    private List<int> _listUnique = new ();
    private Dictionary<int, int> _tableCount = new ();

    public FirstUnique(int[] nums) {
        foreach (var n in nums) {
            Add(n);
        }
    }
    
    public int ShowFirstUnique() {
        if (!_listUnique.Any()) {
            return -1;
        }
        return _listUnique.First();
    }
    
    public void Add(int n) {
            if (!_tableCount.ContainsKey(n)) {
                _tableCount[n] = 1;
                _listUnique.Add(n);
            }
            else if (_tableCount[n] == 1) {
                _tableCount[n]++;
                _listUnique.Remove(n);
            }
            else {
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