using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
	public delegate void EnterState( string stateName );
	public delegate void PushState( string stateName, string lastStateName );
	public delegate void PopState();
	
	protected Dictionary<string, FSState> 	mStates; //用于State注册
    protected string 						mEntryPoint; 
    protected Stack<FSState>				mStateStack;//存放FSState，通过Update进行状态的切换

    public FiniteStateMachine()
	{
		mStates 	= new Dictionary<string, FSState>();
		mStateStack = new Stack<FSState>();
		mEntryPoint	= null;
	}
	
	public FSState CurrentState
	{
		get
		{
			if( mStateStack.Count == 0 )
			{
				return null;	
			}
			return mStateStack.Peek();
		}
	}
	
	public void Update()
	{
		if( CurrentState == null )
		{
			mStateStack.Push( mStates[ mEntryPoint ] );
			CurrentState.StateObject.OnEnter( null );  //触发当前事件，OnEnter
        }
		CurrentState.StateObject.OnUpdate(); //触发当前事件，OnUpdate
    }
	
	public void Register( string stateName, IState stateObject )
	{
		if( mStates.Count == 0 )
		{
			mEntryPoint = stateName;	
		}
		mStates.Add( stateName, new FSState( stateObject, this, stateName, Enter, Push, Pop )); //添加state状态，并且赋值给委托
	}
	
	public FSState State( string stateName )
	{
		return mStates[ stateName ];	
	}
	
	public void EntryPoint( string startName )
	{
		mEntryPoint = startName;	
	}
	
	public void Enter( string stateName )
	{
		Push( stateName, Pop( stateName ));	
	}
	
	public void Push( string newState )
	{
		string lastName = null;
		if( mStateStack.Count > 1 )
		{
			lastName = mStateStack.Peek().StateName;	
		}
		Push( newState, lastName );
	}
	
	public void Push( string stateName, string lastStateName )
	{
        Debug.Log("Push -> mStateStack" + stateName);

        mStateStack.Push( mStates[ stateName ] );
		mStateStack.Peek().StateObject.OnEnter( lastStateName ); //触发栈顶事件，OnEnter
	}
	
	public void Pop()
	{
		Pop( null );	
	}
	
	protected string Pop( string newName )
	{
		FSState lastState = mStateStack.Peek();
		string newState = null;
		if( newName == null && mStateStack.Count > 1 )
		{
			int index = 0;
			foreach( FSState item in mStateStack )
			{
				if( index++ == mStateStack.Count - 2 )
				{
					newState = item.StateName;
				}
			}
		}
		else
		{
			newState = newName;	
		}
		
		string lastStateName = null;
		if( lastState != null )
		{
			lastStateName = lastState.StateName;
			lastState.StateObject.OnExit( newState ); //触发栈顶事件，OnExit
        }
		mStateStack.Pop();
		return lastStateName;
	}
	
	public void Trigger( string eventName )
	{
		CurrentState.Trigger( eventName );	
	}
	
	public void Trigger( string eventName, object param1 )
	{
		CurrentState.Trigger( eventName, param1 );	
	}
	
	public void Trigger( string eventName, object param1, object param2 )
	{
		CurrentState.Trigger( eventName, param1, param2 );	
	}
	
	public void Trigger( string eventName, object param1, object param2, object param3 )
	{
		CurrentState.Trigger( eventName, param1, param2, param3 );
	}
}
