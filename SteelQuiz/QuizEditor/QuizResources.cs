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

using SteelQuiz.QuizData.Resource;
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
    public partial class QuizResources : AutoThemeableForm
    {
        private QuizEditor QuizEditor { get; set; }
        private ResourceCollection<Image> QuizImages { get; set; } = new ResourceCollection<Image>();

        private PictureBox __selectedPictureBox = null;
        private PictureBox SelectedPictureBox
        {
            get
            {
                return __selectedPictureBox;
            }

            set
            {
                __selectedPictureBox = value;
                btn_chg.Enabled = value != null;
                btn_del.Enabled = value != null;
            }
        }

        public QuizResources(QuizEditor quizEditor, ResourceCollection<Image> quizImages)
        {
            InitializeComponent();

            QuizEditor = quizEditor;
            QuizImages = quizImages;

            foreach (var imgContainer in QuizImages.GetAll())
            {
                AddImageCtrl(imgContainer.Object, imgContainer.Guid);
            }

            SetTheme();
        }

        private void AddImageCtrl(Image image, Guid guid)
        {
            var pic = new PictureBox();
            pic.BackColor = Color.FromArgb(70, 70, 70);
            pic.Size = new Size(200, 200);
            pic.BackgroundImage = image;
            pic.BackgroundImageLayout = ImageLayout.Zoom;
            pic.Tag = guid;
            pic.MouseClick += (sender, e) =>
            {
                var snd = (PictureBox)sender;
                if (snd != SelectedPictureBox)
                {
                    if (SelectedPictureBox != null)
                    {
                        SelectedPictureBox.Size = new Size(200, 200);
                    }
                    SelectedPictureBox = snd;
                    SelectedPictureBox.Size = new Size(300, 300);
                }
                else
                {
                    SelectedPictureBox.Size = new Size(200, 200);
                    SelectedPictureBox = null;
                }
            };
            flp_res.Controls.Add(pic);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (ofd_image.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var img = Image.FromFile(ofd_image.FileName);
            if (!QuizImages.Contains(img))
            {
                var guid = QuizImages.Add(img);
                AddImageCtrl(img, guid);

                QuizEditor.ChangedSinceLastSave = true;
            }
        }

        private void btn_chg_Click(object sender, EventArgs e)
        {
            if (ofd_image.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var img = Image.FromFile(ofd_image.FileName);
            var imgContainer = QuizImages.GetContainer((Guid)SelectedPictureBox.Tag);
            imgContainer.ChangeResource(img);
            SelectedPictureBox.BackgroundImage = img;

            QuizEditor.ChangedSinceLastSave = true;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure?", "Delete Resource", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            QuizImages.Remove((Guid)SelectedPictureBox.Tag);
            SelectedPictureBox.Dispose();
            SelectedPictureBox = null;

            QuizEditor.ChangedSinceLastSave = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
