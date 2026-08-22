public class Solution {
    public IList<int> GetRow(int rowIndex) {
        List<int> row = new List<int>();

        for (int i = 0; i <= rowIndex; i++) {
            row.Add(1);

            for (int j = i - 1; j > 0; j--) {
                row[j] = row[j] + row[j - 1];
            }
        }

        return row;
    }
}