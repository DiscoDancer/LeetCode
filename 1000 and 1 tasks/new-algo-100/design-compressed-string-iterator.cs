public class StringIterator {
    // решение в лоб, подублировать
    // решние не в лоб - хранит пары

    public class Row {
        public char c {get; set;}
        public int count {get; set;}
    }

    private Queue<Row> _queue = new ();

    public StringIterator(string compressedString) {
        var i = 0;
        while (i < compressedString.Length) {
            var c = compressedString[i];
            i++;
            var sb = new StringBuilder();
            while (i < compressedString.Length && char.IsDigit(compressedString[i])) {
                sb.Append(compressedString[i]);
                i++;
            }
            _queue.Enqueue(new Row {
                c = c,
                count = int.Parse(sb.ToString()),
            });
        }
    }

    private void SkipEmpty() {
        while (_queue.Count > 0 && _queue.Peek().count == 0) {
            _queue.Dequeue();
        }
    }
    
    public char Next() {
        if (!HasNext()) {
            return ' ';
        }

        var peek = _queue.Peek();
        peek.count--;
        if (peek.count == 0) {
            _queue.Dequeue();
        }
        return peek.c;
    }
    
    public bool HasNext() {
        SkipEmpty();
        return _queue.Count > 0;
    }
}

/**
 * Your StringIterator object will be instantiated and called as such:
 * StringIterator obj = new StringIterator(compressedString);
 * char param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */