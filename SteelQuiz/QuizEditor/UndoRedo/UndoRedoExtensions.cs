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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizEditor.UndoRedo
{
    public static class UndoRedoExtensions
    {
        /*
         * The following Funcs should be added to the undo/redo-stacks. For instance, if an item is added to a listbox, RemoveItem should be added to the undo stack
         * (which will remove the added item when pressing undo)
         */

        /*
         * formPtr is a Func which returns the appropriate form
         */ 

        public static Func<TextBox> ChangeText(this TextBox textBox, string to, Action beforeRevertAction)
        {
            return () => {
                beforeRevertAction?.Invoke();
                textBox.Text = to;
                return textBox;
            };
        }


        public static Func<TextBox> ChangeText(this TextBox textBox, Func<Form> formPtr, string textBoxName, string to)
        {
            return () => {
                var txt = formPtr().Controls[textBoxName] as TextBox;
                if (txt == null)
                {
                    return null;
                }
                txt.Text = to;
                return txt;
            };
        }

        public static Func<ListBox> RemoveItem(this ListBox listBox, object added)
        {
            return () => {
                listBox.Items.Remove(added);
                return listBox;
            };
        }

        public static Func<ListBox> RemoveItem(this ListBox listBox, Func<Form> formPtr, string listBoxName, object added)
        {
            return () => {
                var lst = formPtr().Controls[listBoxName] as ListBox;
                if (lst == null)
                {
                    return null;
                }
                lst.Items.Remove(added);
                return lst;
            };
        }

        public static Func<ListBox> AddItem(this ListBox listBox, object removed)
        {
            return () => {
                listBox.Items.Add(removed);
                return listBox;
            };
        }

        public static Func<ListBox> AddItem(this ListBox listBox, Func<Form> formPtr, string listBoxName, object removed)
        {
            return () => {
                var lst = formPtr().Controls[listBoxName] as ListBox;
                if (lst == null)
                {
                    return null;
                }
                lst.Items.Add(removed);
                return lst;
            };
        }

        public static Func<ListBox> ChangeItem(this ListBox listBox, object to, object from)
        {
            return () => {
                listBox.Items[listBox.Items.IndexOf(from)] = to;
                return listBox;
            };
        }

        public static Func<ListBox> ChangeItem(this ListBox listBox, Func<Form> formPtr, string listBoxName, object to, object from)
        {
            return () => {
                var lst = formPtr().Controls[listBoxName] as ListBox;
                if (lst == null)
                {
                    return null;
                }
                lst.Items[lst.Items.IndexOf(from)] = to;
                return lst;
            };
        }

        public static Func<CheckBox> SetChecked(this CheckBox checkBox, bool state, Action beforeRevertAction)
        {
            return () =>
            {
                beforeRevertAction?.Invoke();
                checkBox.Checked = state;
                return checkBox;
            };
        }
    }
}
