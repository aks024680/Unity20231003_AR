
using System;
using UnityEngine;
using Vuforia;

namespace AR
{
    /// <summary>
    /// 按鈕事件
    /// </summary>
    public class CardManager : MonoBehaviour
    {
        [SerializeField, Header("動畫控制器")]
        private Animator ani;
        [SerializeField, Header("虛擬按鈕攻擊")]
        private VirtualButtonBehaviour vbbAttack;

        private string parAttack = "AttackTrigger";

        private void Awake()
        {
            vbbAttack.RegisterOnButtonPressed(PressAttackButton);
        }

        private void PressAttackButton(VirtualButtonBehaviour behaviour)
        {
            if (behaviour.VirtualButtonName == "Attack")
            {
                ani.SetTrigger(parAttack);
            }
        }
    }
}

