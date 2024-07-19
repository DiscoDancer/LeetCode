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

    private string CreateLineFromWord()
    {
        var word = _curLineBuffer[0];
        return CreateLineFromWordsWithSingleSpace([word]);
    }
    
    private string CreateLineFromWordsWithSingleSpace(List<string> words)
    {
        var sb = new StringBuilder(string.Join(" ", words));
        while (sb.Length < _maxWidth) {
            sb.Append(' ');
        }

        return sb.ToString();
    }

    private string CreateLineFromWords(string space, string bigSpace, int bigSpacesCount)
    {
        var words = _curLineBuffer;
        var spacesCount = Math.Max(0, words.Count - 1);
        var sb = new StringBuilder();
        for (int i = 0, j = 0; i < words.Count; i++, j++) {
            sb.Append(words[i]);
            if (j < bigSpacesCount) {
                sb.Append(bigSpace);
            }
            else if (j < spacesCount) {
                sb.Append(space);
            }
        }

        return sb.ToString();
    }

    private (int minSizeSpace, int bigSpacesCount) CalculateSpaces()
    {
        var allWordsInLineLength = _curLineBuffer.Select(x => x.Length).Sum();
        var allSpacesInLineLength = _maxWidth - allWordsInLineLength;
        var spacesCount = _curLineBuffer.Count() - 1;
        var minSizeSpace = (int) Math.Floor((double)allSpacesInLineLength / spacesCount );

        var bigSpacesCount = allSpacesInLineLength - minSizeSpace * spacesCount;

        return (minSizeSpace, bigSpacesCount);
    }

    private readonly Dictionary<int, string> _spaceTable = new();
    
    private (string space, string bigSpace) GetSpaces(int minSizeSpace)
    {
        if (!_spaceTable.ContainsKey(minSizeSpace))
        {
            _spaceTable[minSizeSpace] = CreateSpace(minSizeSpace);
        }

        if (!_spaceTable.ContainsKey(minSizeSpace + 1))
        {
            _spaceTable[minSizeSpace + 1] = _spaceTable[minSizeSpace] + " ";
        }

        return (_spaceTable[minSizeSpace], _spaceTable[minSizeSpace + 1]);
    }

    private string CreateSpace(int length)
    {
        var sbSpace = new StringBuilder();
        for (var i = 0; i < length; i++) {
            sbSpace.Append(' ');
        }
        var space = sbSpace.ToString();
        return space;
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
                    _result.Add(CreateLineFromWord());
                }
                else
                {
                    var (minSizeSpace, bigSpacesCount) = CalculateSpaces();
                    var (space, bigSpace) = GetSpaces(minSizeSpace);
                    _result.Add(CreateLineFromWords(space, bigSpace, bigSpacesCount));
                }

                // clean
                _curLineBuffer = [w];
            }
        }

        // last Line
        if (_curLineBuffer.Any()) {
            _result.Add(CreateLineFromWordsWithSingleSpace(_curLineBuffer));
        }
    }
    
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        _maxWidth = maxWidth;
        FullJustifyInner(words);
        
        return _result;
    }
}