using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTemplate<T>
{
    public T owner;   //拥有者(范型)

    public StateTemplate(T o)
    {
        owner = o;
    }
}
