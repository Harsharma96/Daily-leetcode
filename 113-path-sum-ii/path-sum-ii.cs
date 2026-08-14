/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        IList<IList<int>> result = new List<IList<int>>();
        List<int> path = new List<int>();

        DFS(root, targetSum, path, result);

        return result;
    }

    private void DFS(TreeNode node, int target, List<int> path, IList<IList<int>> result)
    {
        if (node == null)
            return;

        path.Add(node.val);
        target -= node.val;

     
        if (node.left == null && node.right == null && target == 0)
        {
            result.Add(new List<int>(path));
        }

        DFS(node.left, target, path, result);
        DFS(node.right, target, path, result);

        
        path.RemoveAt(path.Count - 1);
    }
}