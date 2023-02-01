// https://leetcode.com/problems/reconstruct-itinerary/solutions/514368/reconstruct-itinerary/?orderBy=most_votes
public class Solution {

    private Dictionary<string, List<string>> _flightTable = new ();
    private Dictionary<string, bool[]> _flightTableVisited = new ();
    private List<string> _result = new ();
    private int _ticketCount;

    // хватит только списка и последнего и так получим?
    private bool DFS(List<string> route) {
        // все облетели = удача
        if (route.Count() == _ticketCount + 1) {
            _result = route.ToList();
            return true;
        }

        // лететь больше некуда, но не все облетели = неудачная ветка
        if (!_flightTable.ContainsKey(route.Last())) {
            return false;
        }

        for (int i = 0; i < _flightTable[route.Last()].Count(); i++) {
            if (_flightTableVisited[route.Last()][i]) {
                continue;
            }

            _flightTableVisited[route.Last()][i] = true;
            route.Add(_flightTable[route.Last()][i]);

            var subResult = DFS(route);

            route.RemoveAt(route.Count() - 1);
            _flightTableVisited[route.Last()][i] = false;

            if (subResult) {
                return true;
            }
        }

        return false;
    }

    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        _ticketCount = tickets.Count();
        foreach (var ticket in tickets) {
            if (!_flightTable.ContainsKey(ticket[0])) {
                _flightTable[ticket[0]] = new ();
            }
            _flightTable[ticket[0]].Add(ticket[1]);
        }

        foreach (var key in _flightTable.Keys) {
            _flightTable[key].Sort();
            _flightTableVisited[key] = new bool[_flightTable[key].Count()];
        }

        DFS(new List<string>() {"JFK"});

        return _result;
    }
}