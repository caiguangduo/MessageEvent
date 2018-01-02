using System;
using System.Collections;

public delegate void  CEventListenerDelegate(CBaseEvent evt);

public class CEventDispatcher
{
    static CEventDispatcher instance;
    public static CEventDispatcher GetInstance()
    {
        if (instance == null)
            instance = new CEventDispatcher();
        return instance;
    }

    private Hashtable listeners = new Hashtable();

    public void AddEventListener(CEventType eventType, CEventListenerDelegate listener)
    {
        CEventListenerDelegate ceventListenerDelegate = this.listeners[eventType] as CEventListenerDelegate;
        ceventListenerDelegate = (CEventListenerDelegate)Delegate.Combine(ceventListenerDelegate, listener);
        this.listeners[eventType] = ceventListenerDelegate;
    }

    public void RemoveEventListener(CEventType eventType, CEventListenerDelegate listener)
    {
        CEventListenerDelegate ceventListenerDelegate = this.listeners[eventType] as CEventListenerDelegate;
        if (ceventListenerDelegate != null)
            ceventListenerDelegate = (CEventListenerDelegate)Delegate.Remove(ceventListenerDelegate, listener);
        this.listeners[eventType] = ceventListenerDelegate;
    }

    public void RemoveAll()
    {
        this.listeners.Clear();
    }

    public void DispatchEvent(CBaseEvent evt)
    {
        CEventListenerDelegate ceventListenerDelegate = this.listeners[evt.Type] as CEventListenerDelegate;
        if (ceventListenerDelegate != null)
        {
            try
            {
                ceventListenerDelegate(evt);
            }
            catch(Exception ex)
            {
                throw new Exception(string.Concat(new string[]
                {
                    "Error dispatching event", 
                    evt.Type.ToString(),
                    ": ",
                    ex.Message,
                    " ",
                    ex.StackTrace
                }), ex);
            }
        }
    }

}

