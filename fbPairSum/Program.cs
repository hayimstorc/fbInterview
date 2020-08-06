using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class FBStuf
{
    static void Main(string[] args)
    {
        testSubTrees();
        // Call numberOfWays() with test cases here
        string S = "facebook";
        Console.WriteLine(EncryptedWords.findEncryptedWord(S));
        int[] arr = { 5, 5, 6, 2, 1, 7, 8, 3 };//2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        int k = 4;
        Console.WriteLine(String.Format("{0} n of ways", PairSums.numberOfWays(arr, k)));
        string toCipher = "<yzf-k_x+!a";
        // Console.WriteLine(RotationalCipher.rotationalCipher(toCipher, 3)); 
        int[] restuls = LargestTripleProducts.findMaxProduct(arr);
        Array.ForEach(restuls, Console.WriteLine);
    }

    private static void testSubTrees()
    {
        //Testcase 1
        /*int n_1 = 3, q_1 = 1;
        String s_1 = "aba";
        TreeNode.Node root_1 = new TreeNode.Node(1);
        root_1.children.Add(new TreeNode.Node(2));
        root_1.children.Add(new TreeNode.Node(3));
        List<TreeNode.Query> queries_1 = new List<TreeNode.Query>();
        queries_1.Add(new TreeNode.Query(1, 'a'));
        int[] output_1 = TreeNode.CountOfNodes(root_1, queries_1, s_1);
        */
        int n_2 = 7, q_2 = 3;
        String s_2 = "abaacab";
        TreeNode.Node root_2 = new TreeNode.Node(1);
        root_2.children.Add(new TreeNode.Node(2));
        root_2.children.Add(new TreeNode.Node(3));
        root_2.children.Add(new TreeNode.Node(7));
        root_2.children[0].children.Add(new TreeNode.Node(4));
        root_2.children[0].children.Add(new TreeNode.Node(5));
        root_2.children[1].children.Add(new TreeNode.Node(6));
        List<TreeNode.Query> queries_2 = new List<TreeNode.Query>();
      //  queries_2.Add(new TreeNode.Query(1, 'a'));
       // queries_2.Add(new TreeNode.Query(2, 'b'));
           queries_2.Add(new TreeNode.Query(3, 'a'));
        int[] output_2 = TreeNode.CountOfNodes(root_2, queries_2, s_2);
        int[] expected_2 = { 4, 1, 2 };

    }
}
// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
class PairSums
{

    public static int numberOfWays(int[] arr, int k)
    {
        // Write your code here
        int nPfWays = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                nPfWays += (arr[i] + arr[j] == k ? 1 : 0);
            }
        }
        return nPfWays;
    }//O^2 complexity

}

public class RotationalCipher
{
    readonly string[] alpha = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z" };
    readonly string[] alphaUpper = { "A", "B", "C", "D", "E", "F", "g", "H", "I", "J", "K", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z" };


    public static string rotationalCipher(string input, int rotationFactor)
    {
        string ciphered = "";//maybe string builder
        //regex for alphanumeric only - actually don't need that since I replace by condioitn
        string onlyAlphanmeric = Regex.Replace(input, "[^a-zA-Z0-9]", "");
        Console.WriteLine(onlyAlphanmeric);
        for (int i = 0; i < onlyAlphanmeric.Length; i++)
        {
            //for alpha - use k % (length of alpha or aplhaUpper length) to get the index of the replacement
            //char from the array and add it to ciphered
            //for numeric - use k mod 10 to get the replacement int
            Console.WriteLine(onlyAlphanmeric[i]);
            if ((short)onlyAlphanmeric[i] >= 97 && (short)onlyAlphanmeric[i] <= 122)
            {
                ciphered += (char)(((onlyAlphanmeric[i] + rotationFactor - 97) % 26) + 97);
            }
        }
        return ciphered;
    }
}


// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
class LargestTripleProducts
{
    public static int[] findMaxProduct(int[] arr)
    {
        // Write your code here
        int[] largest = new int[3];
        int[] output = new int[arr.Length];
        output[0] = -1;
        output[1] = -1;
        largest[0] = arr[0];
        largest[1] = arr[1];
        for (int i = 2; i < output.Length; i++)
        {
            largest = maintainLargest(largest, arr[i]);
            output[i] = largest[0] * largest[1] * largest[2];
        }
        return output;
    }

    private static int[] maintainLargest(int[] l, int e)
    {
        if (l[0] > l[2])
        {
            int t = l[2];
            l[2] = l[0];
            l[0] = t;
            if (l[1] > l[2])
            {
                t = l[1];
                l[1] = l[2];
                l[2] = t;
            }
        }
        if (e > l[2])
        {
            l[0] = l[1];
            l[1] = l[2];
            l[2] = e;
        }

        return l;
    }
}

public class EncryptedWords
{

    public static String findEncryptedWord(String s)
    {
        string R = "";
        int m = s.Length % 2 == 0 ? s.Length / 2 - 1 : s.Length / 2;
        R = encryptWords(s, m);
        return R;
    }

    private static String encryptWords(string s, int m)
    {
        //int m = s.Length % 2 == 0 ? s.Length / 2 : (int) Math.Ceiling(s.Length / 2.0);
        if (s.Length < 3)
            return s;
        return s[m] +
            encryptWords(s.Substring(0, m), m % 2 == 0 ? m / 2 - 1 : m / 2) +
            encryptWords(s.Substring(m + 1), m % 2 == 0 ? m / 2 - 1 : m / 2);

    }
}

public class TreeNode
{

    // Tree Node 
    public class Node
    {
        public int val;
        public List<Node> children;

        public Node()
        {
            val = 0;
            children = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            children = new List<Node>();
        }

        public Node(int _val, List<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public class Query
    {
        internal int u;
        internal char c;
        internal Query(int u, char c)
        {
            this.u = u;
            this.c = c;
        }
    }

    // Add any helper functions you may need here


    public static int[] CountOfNodes(Node root, List<Query> queries, String s)
    {
        // Write your code here
        List<int> queriesCounters = new List<int>(); ;
        foreach (Query q in queries)
        {
            Node searchRoot = GetStartingNode(root, q.u);
            if (searchRoot == null)
            {
                queriesCounters.Add(0);
            }
            else
            {
                int count = 0;
                CountNodes(searchRoot, q, s, ref count);
                queriesCounters.Add(count);
            }
        }
        return queriesCounters.ToArray();


    }

    private static Node GetStartingNode(Node root, int u)
    {
        if (root != null)
        {
            if (root.val == u)
                return root;
            else if (root.children.Count > 0)
            {
                foreach (Node child in root.children)
                {
                    Node result = GetStartingNode(child, u);
                    if (result != null) {
                        return result;
                    }
                }
            }
        }
        return null;
    }

    private static int CountNodesReturn(Node root, Query q, string s)
    {

        if (root.children != null && root.children.Count > 0)
        {
            foreach (Node child in root.children)
            {
                return (s[root.val - 1] == q.c ? 1 : 0) + CountNodesReturn(child, q, s);
            }
        }
        else
            return s[root.val - 1] == q.c ? 1 : 0;
        return 0;
    }

    private static void CountNodes(Node root, Query q, string s, ref int count)
    {
        count += (s[root.val - 1] == q.c ? 1 : 0);
        if (root.children != null && root.children.Count > 0)
        {
            foreach (Node child in root.children)
            {
                CountNodes(child, q, s, ref count);
            }
        }

    }
}
