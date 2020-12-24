using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedMetricCalculator
{
    partial class Analyzer
    {
        const string repoName = "C:\\Users\\WS0\\Documents\\Projects\\Project_A\\MR\\bin\\x86\\Debug\\MR.exe";

        public static double GetМethodHidingFactor()
        {
            Assembly assembly = Assembly.LoadFrom(repoName);

            int privateMethods = 0;
            int allMethods = 0;

            foreach (Type type in assembly.GetTypes())
            {
                foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.FlattenHierarchy))
                {
                    if ( method.IsPublic || method.IsPrivate)
                    {
                        allMethods++;

                        if (method.IsPrivate)
                        {
                            privateMethods++;
                        }
                    }
                }
            }

            return (double) privateMethods / allMethods;
        }

        public static double GetAttributeHidingFactor()
        {
            Assembly assembly = Assembly.LoadFrom(repoName);

            int privateAttributes = 0;
            int allAttributes = 0;

            foreach (Type type in assembly.GetTypes())
            {
                foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.FlattenHierarchy))
                {
                    if (field.IsPublic || field.IsPrivate)
                    {
                        allAttributes++;

                        if (field.IsPrivate)
                        {
                            privateAttributes++;
                        }
                    }
                }
            }

            return (double)privateAttributes / allAttributes;
        }

        public static double GetMethodInheritanceFactor()
        {
            Assembly assembly = Assembly.LoadFrom(repoName);

            int inheritedOverridenMethods = 0;
            int inheritedNotOverridenMethods = 0;
            int allMethods = 0; //with all inherited


            foreach (Type type in assembly.GetTypes())
            {
                allMethods += type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.FlattenHierarchy).Length; 

                foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.FlattenHierarchy))
                {
                    var m_base = method.GetBaseDefinition();
                    if (m_base.ReflectedType.Name != method.ReflectedType.Name) // has base class
                    {
                        inheritedOverridenMethods++; 
                    }
                }
            }

            inheritedNotOverridenMethods = allMethods - inheritedOverridenMethods;

            return (double)inheritedNotOverridenMethods / allMethods;
        }
        
        public static double GetAttributeInheritanceFactor()
        {
            return 1;
        }

        public static double GetPolymorphismObjectFactor()
        {
            Assembly assembly = Assembly.LoadFrom(repoName);

            int inheritedOverridenMethods = 0;
            int denominator = 0;

            foreach (Type type in assembly.GetTypes())
            {
                int child = assembly.GetTypes()
                    .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Count();

                int newMethods = 0;

                foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.FlattenHierarchy))
                {
                     var m_base = method.GetBaseDefinition();
                    if (m_base.ReflectedType.Name != method.ReflectedType.Name) // has base class
                    {
                        inheritedOverridenMethods++;
                    }
                    else
                    {
                        newMethods++;
                    }
                }

                denominator += newMethods * child;
            }

            if (denominator == 0)
                return 0;

            return (double)inheritedOverridenMethods / denominator;
        }
    }
}
