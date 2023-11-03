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

        public class PrinterLabel
        {
            private int _LabelHeigh;
            private int _LabelWidth;
            private string _description;

            public int LabelHeigh
            {
                get => _LabelHeigh;
                set
                {
                    _LabelHeigh = value;
                }
            }
            public int LabelWidth
            {
                get => _LabelWidth;
                set
                {
                    _LabelWidth = value;
                }
            }
            public string Description
            {
                get { return _description; }
                set
                {
                    if (value.Length > 0 && value.Length < 10)
                        this._description = value;
                    else
                        throw new System.Exception("欄位上限為10");
                }
            }
        }

        static void ClassTest()
        {
            /*
                   只是拿來學習Class的Code
             */
            PrinterLabel label = new PrinterLabel();
            int getLH;
            label.LabelHeigh = 10;
            getLH = label.LabelHeigh;
            label.Description = "1111111111";
            System.Console.Write("");
        }
        static void Main(string[] args)
        {
            ClassTest();


            /* 以下是ZPL API範本 */
            byte[] zpl = Encoding.UTF8.GetBytes("^XA^MNN^LL800^FO400,10^BQN,2,10^FDMM,AHTTPS://T2DC.CN/99.1000.1/AB0401005001012430101DJ^FS^FO100,407^BQN,2,10^FDMM,AHTTPS://T2DC.CN/99.1000.1/AB0401005001012430101DJS20000500*********00230529B001000100010539825295977638568^FS^FO396,17^GB377,377^FS^FO96,414^GB377,377^FS^FO150,40^A0N,40,40^FDQR Code Short^FS^FO480,500^A0N,40,40^FDQR Code Long^FS^XZ");
            // adjust print density (8dpmm), label width (4 inches), label height (6 inches), and label index (0) as necessary
            var request = (HttpWebRequest)WebRequest.Create("http://api.labelary.com/v1/printers/8dpmm/labels/4x6/0/");
            request.Method = "POST";
            //request.Accept = "application/pdf"; // omit this line to get PNG images back
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = zpl.Length;

            var requestStream = request.GetRequestStream();
            requestStream.Write(zpl, 0, zpl.Length);
            requestStream.Close();

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();
                var fileStream = File.Create("label.png"); // change file name for PNG images
                responseStream.CopyTo(fileStream);
                responseStream.Close();
                fileStream.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine("Error: {0}", e.Status);
            }
            return;
        }
    }
}
