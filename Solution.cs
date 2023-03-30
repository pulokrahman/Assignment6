public class Solution
{
    public static void Main()
    {
        int[] nums = new int[] { -1, -1, 1, 0,0,0, 2 };
        Solution solution = new Solution();
        IList<IList<int>> list = solution.ThreeSum(nums);
        foreach (List<int> l in list)
        {
            foreach (int i in l)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }

    public IList<IList<int>> ThreeSum(int[] nums)
    {

        Array.Sort(nums);
        //foreach (int num in nums)
        // Console.Write(num + " ");
        //    Console.WriteLine();
        IList<IList<int>> ans = new List<IList<int>>();
        //[-1,-1,-1,0,0,0,0,2,2,2]


        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            Dictionary<int, int> sums = new Dictionary<int, int>();
            HashSet<int> repeat = new HashSet<int>();

            int target = nums[i];
            int l = i + 1; //for some reason it was skipping to i*2
                           //if (target==-11)
                           //Console.WriteLine(l);
            for (int j = l; j < nums.Length; j++)
            {
                int sum = target + nums[j];
                //if(nums[i]==-11) {
                //Console.Write(i +" "+ j + " ");
                //Console.Write(target+ " "+ sum + " " + nums[j]);
                //Console.WriteLine();
                //} 
                if (!sums.ContainsKey(0 - sum))
                {
                    sums.Add(0 - sum, j);

                }
            }
            for (int j = i + 1; j < nums.Length; j++)
            {
                //if(nums[j]==1 && nums[i]==-11) {

                ///Console.WriteLine(sums.ContainsKey(10));
                //}
                if (!sums.ContainsKey(nums[j]))
                    continue;
                int values = sums[nums[j]];
                if (!repeat.Contains(nums[j]) && values != j)
                {

                    List<int> LowList = new List<int>() { nums[i], nums[j], 0 - nums[i] - nums[j] };
                    repeat.Add(nums[j]);
                    repeat.Add(0 - nums[j] - nums[i]);
                    ans.Add(LowList);

                }
            }

        }


        return ans;
    }

}