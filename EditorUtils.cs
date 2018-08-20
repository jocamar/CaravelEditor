using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CaravelEditor
{
    public static class EditorUtils
    {
        public static XmlNode GetDifference(XmlNode origNode, XmlNode currNode)
        {
            if (origNode == null || currNode == null)
            {
                return null;
            }
            
            var doc = new XmlDocument();
            XmlElement change;

            bool different = false;
            foreach (XmlAttribute attribute in origNode.Attributes)
            {
                if (currNode.Attributes[attribute.Name] == null || attribute.Value != currNode.Attributes[attribute.Name].Value)
                {
                    different = true;
                    break;
                }
            }

            if (origNode.ChildNodes.Count <= 0 && currNode.ChildNodes.Count <= 0)
            {
                if (different)
                {
                    change = doc.CreateElement("Node-Changed");
                    change.SetAttribute("name", currNode.Name);
                    change.SetAttribute("xpath", GetXPathToNode(origNode));
                    var innerNodeFragment = doc.CreateDocumentFragment();
                    innerNodeFragment.InnerXml = currNode.OuterXml;

                    change.AppendChild(innerNodeFragment);
                    return change;
                }
                else
                {
                    return null;
                }
            }

            var diffNodes = new List<XmlNode>();

            foreach (XmlNode child in origNode.ChildNodes)
            {
                var xpath = GetXPathToNode(child);
                xpath = xpath.Substring(xpath.LastIndexOf("/") + 1);
                var currElement = currNode.SelectSingleNode(xpath);

                if (currElement != null)
                {
                    change = (XmlElement) GetDifference(child, currElement);

                    if (change != null)
                    {
                        var importedNode = doc.ImportNode(change, true);
                        diffNodes.Add(importedNode);
                    }
                }
                else
                {
                    change = doc.CreateElement("Node-Removed");
                    change.SetAttribute("name", child.Name);
                    change.SetAttribute("xpath", GetXPathToNode(child));
                    diffNodes.Add(change);
                }
            }

            foreach (XmlNode child in currNode.ChildNodes)
            {
                var xpath = GetXPathToNode(child);
                xpath = xpath.Substring(xpath.LastIndexOf("/") + 1);
                var origElement = origNode.SelectSingleNode(xpath);

                if (origElement == null)
                {
                    change = doc.CreateElement("Node-Added");
                    change.SetAttribute("name", child.Name);
                    change.SetAttribute("xpath", GetXPathToNode(child));

                    var importedNode = doc.ImportNode(child, true);
                    change.AppendChild(importedNode);
                    diffNodes.Add(change);
                }
            }

            if (diffNodes.Count > 0 || different)
            {
                change = doc.CreateElement("Node-Changed");
                change.SetAttribute("name", origNode.Name);
                change.SetAttribute("xpath", GetXPathToNode(origNode));

                var elemString = currNode.OuterXml;
                if (currNode.InnerXml != "")
                {
                    elemString = elemString.Replace(currNode.InnerXml, "");
                }

                var innerNodeFragment = doc.CreateDocumentFragment();
                innerNodeFragment.InnerXml = elemString;

                var node = change.AppendChild(innerNodeFragment);
                
                foreach (var diff in diffNodes)
                {
                    node.AppendChild(diff);
                }

                return change;
            }
            else
            {
                return null;
            }
        }

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

                ++count;
            }
            throw new InvalidOperationException("Child node somehow not found in its parent's ChildNodes property.");
        }
    }
}
