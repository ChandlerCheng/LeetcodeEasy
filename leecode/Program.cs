using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace leecode
{
    class Program
    {
        static bool IsPowerOfTwo(int n)
        {
            /* LeetCode #231 */
            /* LeetCode #326 , Is Power Of Three */
            if (n < 0)
            {
                return false;
            }

            double nn = n * 1.0;
            while (nn >= 2)
            {
                nn /= 2;
            }
            return nn == 1.0;
        }
        static bool IsSubsequence(string s, string t)
        {
            /* LeetCode #392 Is Subsequence 是否為子序列 */
            if (s == "")
                return true;
            char[] arr = s.ToCharArray();
            int idx = 0;

            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == arr[idx])
                {
                    idx += 1;
                    if (idx == arr.Length)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static int[] PlusOne(int[] digits)
        {
            /* LeetCode #66 Plus One 加上一 */
            int len = digits.Length;
            int num;
            int add = 1;

            for (int i = len - 1; i >= 0; i--)
            {
                num = digits[i] + add;
                if (num == 10)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i] = num;
                    return digits;
                }
            }

            int[] newDigits = new int[digits.Length + 1];

            newDigits[0] = 1;
            Array.Copy(digits, 0, newDigits, 1, digits.Length);

            return newDigits;

        }
        // 以下是自己寫的
        static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int need = target - nums[i];
                if (dictionary.ContainsKey(need))
                {
                    return new int[] { dictionary[need], i };
                }
                else
                {
                    if (dictionary.ContainsKey(nums[i]))    // 重複的Key會導致出錯
                        continue;
                    else 
                        dictionary.Add(nums[i], i);
                }
            }

            return null;
        }
       
        static bool IsPalindrome(int x)
        {
            /* LeetCode #9 Palindrome Number*/
            string arrSt = x.ToString();
            char[] arr = arrSt.ToCharArray();
            int max = arr.Length / 2;
            int count = 0;
            int i = 0;

            for ( i = 0; i < max; i++)
            {
                if (arr[i] == arr[arr.Length-1 - i])
                    count++;
            }

            if (count == max)
                return true;

            return false;
        }
        static int RomanToInt(string s)
        {
            /* 
             * LeetCode #13 RomanToInt
             * 
             */


            return 0;
        }
        static void LongestCommonPrefix(string[] strs)
        {
            /* 
             * LeetCode #14 Longest Common Prefix
             */

        }
        static void Main(string[] args)
        {
            
            return;
        }
    }
}
