﻿using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    public class WordPair
    {
        public string Word1 { get; set; }
        public List<string> Word1Synonyms { get; set; }

        public string Word2 { get; set; }
        public List<string> Word2Synonyms { get; set; }

        public StringComp.Rules TranslationRules { get; set; }

        public WordPair(string word1, string word2, StringComp.Rules translationRules, List<string> word1Synonyms = null, List<string> word2Synonyms = null)
        {
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

        public bool Equals(WordPair wp2)
        {
            if (wp2 == null)
            {
                return false;
            }

            return
                this.Word1 == wp2.Word1 &&
                this.Word1Synonyms.SequenceEqual(wp2.Word1Synonyms) &&
                this.Word2 == wp2.Word2 &&
                this.Word2Synonyms.SequenceEqual(wp2.Word2Synonyms) &&
                this.TranslationRules == wp2.TranslationRules;
        }

        public WordProgData GetWordProgData()
        {
            foreach (var wordProgData in QuizCore.QuizProgress.WordProgDatas)
            {
                if (wordProgData.WordPair.Equals(this))
                {
                    return wordProgData;
                }
            }

            throw new Exception("No word progress data could be found for this word pair");
        }

        public StringComp.CharacterMismatch CharacterMismatches(string input, TranslationMode translationMode, bool updateProgress = true)
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

            if (updateProgress)
            {
                GetWordProgData().AddWordTry(new WordTry(bestCharacterMismatch.Correct()));
                QuizCore.SaveProgress();
            }

            if (bestCharacterMismatch.Correct())
            {
                GetWordProgData().AskedThisRound = true;
                QuizCore.QuizProgress.SetCurrentWordPair(null);
            }

            return bestCharacterMismatch;
        }
    }
}