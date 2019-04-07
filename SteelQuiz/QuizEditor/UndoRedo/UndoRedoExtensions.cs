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

        public static Func<TextBox> ChangeText(this TextBox textBox, string to, Action beforeRevertAction = null)
        {
            return () => {
                beforeRevertAction();
                textBox.Text = to;
                return textBox;
            };
        }

        public static Func<TextBox> ChangeTextChild(this TextBox textBox, QuizEditorWord owner, string textBoxName, string to)
        {
            return () => {
                var txt = owner.editWordSynonyms.Controls[textBoxName] as TextBox;
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

        public static Func<ListBox> RemoveItemChild(this ListBox listBox, QuizEditorWord owner, string listBoxName, object added)
        {
            return () => {
                var lst = owner.editWordSynonyms.Controls[listBoxName] as ListBox;
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

        public static Func<ListBox> AddItemChild(this ListBox listBox, QuizEditorWord owner, string listBoxName, object removed)
        {
            return () => {
                var lst = owner.editWordSynonyms.Controls[listBoxName] as ListBox;
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

        public static Func<ListBox> ChangeItemChild(this ListBox listBox, QuizEditorWord owner, string listBoxName, object to, object from)
        {
            return () => {
                var lst = owner.editWordSynonyms.Controls[listBoxName] as ListBox;
                if (lst == null)
                {
                    return null;
                }
                lst.Items[lst.Items.IndexOf(from)] = to;
                return lst;
            };
        }
    }
}
