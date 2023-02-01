// НЕВЕРНО! не все тест кейсы проходят

public class Solution {
    // tickets[i] = [fromi, toi]
    // departs from "JFK"
    // smallest lexical order

    /*
        Идеи: считаем все варианты, потом сортируем
    */
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        // tag (from) -> queue (from, to) sorted by fromto
        var table = new Dictionary<string, PriorityQueue<(string from, string to), string>>();

        foreach (var t in tickets) {
            var from = t[0];
            var to = t[1];

            if (!table.ContainsKey(from)) {
                table[from] = new ();
            }
            table[from].Enqueue((from, to), from + to);
        }

        var result = new List<string>();

        while (table["JFK"].TryDequeue(out var tripJFK, out var str)) {
            // тут начинается путешествие (их может быть несколько)
            result.Add(tripJFK.from);
            result.Add(tripJFK.to);

            // идем от somewhere ( JFK -> somewhere)
            var currentTripTo = tripJFK.to;
            while (table.ContainsKey(currentTripTo) && table[currentTripTo].Count > 0) {
                var newTrip = table[currentTripTo].Dequeue();
                if (result.Last() != newTrip.from) {
                    result.Add(newTrip.from);
                }
                result.Add(newTrip.to);

                currentTripTo = newTrip.to;
            }
        }

        return result;
    }
}