public class Solution {
    private List<string> _curLineBuffer = new();
    private IList<string> _result = new List<string>();
    private int _maxWidth;

    private bool CanWordFitInCurrentLine(string word)
    {
        var minCharactersRequiredToAddWtoCurrentLine = 0;
        // add words
        minCharactersRequiredToAddWtoCurrentLine += _curLineBuffer.Select(x => x.Length).Sum();
        // add spaces
        minCharactersRequiredToAddWtoCurrentLine += Math.Max(0, _curLineBuffer.Count() - 1);
        // add w
        minCharactersRequiredToAddWtoCurrentLine += word.Length;
        // add space for w
        minCharactersRequiredToAddWtoCurrentLine += (_curLineBuffer.Any() ? 1 : 0);

        return minCharactersRequiredToAddWtoCurrentLine <= _maxWidth;
    }

    private void FullJustifyInner(string[] words)
    {
        foreach (var w in words)
        {
            if (CanWordFitInCurrentLine(w)) {
                _curLineBuffer.Add(w);
            }
            else {
                if (_curLineBuffer.Count() == 1) {
                    var sb = new StringBuilder(_curLineBuffer[0]);
                    while (sb.Length < _maxWidth) {
                        sb.Append(' ');
                    }
                    _result.Add(sb.ToString());
                }
                else {
                    var allWordsInLineLength = _curLineBuffer.Select(x => x.Length).Sum();
                    var allSpacesInLineLength = _maxWidth - allWordsInLineLength;
                    var spacesCount = _curLineBuffer.Count() - 1;
                    var minSizeSpace = (int) Math.Floor((double)allSpacesInLineLength / spacesCount );

                    var bigSpacesCount = allSpacesInLineLength - minSizeSpace * spacesCount;

                    var sbSpace = new StringBuilder();
                    for (int i = 0; i < minSizeSpace; i++) {
                        sbSpace.Append(' ');
                    }
                    var space = sbSpace.ToString();
                    var bigSpace = space + " ";

                    var sb = new StringBuilder();
                    for (int i = 0, j = 0; i < _curLineBuffer.Count(); i++, j++) {
                        sb.Append(_curLineBuffer[i]);
                        if (j < bigSpacesCount) {
                            sb.Append(bigSpace);
                        }
                        else if (j < spacesCount) {
                            sb.Append(space);
                        }
                    }
                    _result.Add(sb.ToString());
                }

                // clean
                _curLineBuffer = [w];
            }
        }

        // last Line
        if (_curLineBuffer.Any()) {
            var sb = new StringBuilder(string.Join(" ", _curLineBuffer));
            while (sb.Length < _maxWidth) {
                sb.Append(' ');
            }
            _result.Add(sb.ToString());
        }
    }
    
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        _maxWidth = maxWidth;
        FullJustifyInner(words);
        
        return _result;
    }
}