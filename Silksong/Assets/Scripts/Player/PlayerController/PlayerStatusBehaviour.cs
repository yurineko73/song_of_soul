using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatesBehaviour : StatesBehaviour
{
    PlayerController PlayerController { get; set; }
    public override void StatesEnterBehaviour(EPlayerState playerStates)
    {
        switch (playerStates)
        {
            case EPlayerState.None:
                break;
            case EPlayerState.Idle:
                break;
            case EPlayerState.Run:
                break;
            case EPlayerState.Jump:
                break;
            case EPlayerState.Fall:
                break;
            case EPlayerState.NormalAttack:
                PlayerController.CheckFlipPlayer(1f);
                break;
            default:
                break;
        }
    }
    //activeΪ�����stateʱ��һ֡��ʼ��Ҳ����û�а�start���зֿ�
    public override void StatesActiveBehaviour(EPlayerState playerStates)
    {
        switch (playerStates)
        {
            case EPlayerState.None:
                break;
            case EPlayerState.Idle:
                PlayerController.CheckIsGroundedAndResetAirJumpCount();
                PlayerController.CheckHorizontalMove(0.4f);
                break;
            case EPlayerState.Run:
                PlayerController.CheckIsGroundedAndResetAirJumpCount();
                PlayerController.CheckFlipPlayer(1f);
                PlayerController.CheckHorizontalMove(0.4f);
                break;
            case EPlayerState.Jump:
                PlayerController.CheckJump();
                PlayerController.IsGrounded = false;
                PlayerController.CheckFlipPlayer(1f);
                PlayerController.CheckHorizontalMove(0.5f);
                break;
            case EPlayerState.Fall:
                PlayerController.CheckIsGroundedAndResetAirJumpCount();
                PlayerController.CheckFlipPlayer(1f);
                PlayerController.CheckHorizontalMove(0.5f);
                break;
            case EPlayerState.NormalAttack:
                PlayerController.CheckHorizontalMove(0.5f);
                break;
            default:
                break;
        }
    }
    public override void StatesExitBehaviour(EPlayerState playerStates)
    {

    }

    public PlayerStatesBehaviour(PlayerController playerController) => this.PlayerController = playerController;
}

//���һЩ�������Ƶ��ǲ�ͬ��state�����������ת���idle����Ҫ���׸ı����е�enum��ֵ
public enum EPlayerState
{
    None = 0,
    Idle = 10,
    Run = 20,
    Jump = 30,
    Fall = 40,
    NormalAttack = 100,
}

public abstract class StatesBehaviour
{
    public abstract void StatesEnterBehaviour(EPlayerState playerStates);
    public abstract void StatesActiveBehaviour(EPlayerState playerStates);
    public abstract void StatesExitBehaviour(EPlayerState playerStates);
}
