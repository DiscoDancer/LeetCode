public class Solution {
    public int CalPoints(string[] operations) {
        var list = new List<int>();
        int sum = 0;

        foreach (var op in operations) {
            if (op == "D") {
                list.Add(2*list.Last());
                sum += list.Last();
            }
            else if (op == "C") {
                sum -= list.Last();
                list.RemoveAt(list.Count()-1);
            }
            else if (op == "+") {
                list.Add(list[list.Count()-1] + list[list.Count()-2]);
                sum += list.Last();
            }
            else {
                list.Add(int.Parse(op));
                sum += list.Last();
            }
        }

        return sum;
    }
}