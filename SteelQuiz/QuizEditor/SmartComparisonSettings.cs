/*
    SteelQuiz - A quiz program designed to make learning easier.
    Copyright (C) 2020  Steel9Apps

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

using SteelQuiz.QuizPractise;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizEditor
{
    public partial class SmartComparisonSettings : AutoThemeableForm
    {
        public StringComp.Rules Rules
        {
            get
            {
                var rules = StringComp.Rules.None;
                if (chk_ignoreCapitalizationFirstChar.CheckState == CheckState.Checked)
                {
                    rules |= StringComp.Rules.IgnoreFirstCapitalization;
                }
                if (chk_ignoreOpeningWhitespace.CheckState == CheckState.Checked)
                {
                    rules |= StringComp.Rules.IgnoreOpeningWhitespace;
                }
                if (chk_ignoreEndingWhitespace.CheckState == CheckState.Checked)
                {
                    rules |= StringComp.Rules.IgnoreEndingWhitespace;
                }
                if (chk_ignoreDotsInEnd.CheckState == CheckState.Checked)
                {
                    rules |= StringComp.Rules.IgnoreDotsInEnd;
                }
                if (chk_treatTextInParenthesisAsSynonym.CheckState == CheckState.Checked)
                {
                    rules |= StringComp.Rules.TreatWordInParenthesisAsOptional;
                }
                if (chk_treatWordsBetweenSlashAsSynonyms.CheckState == CheckState.Checked)
                {
                    rules |= StringComp.Rules.TreatWordsBetweenSlashAsSynonyms;
                }

                return rules;
            }

            set
            {
                chk_ignoreCapitalizationFirstChar.Checked = value.HasFlag(StringComp.Rules.IgnoreFirstCapitalization);
                chk_ignoreOpeningWhitespace.Checked = value.HasFlag(StringComp.Rules.IgnoreOpeningWhitespace);
                chk_ignoreEndingWhitespace.Checked = value.HasFlag(StringComp.Rules.IgnoreEndingWhitespace);
                chk_ignoreDotsInEnd.Checked = value.HasFlag(StringComp.Rules.IgnoreDotsInEnd);
                chk_treatTextInParenthesisAsSynonym.Checked = value.HasFlag(StringComp.Rules.TreatWordInParenthesisAsOptional);
                chk_treatWordsBetweenSlashAsSynonyms.Checked = value.HasFlag(StringComp.Rules.TreatWordsBetweenSlashAsSynonyms);
            }
        }

        /// <summary>
        /// A settings dialog to change the comparison rules for one wordpair.
        /// </summary>
        /// <param name="comparisonRules">The current comparison rules</param>
        public SmartComparisonSettings(StringComp.Rules comparisonRules)
        {
            InitializeComponent();
            SetTheme();

            Rules = comparisonRules;
        }

        /// <summary>
        /// A settings dialog to change the comparison rules for multiple wordpair.
        /// </summary>
        /// <param name="comparisonRules">The current comparison rules</param>
        public SmartComparisonSettings(IEnumerable<StringComp.Rules> comparisonRules)
        {
            InitializeComponent();
            SetTheme();


            int totalCount = comparisonRules.Count();
            int ignoreFirstCapitalizationCount = comparisonRules.Where(x => x.HasFlag(StringComp.Rules.IgnoreFirstCapitalization)).Count();
            int ignoreOpeningWhitespaceCount = comparisonRules.Where(x => x.HasFlag(StringComp.Rules.IgnoreOpeningWhitespace)).Count();
            int ignoreEndingWhitespaceCount = comparisonRules.Where(x => x.HasFlag(StringComp.Rules.IgnoreEndingWhitespace)).Count();
            int ignoreDotsInEndCount = comparisonRules.Where(x => x.HasFlag(StringComp.Rules.IgnoreDotsInEnd)).Count();
            int treatWordInparenthesisAsOptionalCount = comparisonRules.Where(x => x.HasFlag(StringComp.Rules.TreatWordInParenthesisAsOptional)).Count();
            int treatWordsBetweenSlashAsSynonymsCount = comparisonRules.Where(x => x.HasFlag(StringComp.Rules.TreatWordsBetweenSlashAsSynonyms)).Count();

            if (ignoreFirstCapitalizationCount == totalCount)
            {
                chk_ignoreCapitalizationFirstChar.CheckState = CheckState.Checked;
            }
            else if (ignoreFirstCapitalizationCount < totalCount && ignoreFirstCapitalizationCount > 0)
            {
                chk_ignoreCapitalizationFirstChar.CheckState = CheckState.Indeterminate;
            }
            else if (ignoreFirstCapitalizationCount == 0)
            {
                chk_ignoreCapitalizationFirstChar.CheckState = CheckState.Unchecked;
            }

            if (ignoreOpeningWhitespaceCount == totalCount)
            {
                chk_ignoreOpeningWhitespace.CheckState = CheckState.Checked;
            }
            else if (ignoreOpeningWhitespaceCount < totalCount && ignoreOpeningWhitespaceCount > 0)
            {
                chk_ignoreOpeningWhitespace.CheckState = CheckState.Indeterminate;
            }
            else if (ignoreOpeningWhitespaceCount == 0)
            {
                chk_ignoreOpeningWhitespace.CheckState = CheckState.Unchecked;
            }

            if (ignoreEndingWhitespaceCount == totalCount)
            {
                chk_ignoreEndingWhitespace.CheckState = CheckState.Checked;
            }
            else if (ignoreEndingWhitespaceCount < totalCount && ignoreEndingWhitespaceCount > 0)
            {
                chk_ignoreEndingWhitespace.CheckState = CheckState.Indeterminate;
            }
            else if (ignoreEndingWhitespaceCount == 0)
            {
                chk_ignoreEndingWhitespace.CheckState = CheckState.Unchecked;
            }

            if (ignoreDotsInEndCount == totalCount)
            {
                chk_ignoreDotsInEnd.CheckState = CheckState.Checked;
            }
            else if (ignoreDotsInEndCount < totalCount && ignoreDotsInEndCount > 0)
            {
                chk_ignoreDotsInEnd.CheckState = CheckState.Indeterminate;
            }
            else if (ignoreDotsInEndCount == 0)
            {
                chk_ignoreDotsInEnd.CheckState = CheckState.Unchecked;
            }

            if (treatWordInparenthesisAsOptionalCount == totalCount)
            {
                chk_treatTextInParenthesisAsSynonym.CheckState = CheckState.Checked;
            }
            else if (treatWordInparenthesisAsOptionalCount < totalCount && treatWordInparenthesisAsOptionalCount > 0)
            {
                chk_treatTextInParenthesisAsSynonym.CheckState = CheckState.Indeterminate;
            }
            else if (treatWordInparenthesisAsOptionalCount == 0)
            {
                chk_treatTextInParenthesisAsSynonym.CheckState = CheckState.Unchecked;
            }

            if (treatWordsBetweenSlashAsSynonymsCount == totalCount)
            {
                chk_treatWordsBetweenSlashAsSynonyms.CheckState = CheckState.Checked;
            }
            else if (treatWordsBetweenSlashAsSynonymsCount < totalCount && treatWordsBetweenSlashAsSynonymsCount > 0)
            {
                chk_treatWordsBetweenSlashAsSynonyms.CheckState = CheckState.Indeterminate;
            }
            else if (treatWordsBetweenSlashAsSynonymsCount == 0)
            {
                chk_treatWordsBetweenSlashAsSynonyms.CheckState = CheckState.Unchecked;
            }
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Chk_Click(object sender, EventArgs e)
        {
            var chk = (CheckBox)sender;
            if (chk.CheckState == CheckState.Checked)
            {
                chk.CheckState = CheckState.Unchecked;
            }
            else if (chk.CheckState == CheckState.Unchecked)
            {
                chk.CheckState = CheckState.Checked;
            }
            else if (chk.CheckState == CheckState.Indeterminate)
            {
                chk.CheckState = CheckState.Checked;
            }
        }
    }
}
