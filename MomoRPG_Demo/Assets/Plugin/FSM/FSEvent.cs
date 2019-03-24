using System;

/// <summary>
/// 该类主要处理事件的响应，定义有限状态机的状态，触发事件
/// </summary>
public class FSEvent
{
	protected FiniteStateMachine.EnterState mEnterDelegate;
	protected FiniteStateMachine.PushState	mPushDelegate;
	protected FiniteStateMachine.PopState	mPopDelegate;
	
	protected enum EventType { NONE, ENTER, PUSH, POP };  //定义了一个枚举用于处理有限状态机的状态
    protected string mEventName;
	protected FSState mStateOwner;
	protected string mTargetState;
	protected FiniteStateMachine mOwner;
	protected EventType eType;
	public Func<object,object,object,bool> mAction = null;
	
	public FSEvent( string name, string target, FSState state, FiniteStateMachine owner, FiniteStateMachine.EnterState e, FiniteStateMachine.PushState pu, FiniteStateMachine.PopState po )
	{
		mStateOwner 	= state;
		mEventName 		= name;
		mTargetState 	= target;
		mOwner			= owner;
		eType			= EventType.NONE;
		mEnterDelegate	= e;
		mPushDelegate	= pu;
		mPopDelegate	= po;
	}
	
	public FSState Enter( string stateName )
	{
		mTargetState 	= stateName;
		eType			= EventType.ENTER;
		return mStateOwner;
	}
	
	public FSState Push( string stateName )
	{
		mTargetState 	= stateName;
		eType 			= EventType.PUSH;
		return mStateOwner;
	}
	
	public void Pop()
	{
		eType = EventType.POP;	
	}
	
	public void Execute( object o1, object o2, object o3 )
	{
		if( eType == EventType.POP )
		{
			mPopDelegate();	
		}
		else if( eType == EventType.PUSH )
		{
			mPushDelegate( mTargetState, mOwner.CurrentState.StateName );
		}
		else if( eType == EventType.ENTER )
		{
			mEnterDelegate( mTargetState );	
		}
		else if( mAction != null )
		{
			mAction( o1, o2, o3 );	
		}
	}

    public override string ToString()
    {
        return this.mEventName;
    }
}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
