public class Solution {
    private readonly Dictionary<string, List<string>> _iLessThanTable = new();
    private readonly Dictionary<string, List<string>> _iBiggerThanTable = new();
    private readonly Dictionary<string, Dictionary<int, List<int>>> _sameGroupILessThanTable = new();
    private readonly Dictionary<string, Dictionary<int, List<int>>> _sameGroupIBiggerThanTable = new();
    
    private int[] ResolveGroup(string groupId)
    {
        var iLessThanTable = _sameGroupILessThanTable[groupId];
        var iBiggerThanTable = _sameGroupIBiggerThanTable[groupId];

        var result = new List<int>();
        var queue = new Queue<int>();
        foreach (var i in iBiggerThanTable.Keys)
        {
            if (iBiggerThanTable[i].Count == 0)
            {
                queue.Enqueue(i);
            }
        }
        
        while (queue.Any())
        {
            var cur = queue.Dequeue();
            result.Add(cur);

            foreach (var other in iLessThanTable[cur])
            {
                iBiggerThanTable[other].Remove(cur);
                if (iBiggerThanTable[other].Count == 0)
                {
                    queue.Enqueue(other);
                }
            }
        }
        
        return result.ToArray();
    }
    
    public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems) {

        for (var i = 0; i < n; i++)
        {
            var iGroupId = group[i] == -1 ? $"N{i}" : group[i].ToString();
            _iBiggerThanTable[iGroupId] = new List<string>();
            _iLessThanTable[iGroupId] = new List<string>();
            if (!_sameGroupILessThanTable.ContainsKey(iGroupId))
            {
                _sameGroupILessThanTable[iGroupId] = new();
            }
            if (!_sameGroupILessThanTable[iGroupId].ContainsKey(i))
            {
                _sameGroupILessThanTable[iGroupId][i] = new();
            }
            if (!_sameGroupIBiggerThanTable.ContainsKey(iGroupId))
            {
                _sameGroupIBiggerThanTable[iGroupId] = new();
            }
            if (!_sameGroupIBiggerThanTable[iGroupId].ContainsKey(i))
            {
                _sameGroupIBiggerThanTable[iGroupId][i] = new();
            }
        }
        
        for (var i = 0; i < n; i++)
        {
            var iGroupId = group[i] == -1 ? $"N{i}" : group[i].ToString();
            
            foreach (var j in beforeItems[i])
            {
                var jGroupId = group[j] == -1 ? $"N{j}" : group[j].ToString();
                
                if (iGroupId == jGroupId)
                {
                    _sameGroupILessThanTable[iGroupId][j].Add(i);
                    _sameGroupIBiggerThanTable[iGroupId][i].Add(j);
                    
                    if (_sameGroupILessThanTable[iGroupId][i].Contains(j) ||
                        _sameGroupIBiggerThanTable[iGroupId][j].Contains(i))
                    {
                        Console.WriteLine("CONTROVERSARY");
                        return [];
                    }
                    
                    continue;
                }
                _iLessThanTable[jGroupId].Add(iGroupId);
                _iBiggerThanTable[iGroupId].Add(jGroupId);
                
                // проверка на противоречия
                // увтверждение: jGroupId < iGroupId
                if (_iLessThanTable[iGroupId].Contains(jGroupId) ||
                    _iBiggerThanTable[jGroupId].Contains(iGroupId))
                {
                    Console.WriteLine("CONTROVERSARY");
                    return [];
                }
            }
        }

        var groupList = new List<string>();

        var queue = new Queue<string>();
        foreach (var groupId in _iBiggerThanTable.Keys)
        {
            if (_iBiggerThanTable[groupId].Count == 0)
            {
                queue.Enqueue(groupId);
            }
        }

        while (queue.Any())
        {
            var cur = queue.Dequeue();
            groupList.Add(cur);

            foreach (var other in _iLessThanTable[cur])
            {
                _iBiggerThanTable[other].Remove(cur);
                if (_iBiggerThanTable[other].Count == 0)
                {
                    queue.Enqueue(other);
                }
            }
        }

        var numericResult = new List<int>();
        foreach (var groupId in groupList)
        {
            if (groupId.StartsWith("N"))
            {
                numericResult.Add(int.Parse(groupId[1..]));
            }
            else
            {
                var resolvedGroup = ResolveGroup(groupId);
                numericResult.AddRange(resolvedGroup);
            }
        }
        
        if (numericResult.Count() != n) {
            return [];
        }

        return numericResult.ToArray();
    }
}