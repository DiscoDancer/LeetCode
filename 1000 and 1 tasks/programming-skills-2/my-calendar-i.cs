public class MyCalendar {

    private List<(int start, int end)> _list = new ();

    public MyCalendar() {
        
    }
    
    // start != end
    public bool Book(int start, int end) {
        foreach (var e in _list) {
            var isBefore = start >= e.end;
            var isAfter = end <= e.start;
            if (!(isBefore || isAfter)) {
                return false;
            }
        }

        _list.Add((start, end));
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */