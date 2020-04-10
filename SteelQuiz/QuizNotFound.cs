using Newtonsoft.Json;
using SteelQuiz.QuizData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public partial class QuizNotFound : AutoThemeableForm
    {
        public string NewQuizPath { get; set; }
        private string OldQuizPath { get; set; }
        private Guid QuizGuid { get; set; }

        public QuizNotFound(Guid quizGuid, string oldQuizPath)
        {
            InitializeComponent();

            QuizGuid = quizGuid;
            OldQuizPath = oldQuizPath;

            lbl_oldPath.Text = "Old Path:\r\n" + oldQuizPath;

            var oldQuizDir = Path.GetDirectoryName(oldQuizPath);
            if (Directory.Exists(oldQuizDir))
            {
                ofd_quiz.InitialDirectory = oldQuizDir;
            }
            else
            {
                ofd_quiz.InitialDirectory = ConfigManager.Config.StorageConfig.DefaultQuizSaveFolder;
            }

            SetTheme();
        }

        private class SearchDir
        {
            public string Path { get; set; }
            public bool Recursive { get; set; }

            public SearchDir(string path, bool recursive)
            {
                Path = path;
                Recursive = recursive;
            }
        }

        private List<SearchDir> GetSearchDirs()
        {
            return new SearchDir[] {
                new SearchDir(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), true),
                new SearchDir(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), true),
                new SearchDir(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SteelQuiz"), true),
                new SearchDir(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"), true),
                new SearchDir(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OneDrive"), true),
                new SearchDir(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Dropbox"), true),
                new SearchDir(Path.GetDirectoryName(OldQuizPath), true),
                new SearchDir(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), true),
                new SearchDir(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), true),
                new SearchDir(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), true),
                new SearchDir(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), false),
            }.Where(x => Directory.Exists(x.Path)).ToList();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_specifyManually_Click(object sender, EventArgs e)
        {
            if (ofd_quiz.ShowDialog() == DialogResult.OK)
            {
                string rawQuiz = null;
                try
                {
                    rawQuiz = AtomicIO.AtomicRead(ofd_quiz.FileName);
                }
                catch (AtomicException ex)
                {
                    MessageBox.Show("Could not read file:\r\n" + ex.ToString(), "Atomic Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var quiz = JsonConvert.DeserializeObject<Quiz>(rawQuiz);
                if (quiz.GUID == QuizGuid)
                {
                    NewQuizPath = ofd_quiz.FileName;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("The selected quiz is not the right one. SteelQuiz is looking for the following quiz:\r\n\r\n" +
                        $"Old name: {Path.GetFileNameWithoutExtension(OldQuizPath)}\r\nGuid:{QuizGuid.ToString()}",
                        "Guid does not match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_autoSearch_Click(object sender, EventArgs e)
        {
            if (!bgw_quizSearcher.IsBusy)
            {
                bgw_quizSearcher.RunWorkerAsync();

                lbl_msg.Text = "Searching ...";
                btn_cancel.Enabled = false;
                btn_specifyManually.Enabled = false;
                btn_autoSearch.Text = "Cancel";
            }
            else
            {
                bgw_quizSearcher.CancelAsync();

                btn_autoSearch.Enabled = false;
            }
        }

        private void bgw_quizSearcher_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var searchDir in GetSearchDirs())
            {
                try
                {
                    foreach (var file in Directory.EnumerateFiles(searchDir.Path, $"*.{QuizCore.QUIZ_EXTENSION}",
                        searchDir.Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
                    {
                        if (bgw_quizSearcher.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        string rawQuiz;
                        try
                        {
                            rawQuiz = AtomicIO.AtomicRead(file);
                        }
                        catch (AtomicException)
                        {
                            continue;
                        }
                        var quiz = JsonConvert.DeserializeObject<Quiz>(rawQuiz);

                        if (quiz != null && quiz.GUID == QuizGuid)
                        {
                            NewQuizPath = file;
                            break;
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        private void bgw_quizSearcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (NewQuizPath != null)
            {
                DialogResult = DialogResult.OK;
                return;
            }

            lbl_msg.Text = "Could not locate quiz. Did you rename or move it?";
            btn_cancel.Enabled = true;
            btn_specifyManually.Enabled = true;
            btn_autoSearch.Enabled = true;
            btn_autoSearch.Text = "Let SteelQuiz search";

            MessageBox.Show("SteelQuiz could not locate the quiz. You must specify the path manually if you wish to load it.", "Could not locate Quiz",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
