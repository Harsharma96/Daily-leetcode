public class Solution
{
    private Dictionary<int, int> inorderMap;
    private int postIndex;

    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        inorderMap = new Dictionary<int, int>();

        for (int i = 0; i < inorder.Length; i++)
        {
            inorderMap[inorder[i]] = i;
        }

        postIndex = postorder.Length - 1;

        return Build(postorder, 0, inorder.Length - 1);
    }

    private TreeNode Build(int[] postorder, int left, int right)
    {
        if (left > right)
            return null;

        int rootVal = postorder[postIndex--];
        TreeNode root = new TreeNode(rootVal);

        int index = inorderMap[rootVal];

        root.right = Build(postorder, index + 1, right);

        root.left = Build(postorder, left, index - 1);

        return root;
    }
}