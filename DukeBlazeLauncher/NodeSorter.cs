// Example of how to use NodeSorter
// https://stackoverflow.com/questions/50922465/how-to-sort-the-child-nodes-of-treeview
// You call it by assigning it and then calling sort:
//   treeView1.TreeViewNodeSorter = new NodeSorter();
//   treeView1.Sort();
//
// More info: https://stackoverflow.com/questions/73210073/sort-specific-node-in-treeview

using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;

namespace DukeBlazeLauncher
{
    public class NodeSorter(SortOrder sortOrder = SortOrder.Ascending) : IComparer
    {
        public SortOrder SortOrder { get; set; } = sortOrder;

        public int Compare(object x, object y)
        {
            if (x is not TreeNode tx || y is not TreeNode ty) return 0;

            string s1 = tx.Text;
            while (s1.Length > 0 && char.IsDigit(s1[^1])) s1 = s1[..^1];
            s1 += tx.Text[s1.Length..].PadLeft(12, '0');

            string s2 = ty.Text;
            while (s2.Length > 0 && char.IsDigit(s2[^1])) s2 = s2[..^1];
            s2 += ty.Text[s2.Length..].PadLeft(12, '0');

            return SortOrder switch
            {
                SortOrder.Descending => string.Compare(s1, s2) * -1,
                SortOrder.Ascending => string.Compare(s1, s2),
                _ => 1
            };
        }
    }

/*  A couple of extension methods for the TreeView and TreeNode types.
    You can call them as follows:

    // To sort the whole TreeView
    YourTreeView.Sort(SortOrder.Descending);

    // Or the children of the selected node
    YourTreeView.SelectedNode.Sort(SortOrder.Ascending);
*/
    public static class TreeViewExtensions
    {
        public static void Sort(this TreeView self, SortOrder order = SortOrder.Ascending)
        {
            self.TreeViewNodeSorter = new NodeSorter(order);
            self.BeginUpdate();
            self.Sort();
            self.EndUpdate();
        }

        // New version for .NET 8+, c# 12+
        public static void Sort(this TreeNode self, SortOrder order = SortOrder.Ascending)
        {
            if (self.TreeView is null) return;
            TreeNode[] tmp;
            TreeView tv = self.TreeView;
            NaturalStringComparer comparer = new();

            if (order == SortOrder.Descending)
                tmp = [.. self.Nodes.Cast<TreeNode>().OrderByDescending(n => n.Text, comparer)];
            else
                tmp = [.. self.Nodes.Cast<TreeNode>().OrderBy(n => n.Text, comparer)];

            var sorter = tv.TreeViewNodeSorter as NodeSorter ?? new NodeSorter();
            sorter.SortOrder = SortOrder.None;

            tv.TreeViewNodeSorter = sorter;
            tv.BeginUpdate();
            self.Nodes.Clear();

            // Following line throws NullReferenceException, not sure why  :-O
            //self.Nodes.AddRange(tmp);

            // Alternative to AddRange() which actually works  ;-)
            for (int c = tmp.Count() - 1; c >= 0; c--)
                self.Nodes.Add(tmp[c]);

            tv.EndUpdate();
        }
    }

    // https://stackoverflow.com/questions/985657/use-own-icomparert-with-linq-orderby Answer by Maxence
    public sealed class NaturalStringComparer(
      ListSortDirection direction = ListSortDirection.Ascending) : IComparer<string>
    {
        public ListSortDirection Direction { get; set; } = direction;
        public int Compare(string x, string y)
        {
            return Direction switch
            {
                ListSortDirection.Ascending => NaturalStringComparer.SafeNativeMethods.StrCmpLogicalW(x, y),
                ListSortDirection.Descending => NaturalStringComparer.SafeNativeMethods.StrCmpLogicalW(y, x),
                _ => 0
            };
        }

        [SuppressUnmanagedCodeSecurity]
        static class SafeNativeMethods
        {
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
            public static extern int StrCmpLogicalW(string psz1, string psz2);
        }
    }
}