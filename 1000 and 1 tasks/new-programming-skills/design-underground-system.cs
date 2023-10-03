public class UndergroundSystem {

    // предполагаем, что станции называются по разному

    // "from#to" -> list<travelTime>
    private Dictionary<string, List<int>> _travelTable = new ();

    private Dictionary<int, (string stationName, int t)> _ongoingTravels = new ();

    public UndergroundSystem() {
        
    }
    
    public void CheckIn(int id, string stationName, int t) {
        _ongoingTravels[id] = (stationName, t);
    }
    
    public void CheckOut(int id, string stationName, int t) {
        var from = _ongoingTravels[id];
        var travelKey = from.stationName + "#" + stationName;
        var travelTime = t - from.t;

        if (!_travelTable.ContainsKey(travelKey)) {
            _travelTable[travelKey] = new ();
        }

        _travelTable[travelKey].Add(travelTime);
    }
    
    public double GetAverageTime(string startStation, string endStation) {
        var list = _travelTable[startStation + '#' + endStation];

        double sum = list.Sum();
        return sum / list.Count();
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */