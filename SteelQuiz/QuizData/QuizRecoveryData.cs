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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    public class QuizRecoveryData
    {
        [JsonProperty]
        public Quiz Quiz { get; private set; }

        [JsonProperty]
        public string QuizPath { get; private set; }

        [JsonProperty]
        public string RecoveryFilePath { get; private set; }

        [JsonProperty]
        public DateTime LastUpdated { get; private set; }

        public QuizRecoveryData(string quizPath, string recoveryPath = null)
        {
            QuizPath = quizPath;

            if (recoveryPath == null)
            {
                SetRecoveryPath();
            }
            else
            {
                RecoveryFilePath = recoveryPath;
            }
        }

        public void SetRecoveryPath()
        {
            string recoveryFilePath;
            int untitledCounter = 1;
            if (QuizPath != null)
            {
                recoveryFilePath = Path.Combine(QuizCore.QUIZ_RECOVERY_FOLDER, $"{Path.GetFileNameWithoutExtension(QuizPath)}.steelquizrecovery");
            }
            else
            {
                recoveryFilePath = Path.Combine(QuizCore.QUIZ_RECOVERY_FOLDER, $"Untitled{untitledCounter.ToString()}.steelquizrecovery");
            }

            while (File.Exists(recoveryFilePath))
            {
                ++untitledCounter;
                if (QuizPath != null)
                {
                    recoveryFilePath = Path.Combine(QuizCore.QUIZ_RECOVERY_FOLDER,
                        $"{Path.GetFileNameWithoutExtension(QuizPath)}_{ untitledCounter.ToString() }.steelquizrecovery");
                }
                else
                {
                    recoveryFilePath = Path.Combine(QuizCore.QUIZ_RECOVERY_FOLDER, $"Untitled{untitledCounter.ToString()}.steelquizrecovery");
                }
            }

            RecoveryFilePath = recoveryFilePath;
        }

        public void Save(Quiz quiz)
        {
            Quiz = quiz;
            LastUpdated = DateTime.Now;
            AtomicIO.AtomicWrite(RecoveryFilePath, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
