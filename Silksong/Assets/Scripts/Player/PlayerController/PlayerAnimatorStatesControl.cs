using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PlayerAnimatorStatesControl : AnimatorStatesControl
{
    public override Animator Animator { get; }
    //��ɫ�ڲ�ͬ��state�ϵ���Ϊ����animator��state�ϵ�SMB�����ö�Ӧ������state
    public override StatesBehaviour CharacterStatesBehaviour { get; set; }
    //animator����ӳ��
    public override AnimatorParamsMapping CharacterAnimatorParamsMapping { get; }
    //�ṩһ���趨��ɫstate֮��ת����״̬������һ��״̬�д�ʲôʱ��ʼ�ܹ���������animator��state�ϵ�SMB�����ö�Ӧ������status
    public PlayerStatusDic PlayerStatusDic { get; private set; }

    public PlayerController PlayerController { get; set; }
    public EPlayerState CurrentPlayerState { get; set; }

    public PlayerAnimatorStatesControl(PlayerController playerController, Animator animator, EPlayerState currentPlayerState)
    {
        this.Animator = animator;
        this.PlayerController = playerController;
        this.CurrentPlayerState = currentPlayerState;
        this.CharacterStatesBehaviour = new PlayerStatesBehaviour(this.PlayerController);
        this.CharacterAnimatorParamsMapping = new PlayerAnimatorParamsMapping(this);
        this.PlayerStatusDic = new PlayerStatusDic(this.PlayerController);
        PlayerSMBEvents.Initialise(this.Animator);
    }

    //public void Initialize(StatusBehaviour behaviour)
    //{

    //}

    public void PlayerStatusUpdate()
    {
        IdleStatePlayerStatusFlagOverrideAsTrue();
        PlayerStatusDic[EPlayerStatus.CanJump].SetFlag(PlayerController.CurrentAirExtraJumpCountLeft > 0 || PlayerController.IsGrounded);

        void IdleStatePlayerStatusFlagOverrideAsTrue()
        {
            if (CurrentPlayerState == EPlayerState.Idle)
            {
                PlayerStatusDic[EPlayerStatus.CanMove].SetFlag(true);
                PlayerStatusDic[EPlayerStatus.CanJump].SetFlag(true);
                PlayerStatusDic[EPlayerStatus.CanNormalAttack].SetFlag(true);
            }
        }
    }

    public void BehaviourLateUpdate()
    {
        CharacterStatesBehaviour.StatesActiveBehaviour(CurrentPlayerState);
    }

    public void ChangePlayerState(EPlayerState newState)
    {
        CharacterStatesBehaviour.StatesExitBehaviour(CurrentPlayerState);
        CurrentPlayerState = newState;
        CharacterStatesBehaviour.StatesEnterBehaviour(newState);
    }

}

public abstract class AnimatorStatesControl
{
    public abstract Animator Animator { get; }
    public abstract StatesBehaviour CharacterStatesBehaviour { get; set; }
    public abstract AnimatorParamsMapping CharacterAnimatorParamsMapping { get; }

    public void ParamsUpdate() => this.CharacterAnimatorParamsMapping.ParamsUpdate();
}