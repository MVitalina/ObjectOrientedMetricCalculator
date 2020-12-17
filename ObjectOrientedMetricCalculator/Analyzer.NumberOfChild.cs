using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedMetricCalculator
{
    partial class Analyzer
    {
        public List<Tuple<string, int>> GetNumberOfChild()
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();

            foreach (string className in AllClasses)
            {
                result.Add(new Tuple<string, int>(className, ChildList(className).Count()));
            }

            return result.OrderByDescending(x => x.Item2).ToList();
        }
    }
}
