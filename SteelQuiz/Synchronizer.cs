using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz
{
    /*
     * Makes locking value-types possible
     */ 
    public class Synchronizer
    {
        private static Dictionary<int, object> Locks { get; set; }
        private object myLock;

        public Synchronizer()
        {
            Locks = new Dictionary<int, object>();
            myLock = new object();
        }

        public object this[int index]
        {
            get
            {
                lock (myLock)
                {
                    object result;
                    if (Locks.TryGetValue(index, out result))
                    {
                        return result;
                    }
                    result = new object();
                    Locks[index] = result;
                    return result;
                }
            }
        }
    }
}
