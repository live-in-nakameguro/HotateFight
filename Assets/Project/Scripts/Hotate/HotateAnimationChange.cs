using UnityEngine;

public class HotateAnimationChange : MonoBehaviour
{
    //���삵����AnimationController��������GameObject�����蓖�Ă�
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