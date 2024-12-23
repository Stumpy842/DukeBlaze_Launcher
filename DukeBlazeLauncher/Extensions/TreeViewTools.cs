using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DragDukeLauncher.Extensions
{
    public static class TreeViewTools
    {

        public static void MoveUp(this TreeNode node)
        {
            TreeNode parent = node.Parent;
            TreeView view = node.TreeView;
            if (parent != null)
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
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index < parent.Nodes.Count - 1)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index + 1, node);
                    view.SelectedNode = node;
                }
            }
            else if (view != null && view.Nodes.Contains(node)) //root node
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
                if (nodes != null)
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
                Tag = node.Tag.ToString(),
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
            public string Tag { get; set; }
            public List<NodeData> Children { get; set; }
        }
    }
}