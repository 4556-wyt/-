using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState currentState {  get; private set; }//{  get; private set; }����˽��������������õ���ʱ�ǹ��еģ�����ı���ʱ��˽�еģ���������Կ������ֵ�����㲻�����κη�ʽӰ����

    public void Initiallize(PlayerState _statestate)//��ʼ���������ú�����ֻ������һ��
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
