using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_CSharp
{
    public class Dictionarys
    {
        private enum ResourceType
        {
            Stone,
            Wood,
            Gold,
        }

        public Dictionarys()
        {
            Dictionary<ResourceType, int> dic = new Dictionary<ResourceType, int>()
            {
                { ResourceType.Stone, 10 },
                { ResourceType.Wood, 35 },
            };

            foreach(KeyValuePair<ResourceType, int> keyValuePair in dic)
            {
                Console.WriteLine(keyValuePair.Key + " : " + keyValuePair.Value);
            }

            dic[ResourceType.Wood] = 30;

            if(dic.TryGetValue(ResourceType.Stone, out int value))
            {
                Console.WriteLine(value);
            }
        }
    }
}
