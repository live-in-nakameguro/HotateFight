using UnityEngine;

public class HotateAnimationChange : MonoBehaviour
{
    //‘€ì‚µ‚½‚¢AnimationController‚ğ‚Á‚½GameObject‚ğŠ„‚è“–‚Ä‚é
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