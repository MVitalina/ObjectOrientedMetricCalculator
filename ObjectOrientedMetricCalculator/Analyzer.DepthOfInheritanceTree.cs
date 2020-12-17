using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedMetricCalculator
{
    partial class Analyzer
    {
        public List<Tuple<string, int>> GetDepthOfInheritanceTree()
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();

            foreach (string className in AllClasses)
            {
                result.Add(new Tuple<string, int>(className, GetDepthRecursive(className)));
            }

            return result.OrderByDescending(x => x.Item2).ToList();
        }

        private int GetDepthRecursive(string node)
        {
            IEnumerable<Tuple<string, string>> childList = ChildList(node);
            if (!childList.Any())
            {
                return 1;
            }

            int maxDepth = 0;

            foreach (var child in childList)
            {
                int depth = GetDepthRecursive(child.Item2) + 1;
                if (maxDepth < depth)
                {
                    maxDepth = depth;
                }
            }

            return maxDepth;
        }
    }
}
