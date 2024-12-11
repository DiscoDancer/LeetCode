import java.util.*;

class Solution {

    public String simplifyPath(String path) {
        var list = new ArrayList<String>();

        if (!path.endsWith("/")) {
            path = path + "/";
        }

        for (var i = 0; i < path.length(); i++) {
            if (path.charAt(i) == '/') {
                while (i + 1 < path.length() && path.charAt(i + 1 ) == '/') {
                    i++;
                }
                i++;
                // i is now not slash, but can be end of string
                if (i == path.length()) {
                    break;
                }
                // i is now not slash and not end of string
                if (i < path.length() - 2 && path.charAt(i) == '.' && path.charAt(i + 1) == '.' && path.charAt(i + 2) == '/') {
                    //  "/../" -> "/"
                    if (!list.isEmpty()) {
                        list.removeLast();
                    }
                    i += 1; // to go to the next slash
                    continue;
                }
                // to go to the next slash
                if (i < path.length() - 1 && path.charAt(i) == '.' && path.charAt(i + 1) == '/') {
                    continue;
                }

                var sb = new StringBuilder();
                while (i < path.length() && path.charAt(i) != '/') {
                    sb.append(path.charAt(i));
                    i++;
                }
                list.add(sb.toString());
                i--;
            }
            else {
                throw new RuntimeException("Unexpected character");
            }
        }

        var result = new StringBuilder();
        for (var s : list) {
            result.append("/");
            result.append(s);
        }

        if (result.isEmpty()) {
            result.append("/");
        }

        return result.toString();
    }
}