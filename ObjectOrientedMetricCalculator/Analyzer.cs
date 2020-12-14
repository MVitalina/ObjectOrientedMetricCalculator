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
            parentChildrenList = (List<Tuple<string, string>>)parentChildrenList.OrderBy(tuple => tuple.Item1).ThenBy(tuple => tuple.Item2);
            foreach(var parentChildren in parentChildrenList)
            {
                int counter = 0;
                //List<Tuple<string, string>> tree = new List<Tuple<string, string>>();
                string parent = parentChildren.Item1;
            }


            return result;
        }

        /*public int GetDepthRecursive(List<Tuple<string, string>> parentChildrenList, string node)
        {
            if ()
            {

            }

            /*if (number == 0)
                return 1;

            double factorial = 1;
            for (int i = number; i >= 1; i--)
            {
                factorial = factorial * i;
            }
            return factorial;
            return 1;
        }

        private bool FindParent(List<Tuple<string, string>> parentChildrenList, string node)
        {
            foreach (var lst in tr)
            {
                if (lst.Item1.Equals("Test"))
                    MessageBox.Show("Value Avail");
            }
        }*/

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
                var splitted = inhClass.Split(':');

                if (splitted.Length != 2)
                {
                    continue;
                }

                string parent = splitted.Last();
                string children = splitted.First();
                result.Add(new Tuple<string, string>(parent, children));
            }

            return result;
        }
    }
}
