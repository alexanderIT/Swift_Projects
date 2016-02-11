using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UndoRedu
{
    class Program
    {
        static void Main(string[] args)
        {
            UndoReduTestObject obj = new UndoReduTestObject();
            UndoReduFramework navigation = UndoReduFramework.Instance;
            navigation.FollowObject(obj);
            for (int i = 0; i < 20; i++)
            {
                obj.Prop = i;
            }

            for (int i = 0; i < 20; i++)
            {
                if(navigation.Undo(i == 0))
                    Console.WriteLine(string.Format("Undo {0}", obj.Prop));
            }

            for (int i = 0; i < 20; i++)
            {
                if(navigation.Redo())
                    Console.WriteLine(string.Format("Redo {0}", obj.Prop));
            }

            for (int i = 0; i < 20; i++)
            {
                if (navigation.Undo())
                    Console.WriteLine(string.Format("Undo {0}", obj.Prop));
            }

            for (int i = 0; i < 20; i++)
            {
                if (navigation.Redo())
                    Console.WriteLine(string.Format("Redo {0}", obj.Prop));
            }

            Console.WriteLine(string.Format("Redo {0}", obj.Prop));


        }

        public class UndoReduTestObject : UndoRedoObject
        {
            int prop = 0;

            public int Prop
            {
                get { return prop; }
                set {
                       if (value != prop)
                       {
                         Notify(prop);
                         prop = value;
                       }
                    }
            }

        }

    }
}
