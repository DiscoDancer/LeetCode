// https://leetcode.com/problems/my-calendar-i/solutions/2803279/c-sorted-dictionary-binary-search/?orderBy=most_votes&languageTags=csharp
// https://leetcode.com/problems/my-calendar-i/editorial/
public class MyCalendar {

    private SortedList<int,int> _list = new ();

    public MyCalendar() {
        
    }
    
    // start != end
    public bool Book(int start, int end) {
        var left = 0;
        var right = _list.Count - 1;
        while(left <= right) {
            int mid = left + (right - left) / 2;
            int eStartTime = _list.Keys[mid];
            int eEndTime = _list[eStartTime];

            var isBefore = start >= eEndTime;
            var isAfter = end <= eStartTime;
            if (!(isBefore || isAfter)) {
                return false;
            }

            if (start > eStartTime) {
                left = mid + 1;
            }
            else {
                right = mid - 1; 
            }

        }

        _list.Add(start,end);
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */