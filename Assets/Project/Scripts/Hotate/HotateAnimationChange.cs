using UnityEngine;

public class HotateAnimationChange : MonoBehaviour
{
    //操作したいAnimationControllerを持ったGameObjectを割り当てる
    public Animator _animator;
    void Update()
    {
        // Bool
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            _animator.SetBool("Running", true);
        }
        else
        {
            _animator.SetBool("Running", false);
        }

    }

}