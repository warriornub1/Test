using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Hashing
{
    public class f_Encoding_Decoding
    {
        public f_Encoding_Decoding()
        {
            List<string> list = new List<string>()
            {
                "neet", "code", "love", "you"
            };
            Console.WriteLine("Encode");
            string result = Encode(list);
            Console.WriteLine(result);

            Console.WriteLine("Decode");
            Console.WriteLine(Decode(result));
        }
        public string Encode(IList<string> strs)
        {
            if (strs.Count == 0)
                return "";
            List<int> sizes = new List<int>();
            string res = "";
            foreach (string s in strs)
            {
                res += s.Length + "#" + s;
            }
            return res;
        }

        public List<string> Decode(string s)
        {
            List<string> res = new List<string>();
            int i = 0;
            while (i < s.Length)
            {
                int j = i;
                while (s[j] != '#')
                {
                    j++;
                }
                int length = int.Parse(s.Substring(i, j - 1));
                i = j + 1;
                j = i + length;
                res.Add(s.Substring(i, length));
                i = j;
            }
            return res;
        }
    }

}
