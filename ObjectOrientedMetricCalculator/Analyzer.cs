using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ObjectOrientedMetricCalculator
{
    partial class Analyzer
    {
        public Analyzer(string moduleListing)
        {
            AllClasses = ParseAllClasses(moduleListing);
            ParentChildrenList = ParseInheritedClasses(moduleListing);
        }

        readonly List<Tuple<string, string>> ParentChildrenList = new List<Tuple<string, string>>();
        readonly List<string> AllClasses = new List<string>();

        private IEnumerable<Tuple<string, string>> ChildList(string node)
        {
            return ParentChildrenList.Where(i => i.Item1 == node);
        }

        private List<string> ParseAllClasses(string moduleListing)
        {
            List<string> allClasses = GetAllMatches(moduleListing, "class\\s*[a-zA-Z]*\\s*[:{]");
            List<string> result = new List<string>();

            foreach (string inhClass in allClasses)
            {
                if (inhClass.Length < 8)
                {
                    continue;
                }

                string className = inhClass.Substring(6); //getting rid of "class " 
                className = className.Remove(className.Length - 2); //getting rid of last char '{' or ':'
                className = className.Trim();

                if (!result.Contains(className))
                {
                    result.Add(className);
                }
            }

            return result;
        }

        private List<Tuple<string, string>> ParseInheritedClasses(string moduleListing)
        {
            List<string> inheritedClasses = GetAllMatches(moduleListing, "class\\s*[a-zA-Z]*\\s*:\\s*[a-zA-Z]*");
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();

            foreach (string inhClass in inheritedClasses)
            {
                if (inhClass.Length < 7)
                {
                    continue;
                }

                var splitted = inhClass.Substring(6).Split(':'); //getting rid of "class " by substring

                if (splitted.Length != 2)
                {
                    continue;
                }

                string parent = splitted.Last().Trim();
                string children = splitted.First().Trim();

                if (AllClasses.Contains(parent))
                {
                    result.Add(new Tuple<string, string>(parent, children));
                }
            }

            return result;
        }

        private List<string> GetAllMatches(string moduleListing, string pattern)
        {
            Regex rgx = new Regex(pattern);

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
    }
}
