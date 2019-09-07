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
                if (chk_ignoreCapitalizationFirstChar.Checked)
                {
                    rules |= StringComp.Rules.IgnoreFirstCapitalization;
                }
                if (chk_ignoreOpeningWhitespace.Checked)
                {
                    rules |= StringComp.Rules.IgnoreOpeningWhitespace;
                }
                if (chk_ignoreEndingWhitespace.Checked)
                {
                    rules |= StringComp.Rules.IgnoreEndingWhitespace;
                }
                if (chk_ignoreDotsInEnd.Checked)
                {
                    rules |= StringComp.Rules.IgnoreDotsInEnd;
                }
                if (chk_treatTextInParenthesisAsSynonym.Checked)
                {
                    rules |= StringComp.Rules.TreatWordInParenthesisAsOptional;
                }
                if (chk_treatWordsBetweenSlashAsSynonyms.Checked)
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

        public SmartComparisonSettings(StringComp.Rules comparisonRules)
        {
            InitializeComponent();
            SetTheme();

            Rules = comparisonRules;
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
