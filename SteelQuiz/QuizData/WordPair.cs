/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  Steel9Apps

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    public class WordPair
    {
        public ulong ID { get; set; }

        public string Word1 { get; set; }
        public List<string> Word1Synonyms { get; set; }

        public string Word2 { get; set; }
        public List<string> Word2Synonyms { get; set; }

        public StringComp.Rules TranslationRules { get; set; }

        public WordPair(ulong id, string word1, string word2, StringComp.Rules translationRules, List<string> word1Synonyms = null, List<string> word2Synonyms = null)
        {
            ID = id;
            Word1 = word1;
            Word2 = word2;
            TranslationRules = translationRules;
            Word1Synonyms = word1Synonyms;
            Word2Synonyms = word2Synonyms;

            if (Word1Synonyms == null)
            {
                Word1Synonyms = new List<string>();
            }

            if (Word2Synonyms == null)
            {
                Word2Synonyms = new List<string>();
            }
        }

        public enum TranslationMode
        {
            L1_to_L2,
            L2_to_L1
        }

        public override bool Equals(object wp2)
        {
            if (wp2.GetType() != this.GetType())
            {
                return false;
            }

            return
                this.Word1 == ((WordPair)wp2).Word1 &&
                this.Word1Synonyms.SequenceEqual(((WordPair)wp2).Word1Synonyms) &&
                this.Word2 == ((WordPair)wp2).Word2 &&
                this.Word2Synonyms.SequenceEqual(((WordPair)wp2).Word2Synonyms) &&
                this.TranslationRules == ((WordPair)wp2).TranslationRules;
        }

        public WordProgData GetWordProgData()
        {
            foreach (var wordProgData in QuizCore.QuizProgress.WordProgDatas)
            {
                if (wordProgData.WordPairID == this.ID)
                {
                    return wordProgData;
                }
            }

            throw new Exception("No word progress data could be found for this word pair");
        }

        public StringComp.CharacterMismatch CharacterMismatches(string input, TranslationMode translationMode, bool updateProgress = true, bool recurse = false)
        {
            var mismatches = new List<StringComp.CharacterMismatch>();
            if (translationMode == TranslationMode.L1_to_L2)
            {
                mismatches.Add(StringComp.CharacterMismatches(Word2, input, TranslationRules));
                foreach (var synonym in Word2Synonyms)
                {
                    mismatches.Add(StringComp.CharacterMismatches(synonym, input, TranslationRules));
                }
            }
            else if (translationMode == TranslationMode.L2_to_L1)
            {
                mismatches.Add(StringComp.CharacterMismatches(Word1, input, TranslationRules));
                foreach (var synonym in Word1Synonyms)
                {
                    mismatches.Add(StringComp.CharacterMismatches(synonym, input, TranslationRules));
                }
            }
            else
            {
                throw new NotImplementedException("Error in WordPair.CharacterMismatches: All translation modes hasn't been implemented!");
            }

            // find CharacterMismatch with the least mismatch
            StringComp.CharacterMismatch bestCharacterMismatch = null;
            foreach (var mismatch in mismatches)
            {
                if (bestCharacterMismatch == null)
                {
                    bestCharacterMismatch = mismatch;
                }
                else
                {
                    if (mismatch.Cmp.Length <= bestCharacterMismatch.Cmp.Length && mismatch.Input.Length <= bestCharacterMismatch.Input.Length)
                    {
                        bestCharacterMismatch = mismatch;
                    }
                }
            }

            if (bestCharacterMismatch.Correct())
            {
                if (!recurse)
                {
                    GetWordProgData().AskedThisRound = true;
                    QuizCore.QuizProgress.SetCurrentWordPair(null);
                }
                if (updateProgress)
                {
                    GetWordProgData().AddWordTry(new WordTry(true));
                    QuizCore.SaveQuizProgress();
                }
            }
            else if (!recurse)
            {
                // check if a synonym for the was being asked as a separate word
                foreach (var wordPair in QuizCore.Quiz.WordPairs)
                {
                    if (translationMode == TranslationMode.L1_to_L2)
                    {
                        if (wordPair.Word1 == Word1 && wordPair.Word2 != Word2)
                        {
                            // check if the answer to this wordpair was correct
                            var mismatch2 = wordPair.CharacterMismatches(input, translationMode, false, true);
                            if (mismatch2.Correct())
                            {
                                // a synonym for this word was being asked, the user could not know this, so don't count it as a miss in the progress
                                return new StringComp.CharacterMismatch(bestCharacterMismatch.Cmp.ToList(), bestCharacterMismatch.Input.ToList(), true);
                            }
                        }
                    }
                    else if (translationMode == TranslationMode.L2_to_L1)
                    {
                        if (wordPair.Word2 == Word2 && wordPair.Word1 != Word1)
                        {
                            // check if the answer to this wordpair was correct
                            var mismatch2 = wordPair.CharacterMismatches(input, translationMode, false, true);
                            if (mismatch2.Correct())
                            {
                                // a synonym for this word was being asked, the user could not know this, so don't count it as a miss in the progress
                                return new StringComp.CharacterMismatch(bestCharacterMismatch.Cmp.ToList(), bestCharacterMismatch.Input.ToList(), true);
                            }
                        }
                    }
                }

                if (updateProgress)
                {
                    GetWordProgData().AddWordTry(new WordTry(false));
                    QuizCore.SaveQuizProgress();
                }
            }

            return bestCharacterMismatch;
        }
    }
}