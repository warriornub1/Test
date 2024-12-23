using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.CSharpBasic.Dictionary
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
            Dictionary<ResourceType, int> resourceTypeAmountDictionary = new Dictionary<ResourceType, int>()
            {
                { ResourceType.Stone, 10 },
                { ResourceType.Wood,  35},
            };

            foreach(KeyValuePair<ResourceType, int> keyValuePair in resourceTypeAmountDictionary)
            {
                Console.WriteLine(keyValuePair.Key + " : " + keyValuePair.Value);
            }

            foreach (ResourceType resourceType in resourceTypeAmountDictionary.Keys)
            {
                Console.WriteLine(resourceType + " : " + resourceTypeAmountDictionary[resourceType]);
            }


            resourceTypeAmountDictionary[ResourceType.Wood] = 30;
            if (resourceTypeAmountDictionary.TryGetValue(ResourceType.Wood, out int woodAmount)) {
                Console.WriteLine(woodAmount);
            }
        }
    }
}
