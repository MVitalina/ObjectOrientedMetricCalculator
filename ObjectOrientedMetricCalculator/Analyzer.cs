using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ObjectOrientedMetricCalculator
{
    class Analyzer
    {
        public List<Tuple<string, int>> GetDepthOfInheritanceTree(string moduleListing)
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();

            //TODO classes without inheritance: return 1;
            
            List<string> inheritedClasses = GetInheritedClasses(moduleListing);
            List<Tuple<string, string>> parentChildrenList = GetParentChildrenList(inheritedClasses);
            foreach(var parentChildren in parentChildrenList) //maybe in all classes list
            {
                string parent = parentChildren.Item1;
                string children = parentChildren.Item2;
                result.Add(new Tuple<string, int>(parent, GetDepthRecursive(parentChildrenList, children)));
            }

            return result;
        }

        public int GetDepthRecursive(List<Tuple<string, string>> parentChildrenList, string node) //node - children
        {
            var childList = ChildList(node, parentChildrenList);
            if (childList.Count() == 0)
            {
                return 1;
            }

            int maxDepth = 0;

            foreach(var child in childList)
            {
                int depth = GetDepthRecursive(parentChildrenList, child.Item2) + 1;
                if (maxDepth < depth)
                {
                    maxDepth = depth;
                }
            }

            return maxDepth;
        }

        private IEnumerable<Tuple<string, string>> ChildList(string node, List<Tuple<string, string>> parentChildrenList)
        {
            return parentChildrenList.Where(i => i.Item1 == node);
        }

        private List<string> GetInheritedClasses(string moduleListing)
        {
            string pattern_inheritedClass = "class\\s*[a-zA-Z]*\\s*:\\s*[a-zA-Z]*";
            Regex rgx = new Regex(pattern_inheritedClass);

            List<string> result = new List<string>();

            Match firstMatch = rgx.Match(moduleListing);
            if (firstMatch.Success)
            {
                result.Add(firstMatch.Value);
                foreach (Match m in rgx.Matches(moduleListing, firstMatch.Index + firstMatch.Length))
                {
                    result.Add(m.Value);
                }
            }

            return result;
        }

        private List<Tuple<string, string>> GetParentChildrenList(List<string> inheritedClasses)
        {
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();
            foreach (string inhClass in inheritedClasses)
            {
                var splitted = inhClass.Substring(6).Split(':'); //"class "

                if (splitted.Length != 2)
                {
                    continue;
                }

                string parent = splitted.Last().Trim();
                string children = splitted.First().Trim();
                result.Add(new Tuple<string, string>(parent, children));
            }

            return result;
        }
    }
}
