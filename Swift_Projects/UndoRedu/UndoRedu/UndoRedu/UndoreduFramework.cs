using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UndoRedu
{
    public class UndoReduFramework
    {
        // how many steps we will remember 
        int capacity = 30;

        internal HashSet<object> objects = new HashSet<object>();

        List<ObjectPropertyValuePair> undoList = new List<ObjectPropertyValuePair>();

        List<ObjectPropertyValuePair> redoList = new List<ObjectPropertyValuePair>();

        static UndoReduFramework instance;
        // we have private constructor because on theory we must have only one UndoRedu manager for application 
        private UndoReduFramework()
        {

        }

        // this is a static property which actually initialize the Manager if it is not 
        public static UndoReduFramework Instance
        {
            get
            {
                if (UndoReduFramework.instance == null)
                    UndoReduFramework.instance = new UndoReduFramework();
                return instance;
            }
        }
       
        /// <summary>
        /// follow the object 
        /// </summary>
        /// <param name="o">object which will be followed</param>
        /// <returns>true is we could follow this object , i.e. if it implements INotificator</returns>
        public bool FollowObject(object o)
        {
            INotify followedObject = o as INotify;
            if (followedObject != null)
            {
                if (objects.Contains(o))
                    throw new ArgumentException("This object is already followed");
                else
                {
                    objects.Add(o);
                    // subscribe for NotifyPropertyChanging in order to know when exactly property was changed 
                    // this allows us to "remember" the state of the object before it will be changed 
                    followedObject.OnNotifyPropertyChanging += FollowedObject_NotifyPropertyChanging;
                    followedObject.OnDispose += FollowedObject_OnDispose;
                    return true;
                }
            }
            return false;
        }

        void FollowedObject_OnDispose(object sender, EventArgs arg)
        {
            RemoveObjectFromUndoReduManager(sender);
        }

        public bool UnFollowObject(object o)
        {
            INotify followedObject = o as INotify;
            if (followedObject != null)
            {
                if (!objects.Contains(o))
                    throw new ArgumentException("This object has not been followed");
                else
                {
                    RemoveObjectFromUndoReduManager(o);
                    return true;
                }
            }
            return false;
        }

        private void RemoveObjectFromUndoReduManager(object sender)
        {
            // unsubscribe from the events
            INotify followedObject = sender as INotify;
            followedObject.OnNotifyPropertyChanging -= FollowedObject_NotifyPropertyChanging;
            followedObject.OnDispose -= FollowedObject_OnDispose;
            // remove the object from all lists 
            objects.Remove(sender);
            // here we use LINQ query to find the object we need 
            ObjectPropertyValuePair followedObjectWrapper = this.undoList.FirstOrDefault(o => o.O.Equals(sender));
            if (followedObjectWrapper != null)
                this.undoList.Remove(followedObjectWrapper);

            // here we use LINQ query to find the object we need 
            followedObjectWrapper = this.redoList.FirstOrDefault(o => o.O.Equals(sender));
            if (followedObjectWrapper != null)
                this.redoList.Remove(followedObjectWrapper);
        }

        private void FollowedObject_NotifyPropertyChanging(object sender, NotificationArg arg)
        {
            // if the object was not disposed and someone "listen" about this event we wont to rise it 
            if(!((INotify)sender).Disposed  && ((INotify)sender).SuspendListener == false )
                this.AddToUndo(new ObjectPropertyValuePair(ref sender, arg.PropertyKey, arg.OldValue));
        }

        // add item to the Undo list
        private void AddToUndo(ObjectPropertyValuePair item)
        {
            AddToList(item, undoList);
        }
        // add item to the redo list 
        private void AddToRedo(ObjectPropertyValuePair item)
        {
            AddToList(item, redoList);
        }

        private void AddToList(ObjectPropertyValuePair item, List<ObjectPropertyValuePair> list)
        {
            // we want to keep the capacity of the list to 30 items
            // but since this list should behave as stack we should remove the items from the bottom 
            if (list.Count >= capacity)
            {
                for (int i = capacity-1; i < list.Count; i++)
                {
                    list.RemoveAt(i);
                }
            }
            list.Insert(0, item);
        }

        // make Undo, i.e. revert the object to its previous state 
        public bool Undo(bool storeSateteBeforOperation = false)
        {
            
            if(undoList.Count > 0)
            {
                // get the object state from the undo list
                ObjectPropertyValuePair undoObject = undoList[0];
                // suspend the object from notification 
                // otherwise we will be notified for an action which we perform and should be inserted in any list 
                undoObject.O.SuspendListener = true ;
                // revert to the state 
                var prevState = undoObject.SetState();
                // after we execute the operation we won to resume the notifications 
                undoObject.O.SuspendListener = false;
                // remove this state from undo list 
                undoList.Remove(undoObject);
                // IF WE WANT TO SAVE CURRENT STATE     
                if (storeSateteBeforOperation)
                    this.AddToRedo(prevState);
                // add this state to the redo list
                this.AddToRedo(undoObject);
                return true;
            }
            return false;

        }

        public bool Redo(bool storeSateteBeforOperation = false)
        {
            if (redoList.Count > 0)
            {
                ObjectPropertyValuePair redoObject = redoList[0];
                redoObject.O.SuspendListener = true;
                var prevState = redoObject.SetState();
                redoObject.O.SuspendListener = false;
                redoList.Remove(redoObject);
                // IF WE WANT TO SAVE CURRENT STATE     
                if (storeSateteBeforOperation)
                    this.AddToUndo(prevState);
                this.AddToUndo(redoObject);
                return true;
            }
            return false;

        }

    }

    // this class is used to store reference to the object 
    // and its property which was set and its old value 
    // this allows us to revert the object to that particular state 
    internal class ObjectPropertyValuePair:IDisposable
    {
        // at this static dictionary we are going to store information about the type 
        // and the properties that this type contains 
        // so actually the value of this dictionary is dictionary and the key is the type 
        private static Dictionary<Type, Dictionary<string, PropertyDescriptor>> objectsProperties = new Dictionary<Type, Dictionary<string, PropertyDescriptor>>();

        object o;
        string property;
        object oldeValue;

        // return the object as Notificator 
        public INotify O
        {
            get
            {
                return (INotify)o;
            }
        }
        
        // the property of the object which was set 
        public string Property
        {
            get
            {
                return property;
            }
        }
        
        // the value of the property 
        public object OldValue
        {
            get
            {
                return oldeValue;
            }
        }

        public void Dispose()
        {
            o = null;
            property = null;
            oldeValue = null;
        }

        // this actually reverts to the state 
        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns the state before revert</returns>
        public ObjectPropertyValuePair SetState()
        {
            ObjectPropertyValuePair prevState = this.GetStateFor(this);
            // we get the meta data about the property based on the object type 
            // then get the corresponding PropertyDescriptor, which allows us to call its set method 
            objectsProperties[this.o.GetType()][this.property].SetValue(this.o,this.oldeValue);

            return prevState;

        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="o"> object whose state will e stored</param>
        /// <param name="property">property for which we will stave the state </param>
        /// <param name="value">the current value </param>
        internal ObjectPropertyValuePair(ref object o, string property, object value)
        {
            // if we do not have information about this type 
            // load it , i.e. read all of its properties and prepare them fro use
            if (!objectsProperties.ContainsKey(o.GetType()))
            {
                objectsProperties.Add(o.GetType(), getProperties(o.GetType()));
            }

            this.o = o;
            this.property = property;
            this.oldeValue = value;
        }

        // this constructor is used only for private usage
        // it makes state from the current object
        private ObjectPropertyValuePair(ref object o, string property)
        {
            // if we do not have information about this type 
            // load it , i.e. read all of its properties and prepare them fro use
            if (!objectsProperties.ContainsKey(o.GetType()))
            {
                objectsProperties.Add(o.GetType(), getProperties(o.GetType()));
            }

            this.o = o;
            this.property = property;
            this.oldeValue = objectsProperties[this.o.GetType()][this.property].GetValue(this.o);
        }

        private Dictionary<string, PropertyDescriptor> getProperties(Type type)
        {
            // get properties for this type 
            Dictionary<string, PropertyDescriptor> returnResult = new Dictionary<string, PropertyDescriptor>();
            // we are using Typedescriptor in order to get meta data about the properties of the object 
            // in order to be bale to detect when any of its properties was changed 
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(type))
            {
                returnResult.Add(prop.Name, prop);
            }
            return returnResult;

        }

        private ObjectPropertyValuePair GetStateFor(ObjectPropertyValuePair state)
        {
            return new ObjectPropertyValuePair(ref state.o, state.property);
        }
    }

    public delegate void NotifyPropertyChnaging(object sender, NotificationArg arg);
    public delegate void NotifyDisposed(object sender, EventArgs arg);
    public interface INotify:IDisposable
    {
        /// <summary>
        /// notify before property change its value 
        /// </summary>
        event NotifyPropertyChnaging OnNotifyPropertyChanging;
        
        /// <summary>
        /// notify the listener before object being disposed 
        /// </summary>
        event NotifyDisposed OnDispose;

        /// <summary>
        /// suspend listener from notification about property change 
        /// </summary>
        bool SuspendListener
        {
            get;
            set;
        }
        /// <summary>
        /// identify if object had been disposed 
        /// </summary>
        bool Disposed
        {
            get;
        }
    }

    public class NotificationArg : EventArgs
    {
        // old value of that property 
        object oldValue;
        // name of the property 
        string propertyKey;

        public object OldValue
        {
            get
            {
                return oldValue;
            }
            // property could be set only at this scope 
            internal set { oldValue = value; }
        }

        // name of the property 
        public string PropertyKey
        {
            get { return this.propertyKey; }
        }

        // constructor 
        public NotificationArg(object oldValue, string propertyKey)
        {
            this.oldValue = oldValue;
            this.propertyKey = propertyKey;
        }
    }

    // base class for objects which can be followed 
    public abstract class UndoRedoObject : INotify
    {
        #region INotify 
        public event NotifyPropertyChnaging OnNotifyPropertyChanging;

        // this is not part of the interface but makes our live easer  
        protected virtual void Notify( object oldValue,[CallerMemberName]string properyName = "")
        {
             if (OnNotifyPropertyChanging != null)
                 OnNotifyPropertyChanging.Invoke(this, new NotificationArg(oldValue, properyName));
        }

        public event NotifyDisposed OnDispose;

        public bool SuspendListener
        {
            get;
            set;
        }

        public bool Disposed
        {
            get;
            private set;
        }

        public virtual void Dispose()
        {
            if (OnDispose != null)
                OnDispose.Invoke(this, new EventArgs());
            Disposed = true;
        }
        #endregion INotify
    }


}
