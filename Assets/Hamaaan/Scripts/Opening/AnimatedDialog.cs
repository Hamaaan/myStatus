using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatedDialog : MonoBehaviour
{
    //アニメーター
    [SerializeField] private Animator animator;

    //レイヤー
    [SerializeField] private int layer;

    //フラグ
    private static readonly int ParamIsOpen = Animator.StringToHash("IsOpen");

    //ダイアログは開いてるかどうか
    public bool IsOpen => gameObject.activeSelf;

    //アニメーション中かどうか
    public bool IsTransition { get; private set; }

    public void Open()
    {
        //不正防止
        if (IsOpen || IsTransition) return;

        //アクティブにする
        gameObject.SetActive(true);

        animator.SetBool(ParamIsOpen, true);

        StartCoroutine(WaitAnimation("Opened"));
    }
    public void Close()
    {
        if (!IsOpen || IsTransition) return;

        animator.SetBool(ParamIsOpen, false);

        StartCoroutine(WaitAnimation("Closed", () => gameObject.SetActive(false)));
    }

    private IEnumerator WaitAnimation(string stateName, UnityAction onCompleted = null)
    {
        IsTransition = true;

        yield return new WaitUntil(() =>
        {
            var state = animator.GetCurrentAnimatorStateInfo(layer);
            return state.IsName(stateName) && state.normalizedTime >= 1;
        }
        );

        IsTransition = false;

        onCompleted?.Invoke();
    }
}
