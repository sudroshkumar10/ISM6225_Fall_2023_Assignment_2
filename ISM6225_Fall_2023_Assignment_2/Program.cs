/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Initialize a list to store the missing ranges
                List<IList<int>> missingRanges = new List<IList<int>>();

                // Helper function to add a range to the result
                void AddRange(int start, int end)
                {
                    if (start == end)
                    {
                        missingRanges.Add(new List<int> { start });
                    }
                    else
                    {
                        missingRanges.Add(new List<int> { start, end });
                    }
                }

                // Handle the case where lower is greater than the first element in nums
                if (nums.Length > 0 && lower < nums[0])
                {
                    AddRange(lower, nums[0] - 1);
                }

                // Check for missing ranges between elements in nums
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] - nums[i - 1] > 1)
                    {
                        AddRange(nums[i - 1] + 1, nums[i] - 1);
                    }
                }

                // Handle the case where upper is smaller than the last element in nums
                if (nums.Length > 0 && upper > nums[nums.Length - 1])
                {
                    AddRange(nums[nums.Length - 1] + 1, upper);
                }

                return missingRanges;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        // This function checks if a given input string 's' contains valid parentheses.

        public static bool IsValid(string s)
        {
            // Create a stack to hold open brackets.
            Stack<char> stack = new Stack<char>();

            // Iterate through each character in the input string.
            foreach (char c in s)
            {
                // If the character is an open bracket, push it onto the stack.
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                // If the character is a closing bracket...
                else if (c == ')' && (stack.Count == 0 || stack.Pop() != '('))
                {
                    // Check if it matches with an open bracket on the stack. If not, return false.
                    return false;
                }
                else if (c == '}' && (stack.Count == 0 || stack.Pop() != '{'))
                {
                    // Check if it matches with an open bracket on the stack. If not, return false.
                    return false;
                }
                else if (c == ']' && (stack.Count == 0 || stack.Pop() != '['))
                {
                    // Check if it matches with an open bracket on the stack. If not, return false.
                    return false;
                }
            }

            // After processing all characters, check if there are any unmatched open brackets left on the stack.
            return stack.Count == 0;
        }




        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        // This function calculates the maximum profit that can be achieved by buying and selling a stock.

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Check if the input prices array is null or has less than 2 elements.
                if (prices == null || prices.Length < 2)
                {
                    return 0; // Cannot make a profit with less than two prices.
                }

                // Initialize variables to track the maximum profit and the minimum price.
                int maxProfit = 0;
                int minPrice = prices[0];

                // Iterate through the prices starting from the second day.
                for (int i = 1; i < prices.Length; i++)
                {
                    // If the current price is lower than the minimum price seen so far, update the minimum price.
                    if (prices[i] < minPrice)
                    {
                        minPrice = prices[i];
                    }
                    // If the current price is higher, calculate the profit from buying at the minimum price and selling at the current price.
                    else
                    {
                        int currentProfit = prices[i] - minPrice;
                        maxProfit = Math.Max(maxProfit, currentProfit); // Update the maximum profit if the current profit is higher.
                    }
                }

                return maxProfit; // Return the maximum profit achieved.
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        // This function checks if a given string is strobogrammatic, which means it reads the same when rotated 180 degrees.
        public static bool IsStrobogrammatic(string num)
        {
            try
            {
                // Initialize two pointers, 'left' and 'right,' to check the string from the outer edges towards the center.
                int left = 0;
                int right = num.Length - 1;

                // Continue checking pairs of characters until the 'left' pointer is less than or equal to the 'right' pointer.
                while (left <= right)
                {
                    // Check if the pair of characters at the 'left' and 'right' positions is strobogrammatic.
                    if (!IsStrobogrammaticPair(num[left], num[right]))
                    {
                        return false; // If the pair is not strobogrammatic, return false.
                    }

                    left++;
                    right--;
                }

                return true; // If all pairs are strobogrammatic, return true, indicating that the input string is strobogrammatic.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // This helper function checks if a pair of characters is strobogrammatic.
        private static bool IsStrobogrammaticPair(char a, char b)
        {
            // A pair is strobogrammatic if it consists of the following character combinations:
            // '0' and '0', '1' and '1', '6' and '9', '8' and '8', '9' and '6'.
            return (a == '0' && b == '0') ||
                   (a == '1' && b == '1') ||
                   (a == '6' && b == '9') ||
                   (a == '8' && b == '8') ||
                   (a == '9' && b == '6');
        }



        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        // This function counts the number of good pairs in the given array 'nums.'
        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                int count = 0; // Initialize a count to keep track of the good pairs.
                Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

                // Iterate through the elements of the 'nums' array.
                foreach (int num in nums)
                {
                    // If the 'frequencyMap' contains the current number, it means we've seen it before.
                    if (frequencyMap.ContainsKey(num))
                    {
                        // Increase the 'count' by the frequency of the current number in the 'frequencyMap.'
                        count += frequencyMap[num];

                        // Increment the frequency of the current number in the 'frequencyMap.'
                        frequencyMap[num]++;
                    }
                    else
                    {
                        // If the current number is not in the 'frequencyMap,' add it with a frequency of 1.
                        frequencyMap[num] = 1;
                    }
                }

                return count; // Return the total count of good pairs.
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        // This function finds the third distinct maximum number in the 'nums' array.
        // If the third maximum does not exist, it returns the maximum number.
        public static int ThirdMax(int[] nums)
        {
            try
            {
                long firstMax = long.MinValue;
                long secondMax = long.MinValue;
                long thirdMax = long.MinValue;

                // Iterate through the elements in the 'nums' array.
                foreach (int num in nums)
                {
                    // Check if the current number is greater than the first maximum.
                    if (num > firstMax)
                    {
                        // Update the third, second, and first maximum values.
                        thirdMax = secondMax;
                        secondMax = firstMax;
                        firstMax = num;
                    }
                    // If the current number is between the first and second maximum, update the third and second maximum values.
                    else if (num < firstMax && num > secondMax)
                    {
                        thirdMax = secondMax;
                        secondMax = num;
                    }
                    // If the current number is between the second and third maximum, update the third maximum.
                    else if (num < secondMax && num > thirdMax)
                    {
                        thirdMax = num;
                    }
                }

                // Return the third maximum if it's not equal to the minimum value, otherwise, return the first maximum.
                return thirdMax != long.MinValue ? (int)thirdMax : (int)firstMax;
            }
            catch (Exception)
            {
                throw;
            }
        }



        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        // This function generates all possible states of the 'currentState' string after one valid move.
        // A valid move involves flipping two consecutive "++" into "--" in the string.
        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                List<string> result = new List<string>();

                // Iterate through the characters in the 'currentState' string, except the last character.
                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    // Check if the current character and the next character are both '+' (consecutive "++").
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Create a new character array to represent the updated state.
                        char[] newState = currentState.ToCharArray();

                        // Flip the consecutive "++" to "--" in the new state.
                        newState[i] = '-';
                        newState[i + 1] = '-';

                        // Add the new state to the result list as a valid move.
                        result.Add(new string(newState));
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        // This function removes vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U') from the input string.
        public static string RemoveVowels(string s)
        {
            // Create a StringBuilder to build the result string efficiently.
            StringBuilder result = new StringBuilder();

            // Iterate through each character in the input string.
            foreach (char c in s)
            {
                // Check if the current character is not a vowel by comparing it to a list of vowel characters.
                if (c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u' &&
                    c != 'A' && c != 'E' && c != 'I' && c != 'O' && c != 'U')
                {
                    // If the character is not a vowel, add it to the result.
                    result.Append(c);
                }
            }

            // Convert the StringBuilder to a string and return the result with vowels removed.
            return result.ToString();
        }



        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
