public class Solution {
    // several aliases for islands
    // naive: k * m*n (aka check for every update)
    // optimization 1 : no need to check is there is no water

    /*
        Ищем соседей. Какие случаи могут быть?
            - соседеней нет -> новый остров
            - соседи есть, id острова у всех одинаковый -> старый отсров, берем любой alias
            - соседи есть, id островов разные -> merge aliases
    */

    // out of mem

    public class Island {
        public Island(int alias) {
            Aliases = new();
            Aliases.Add(alias);
        }
        public Island(List<int> aliases)
        {
            Aliases = aliases;
        }
        public List<int> Aliases {get; }
    }

    private int _inslandCount = 0;
    private int[,] _state;
    private List<Island> _islands = new ();
    private int _nextAlias = 1;

    private Island FindIsland(int aliase) {
        return _islands.Single(x => x.Aliases.Contains(aliase));
    }

        public IList<int> NumIslands2(int m, int n, int[][] positions) {
        _state = new int[m,n];
        var result = new List<int>();

        var X = m;
        var Y = n;

        foreach (var xy in positions) {
            var x = xy[0];
            var y = xy[1];
            if (_state[x,y] != 0) {
                result.Add(_islands.Count());
                continue;
            }

            var neighbours = new List<Island>();
            if (x < X - 1 && _state[x+1,y] != 0) {
                neighbours.Add(FindIsland(_state[x+1,y]));
            }
            if (x > 0 && _state[x-1,y] != 0) {
                neighbours.Add(FindIsland(_state[x-1,y]));
            }
            if (y < Y - 1 && _state[x,y+1] != 0) {
                neighbours.Add(FindIsland(_state[x,y+1]));
            }
            if (y > 0 && _state[x,y-1] != 0) {
                neighbours.Add(FindIsland(_state[x,y-1]));
            }

            if (neighbours.Count() == 0) {
                var alias = _nextAlias++;
                var island = new Island(alias);
                _islands.Add(island);
                _state[x,y] = alias;
            }
            else if (neighbours.Count() == 1) {
                var island = neighbours.First();
                var alias = island.Aliases.First();
                _state[x,y] = alias;
            }
            else
            {
                var aliases = new List<int>();
                foreach (var neighbour in neighbours)
                {
                    aliases.AddRange(neighbour.Aliases);
                    _islands.Remove(neighbour);
                }
                _islands.Add(new Island(aliases));
                _state[x,y] = aliases.First();
            }

            result.Add(_islands.Count());
        }

        return result;
    }
}