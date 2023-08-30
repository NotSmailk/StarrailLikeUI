using UnityEngine;

public class AnimatorHelper
{
    public static void SetBoolParameter(Animator animator, string parametre, bool value)
    {
        animator.SetBool(parametre, value);
    }
}
