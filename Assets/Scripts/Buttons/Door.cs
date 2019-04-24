using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void GoUp()
    {
        _animator.SetBool("IsOpen", true);
    }

    public void GoDown()
    {
        _animator.SetBool("IsOpen", false);
    }
}
