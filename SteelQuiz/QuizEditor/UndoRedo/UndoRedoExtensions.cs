using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.UndoRedo
{
    public static class UndoRedoExtensions
    {
        /*
         * The following Funcs should be added to the undo/redo-stacks. For instance, if an item is added to a listbox, RemoveItem should be added to the undo stack
         * (which will remove the added item when pressing undo)
         */ 

        public static Func<TextBox> ChangeText(this TextBox textBox, string to)
        {
            return () => {
                textBox.Text = to;
                return textBox;
            };
        }

        public static Func<ListBox> RemoveItem(this ListBox listBox, object added)
        {
            return () => {
                listBox.Items.Remove(added);
                return listBox;
            };
        }

        public static Func<ListBox> AddItem(this ListBox listBox, object removed)
        {
            return () => {
                listBox.Items.Add(removed);
                return listBox;
            };
        }

        public static Func<ListBox> ChangeItem(this ListBox listBox, object to, object from)
        {
            return () => {
                listBox.Items[listBox.Items.IndexOf(from)] = to;
                return listBox;
            };
        }
    }
}
