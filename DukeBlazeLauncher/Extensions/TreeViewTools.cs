using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace DukeBlazeLauncher.Extensions
{
    public static class TreeViewTools
    {
// Method to check position of node within parent TreeView node
//  param fol: true=check for first of parent, false=check for last of parent
//  return with fol=true: true if node is NOT first in its parent else false
//  return with fol=false: true if node is NOT last in its parent else false
// Steve - 01/16/2025 23:53:07
        public static bool NotFirstOrLast(this TreeNode node, bool fol = true)
        {
            TreeNode parent = node.Parent;
            if (parent is not null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (fol)
                {
                    return index != 0;
                }
                else
                {
                    return index != parent.Nodes.Count - 1;
                }
            }
            else
            {
                return false;
            }
        }


        public static void MoveUp(this TreeNode node)
        {
            TreeNode parent = node.Parent;
            TreeView view = node.TreeView;
            if (parent is not null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index > 0)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index - 1, node);
                    view.SelectedNode = node;
                }
            }
            else if (node.TreeView.Nodes.Contains(node)) //root node
            {
                int index = view.Nodes.IndexOf(node);
                if (index > 0)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index - 1, node);
                    view.SelectedNode = node;
                }
            }
        }

        public static void MoveDown(this TreeNode node)
        {
            TreeNode parent = node.Parent;
            TreeView view = node.TreeView;
            if (parent is not null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index < parent.Nodes.Count - 1)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index + 1, node);
                    view.SelectedNode = node;
                }
            }
            else if (view is not null && view.Nodes.Contains(node)) //root node
            {
                int index = view.Nodes.IndexOf(node);
                if (index < view.Nodes.Count - 1)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index + 1, node);
                    view.SelectedNode = node;
                }
            }
        }

        public static string SaveTreeViewToJson(TreeView treeView)
        {
            var nodes = new List<NodeData>();
            foreach (TreeNode node in treeView.Nodes)
            {
                nodes.Add(ConvertNodeToNodeData(node));
            }
            string jsonString = JsonConvert.SerializeObject(nodes);
            return jsonString;
        }

        public static void LoadTreeViewFromJson(TreeView treeView, string json)
        {
            try
            {
                var nodes = JsonConvert.DeserializeObject<List<NodeData>>(json);
                treeView.Nodes.Clear();
                if (nodes is not null)
                {
                    foreach (var nodeData in nodes)
                    {
                        TreeNode rootNode = ConvertNodeDataToNode(nodeData);
                        treeView.Nodes.Add(rootNode);
                    }
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error deserializing JSON: " + ex.Message);
                Debug.WriteLine($"***Error deserializing JSON: {ex.Message}");
            }
        }

        private static TreeNode ConvertNodeDataToNode(NodeData nodeData)
        {
            TreeNode node = new TreeNode(nodeData.Text)
            {
                Tag = nodeData.Tag
            };

            foreach (var childData in nodeData.Children)
            {
                node.Nodes.Add(ConvertNodeDataToNode(childData));
            }

            return node;
        }

        private static NodeData ConvertNodeToNodeData(TreeNode node)
        {
            var nodeData = new NodeData
            {
                Text = node.Text,
                //Tag = node.Tag.ToString(), ******** Maybe this was right! ********
                Tag = (int)node.Tag,
                Children = new List<NodeData>()
            };

            foreach (TreeNode childNode in node.Nodes)
            {
                nodeData.Children.Add(ConvertNodeToNodeData(childNode));
            }

            return nodeData;
        }

        public static IEnumerable<TreeNode> Collect(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                yield return node;

                foreach (var child in Collect(node.Nodes))
                    yield return child;
            }
        }

        [Serializable]
        private class NodeData
        {
            public string Text { get; set; }
            public int Tag { get; set; }
            public List<NodeData> Children { get; set; }
        }
    }
}