using System;
using System.IO;
using System.Xml;

namespace CaravelEditor
{
    public static class EditorUtils
    {
        public static string GetXPathToNode(XmlNode node)
        {
            if (node.NodeType == XmlNodeType.Attribute)
            {
                // attributes have an OwnerElement, not a ParentNode; also they have
                // to be matched by name, not found by position
                return string.Format("{0}/@{1}", GetXPathToNode(((XmlAttribute)node).OwnerElement), "*");
            }

            if (node.ParentNode == null)
            {
                // the only node with no parent is the root node, which has no path
                return "";
            }

            // the path to a node is the path to its parent, plus "/*[n]", where 
            // n is its position among its siblings.
            return string.Format("{0}/{1}[{2}]", GetXPathToNode(node.ParentNode), "*", GetNodePosition(node));
        }

        public static bool IsSubPathOf(this string path, string baseDirPath)
        {
            string normalizedPath = WithEnding(Path.GetFullPath(path.Replace('/', '\\')), "\\");

            string normalizedBaseDirPath = WithEnding(Path.GetFullPath(baseDirPath.Replace('/', '\\')), "\\");

            return normalizedPath.StartsWith(normalizedBaseDirPath, StringComparison.OrdinalIgnoreCase);
        }

        private static string WithEnding(string str, string ending)
        {
            if (str == null)
                return ending;

            string result = str;

            // Right() is 1-indexed, so include these cases
            // * Append no characters
            // * Append up to N characters, where N is ending length
            for (int i = 0; i <= ending.Length; i++)
            {
                string tmp = result + Right(ending, i);
                if (tmp.EndsWith(ending))
                    return tmp;
            }

            return result;
        }

        private static string Right(string value, int length)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", length, "Length is less than zero");
            }

            return (length < value.Length) ? value.Substring(value.Length - length) : value;
        }

        private static int GetNodePosition(XmlNode child)
        {
            int count = 1;
            for (int i = 0; i < child.ParentNode.ChildNodes.Count; i++)
            {
                if (child.ParentNode.ChildNodes[i] == child)
                {
                    // tricksy XPath, not starting its positions at 0 like a normal language
                    return count;
                }
                if (child.ParentNode.ChildNodes[i].Name == child.Name)
                {
                    ++count;
                }
            }
            throw new InvalidOperationException("Child node somehow not found in its parent's ChildNodes property.");
        }
    }
}
