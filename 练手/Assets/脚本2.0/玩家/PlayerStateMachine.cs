using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState currentState {  get; private set; }//{  get; private set; }公有私有设置器（你想得到他时是公有的，你想改变他时是私有的，所以你可以看到这个值但是你不能以任何方式影响他

    public void Initiallize(PlayerState _statestate)//初始化函数，该函数将只被调用一次
    {
        currentState=_statestate;
        currentState.Enter();
    }

    public void ChangeState(PlayerState _newstate)
    {
        currentState.Exit();
        currentState = _newstate;
        currentState.Enter();
    }

}
