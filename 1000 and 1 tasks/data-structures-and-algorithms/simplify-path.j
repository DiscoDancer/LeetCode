import java.util.*;


class Solution {
    public String simplifyPath(String path) {
        if (path.equals("/")) {
            return path;
        }

        var i = 0;
        var list = new LinkedList<String>();
        // reading initial noise
        while (i < path.length() - 1 && path.charAt(i + 1) == '/') {
            i++;
        }

        while (i < path.length()) {
            var ch = path.charAt(i);
            if (Character.isAlphabetic(ch)) {
                var buffer = new StringBuilder();
                var j = i;
                while (j < path.length() && path.charAt(j) != '/') {
                    buffer.append(path.charAt(j));
                    j++;
                }
                list.add(buffer.toString());
                i = j;
            }
            else if (ch == '.') {
                var buffer = new StringBuilder();
                var j = i;
                while (j < path.length() && path.charAt(j) != '/') {
                    buffer.append(path.charAt(j));
                    j++;
                }
                var str = buffer.toString();
                if (str.equals(".")) {
                    // current dir -> ignore
                }
                else if (str.equals("..")) {
                    // step back to parent
                    if (!list.isEmpty()) {
                        list.removeLast();
                    }
                }
                else {
                    // new dir
                    list.add(str);
                }
                i = j;
            }
            // ignore for now
            else {
                i++;
            }
        }

        var sb = new StringBuilder();
        sb.append('/');
        while (!list.isEmpty()) {
            sb.append(list.removeFirst());
            if (!list.isEmpty()) {
                sb.append('/');
            }
        }

        return sb.toString();
    }
}