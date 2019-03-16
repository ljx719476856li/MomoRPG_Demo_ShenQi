using System.Collections;

public interface IState 
{
    /// <summary>
    /// 进入动画
    /// </summary>
    /// <param name="prevState"></param>
	void OnEnter( string prevState );
    /// <summary>
    /// 退出动画
    /// </summary>
    /// <param name="nextState"></param>
    void OnExit( string nextState );
    /// <summary>
    /// 保持动画
    /// </summary>
    void OnUpdate();
}
