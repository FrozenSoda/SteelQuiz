using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz
{
    public static class StringComp
    {
        [Flags]
        public enum Rules
        {
            IgnoreCapitalization,
            IgnoreExclamation
        }

        public class CharacterMismatch
        {
            public int[] Cmp { get; set; }
            public int[] Input { get; set; }

            public CharacterMismatch(List<int> cmp, List<int> input)
            {
                Cmp = cmp.ToArray();
                Input = input.ToArray();
            }

            public bool Correct()
            {
                return Cmp.Length == 0 && Input.Length == 0;
            }
        }

        public static CharacterMismatch CharacterMismatches(string cmp, string input, Rules rules)
        {
            var jCurrent = 0;
            var mismatchCmp = new List<int>(); // missing cmp indexes
            var mismatchInput = new List<int>(); // missing input indexes

            for (int i = 0; i < cmp.Length; ++i)
            {
                var found = false;
                for (int j = jCurrent; j < input.Length; ++j)
                {
                    if (cmp[i] == input[j])
                    {
                        ++jCurrent;
                        found = true;
                        break;
                    }
                    else
                    {
                        if (rules.HasFlag(Rules.IgnoreCapitalization))
                        {
                            if (char.ToUpper(cmp[i]) == char.ToUpper(input[j]))
                            {
                                ++jCurrent;
                                found = true;
                                break;
                            }
                        }

                        if (rules.HasFlag(Rules.IgnoreExclamation))
                        {
                            if (cmp[i] == '!')
                            {
                                ++jCurrent;
                                found = true;
                                break;
                            }
                        }
                    }
                }

                if (!found)
                {
                    mismatchCmp.Add(i);
                }
            }

            jCurrent = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                var found = false;
                for (int j = 0; j < cmp.Length; ++j)
                {
                    if (input[i] == cmp[j])
                    {
                        ++jCurrent;
                        found = true;
                        break;
                    }
                    else
                    {
                        if (rules.HasFlag(Rules.IgnoreCapitalization))
                        {
                            if (char.ToUpper(input[i]) == char.ToUpper(cmp[j]))
                            {
                                ++jCurrent;
                                found = true;
                                break;
                            }
                        }

                        if (rules.HasFlag(Rules.IgnoreExclamation))
                        {
                            if (input[i] == '!')
                            {
                                ++jCurrent;
                                found = true;
                                break;
                            }
                        }
                    }
                }

                if (!found)
                {
                    mismatchInput.Add(i);
                }
            }

            return new CharacterMismatch(mismatchCmp, mismatchInput);
        }
    }
}
