using System;
using System.Collections;

public class CBaseEvent
{
    protected Hashtable arguments;
    protected CEventType type;
    protected object sender;

    public CEventType Type
    {
        get
        {
            return this.type;
        }
        set
        {
            this.type = value;
        }
    }

    public IDictionary Params
    {
        get
        {
            return this.arguments;
        }
        set
        {
            this.arguments = (value as Hashtable);
        }
    }

    public object Sender
    {
        get
        {
            return this.sender;
        }
        set
        {
            this.sender = value;
        }
    }

    public override string ToString()
    {
        return this.type + "[" + ((this.sender == null) ? "null" : this.sender.ToString()) + "]";
    }

    public CBaseEvent Clone()
    {
        return new CBaseEvent(this.type, this.arguments, Sender);
    }

    public CBaseEvent(CEventType type, Object sender)
    {
        this.Type = type;
        Sender = sender;
        if (this.arguments == null)
        {
            this.arguments = new Hashtable();
        }
    }

    public CBaseEvent(CEventType type, Hashtable args, Object sender)
    {
        this.Type = type;
        this.arguments = args;
        Sender = sender;
        if (this.arguments == null)
            this.arguments = new Hashtable();
    }

}


