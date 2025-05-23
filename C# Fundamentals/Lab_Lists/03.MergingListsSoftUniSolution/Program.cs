﻿namespace _03.MergingListsSoftUniSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            //List<int> largerList = nums1.Count >= nums2.Count ? nums1 : nums2;
            List<int> resultNums = new List<int>();

            for (int i = 0; i < Math.Min(nums1.Count, nums2.Count); i++)
            {
                resultNums.Add(nums1[i]);
                resultNums.Add(nums2[i]);
            }

            //resultNums.AddRange(largerList.Skip(Math.Min(nums1.Count, nums2.Count)));

            if (nums1.Count > nums2.Count)
                resultNums.AddRange(GetRemainingElements(nums1, nums2));
            else if (nums2.Count > nums1.Count)
                resultNums.AddRange(GetRemainingElements(nums2, nums1));

            Console.WriteLine(string.Join(" ", resultNums));
        }

        static List<int> GetRemainingElements(List<int> longerList, List<int> shorterList)
        {
            List<int> nums = new List<int>();
            for (int i = shorterList.Count; i < longerList.Count; i++)
                nums.Add(longerList[i]);
            return nums;
        }
    }
}
