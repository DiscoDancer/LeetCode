public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth) {
        var result = new List<string>();

        // optimization Premature!
        // var curLineWordsCount = 0;

        var curLineBuffer = new List<string>();
        for (int wi = 0; wi < words.Length; wi++) {
            var w = words[wi];

            var curLineMimnunCharactersCount = curLineBuffer.Select(x => x.Length).Sum();
            curLineMimnunCharactersCount += Math.Max(0, curLineBuffer.Count() - 1);

            // can we add to the current line
            // dont forget extra space
            if (curLineMimnunCharactersCount + w.Length + (curLineBuffer.Any() ? 1 : 0) <= maxWidth) {
                curLineBuffer.Add(w);
            }
            else {
                if (curLineBuffer.Count() == 1) {
                    var sb = new StringBuilder(curLineBuffer[0]);
                    while (sb.Length < maxWidth) {
                        sb.Append(' ');
                    }
                    result.Add(sb.ToString());
                }
                else {
                    var allWordsInLineLength = curLineBuffer.Select(x => x.Length).Sum();
                    var allSpacesInLineLength = maxWidth - allWordsInLineLength;
                    var spacesCount = curLineBuffer.Count() - 1;
                    var minSizeSpace = (int) Math.Floor((double)allSpacesInLineLength / spacesCount );

                    var bigSpacesCount = allSpacesInLineLength - minSizeSpace * spacesCount;

                    var sbSpace = new StringBuilder();
                    for (int i = 0; i < minSizeSpace; i++) {
                        sbSpace.Append(' ');
                    }
                    var space = sbSpace.ToString();
                    var bigSpace = space + " ";

                    var sb = new StringBuilder();
                    for (int i = 0, j = 0; i < curLineBuffer.Count(); i++, j++) {
                        sb.Append(curLineBuffer[i]);
                        if (j < bigSpacesCount) {
                            sb.Append(bigSpace);
                        }
                        else if (j < spacesCount) {
                            sb.Append(space);
                        }
                    }
                    result.Add(sb.ToString());
                }

                // clean
                curLineBuffer = new () {w};
            }
        }

        // last Line
        if (curLineBuffer.Any()) {
            var sb = new StringBuilder(string.Join(" ", curLineBuffer));
            while (sb.Length < maxWidth) {
                sb.Append(' ');
            }
            result.Add(sb.ToString());
        }

        return result;
    }
}