public class FileSystem {

    public class Node {
        
        public static Node CreateFile(string path, string? content = null)
        {
            return new Node()
            {
                Path = path,
                IsFile = true,
                IsFolder = false,
                Content = content,
            };
        }
        
        public static Node CreateFolder(string path)
        {
            return new Node()
            {
                Path = path,
                IsFile = false,
                IsFolder = true,
            };
        }

        public string Path {get; set;}
        public bool IsFile {get; set;}
        public bool IsFolder {get; set;}
        public Dictionary<string, Node> Children {get; set;} = new ();
        public string? Content {get; set;} = null;
    }

    public Node _root = new Node();

    public FileSystem() {
    }
    
    public IList<string> Ls(string path)
    {
        var parts = path.Split('/');
        var current = _root;
        var sbPrefix = new StringBuilder();
        sbPrefix.Append('/');
        foreach (var part in parts)
        {
            if (string.IsNullOrWhiteSpace(part))
            {
                continue;
            }

            if (!current.Children.TryGetValue(part, out var nextChildren))
            {
                return new List<string>();
            }
            
            sbPrefix.Append(current.Path);
            sbPrefix.Append('/');

            current = nextChildren;
        }

        if (current.IsFile)
        {
            return new List<string>() {current.Path};
        }

        return current.Children.Keys.OrderBy(x => x).ToList();
    }
    
    public void Mkdir(string path) {
        var parts = path.Split('/');
        var current = _root;

        foreach (var part in parts)
        {
            if (string.IsNullOrWhiteSpace(part))
            {
                continue;
            }
            
            if (!current.Children.TryGetValue(part, out var existingNode))
            {
                var newFolder = Node.CreateFolder(part);
                current.Children[part] = newFolder;
                current = newFolder;
            }
            else
            {
                if (existingNode.IsFile)
                {
                    throw new Exception();
                }

                current = existingNode;
            }
        }
    }
    
    public void AddContentToFile(string filePath, string content) {
        var parts = filePath.Split('/');
        var current = _root;
        // 0 is always empty
        for (int i = 1; i < parts.Length; i++)
        {
            var part = parts[i];

            
            current.Children.TryGetValue(part, out var existingNode);
            if (existingNode != null)
            {
                current = existingNode;
            }
            else if (i == parts.Length - 1)
            {
                var newFile = Node.CreateFile(part, "");
                current.Children[part] = newFile;
                current = newFile;
            }
            else
            {
                return;
            }
        }

        current.Content += content;
    }
    
    public string ReadContentFromFile(string filePath)
    {
        var parts = filePath.Split('/');
        var current = _root;
        for (int i = 1; i < parts.Length; i++)
        {
            var part = parts[i];
            current.Children.TryGetValue(part, out var existingNode);
            if (existingNode != null)
            {
                current = existingNode;
            }
            else
            {
                return "";
            }
        }

        return current.Content;
    }
}