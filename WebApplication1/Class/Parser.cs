using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace WorkFlowDesigner
{
    class Parser
    {
        public Parser()
        {
        }

        public string[] Parse(string condition)
        {
            
            string s0 = condition.Replace(" ", "");
            string s1 = s0.Replace("&)", ")&");
            string s2 = s1.Replace("|)", ")|");
            
            
            string[] split = s2.Split(new Char[] { '(', ')' },
                                StringSplitOptions.RemoveEmptyEntries);
            //string[] list = s4.Split(' ');            
            return split;
        }

        public bool checkBracket(string condition, Dictionary<string, string> dict)
        {
            if (condition.Equals("")) return true;
            string[] list = condition.Split('|');            
            foreach(string s in list)
            {
                string[] split = s.Split('&');
                bool ret = true;
                foreach(string s2 in split)
                {
                    int pos = s2.IndexOf('=');
                    string key;
                    string value;
                    if(s2[pos-1].Equals('!'))
                    {
                        key = s2.Substring(0, pos - 1);
                        value = s2.Substring(pos + 1, s2.Length - pos - 1);
                        if (dict[key].Equals(value))
                        {
                            ret = false;
                            break;
                        }

                    } else
                    {
                        key = s2.Substring(0, pos);
                        value = s2.Substring(pos + 1, s2.Length - pos - 1);
                        if(!dict[key].Equals(value))
                        {
                            ret = false;
                            break;
                        }
                    }
                }
                if (ret == true) return true;
            }
            return false;
        }

       
        public List<string[]> Condition (string condition)
        {
            List<string[]> a = new List<string[]>();
            int i = 0;
            while (i < condition.Length)
            {
                a.Add(new string[] { condition[i]=='('? "(":(condition[i]==')' ?")":""), "" });
                if (condition[i] == '('||condition[i]==')') i++;
                while((condition[i]>='a'&& condition[i] <= 'z')||(condition[i] >= 'A' && condition[i] <= 'Z')||condition[i]==' ')
                {
                    a.Last()[1] += condition[i];
                    i++;
                }
                a.Add(new string[] { "", "" });
                while(condition[i]=='='|| condition[i] == '!' || condition[i] == '>' || condition[i] == '<')
                {
                    a.Last()[0] += condition[i];
                    i++;
                }
                while(condition[i]!='&'&& condition[i]!='|')
                {
                    a.Last()[1] += condition[i];
                    i++;
                    if (i == condition.Length) return a;
                }
                if(i<condition.Length)
                {
                    a.Add(new string[] { condition[i].ToString(), "" });
                    i++;
                }
               
            } 
            return a;
        }

    }
}
