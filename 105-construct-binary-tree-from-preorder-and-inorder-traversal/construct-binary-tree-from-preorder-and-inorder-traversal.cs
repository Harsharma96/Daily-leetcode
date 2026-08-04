public class Solution
{
    private Dictionary<int, int> inorderMap = new Dictionary<int, int>();
    private int preorderIndex = 0;

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        
        for (int i = 0; i < inorder.Length; i++)
        {
            inorderMap[inorder[i]] = i;
        }

        return Build(preorder, 0, inorder.Length - 1);
    }

    private TreeNode Build(int[] preorder, int left, int right)
    {
        if (left > right)
            return null;

        int rootValue = preorder[preorderIndex++];
        TreeNode root = new TreeNode(rootValue);

        int mid = inorderMap[rootValue];

        root.left = Build(preorder, left, mid - 1);
        root.right = Build(preorder, mid + 1, right);

        return root;
    }
}