using UnityEngine;

public class DDArrowAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private bool _isDropdownOpen = false;

    public void Update()
    {
        bool isOpen = IsDropdownOpen();

        if (isOpen != _isDropdownOpen)
        {
            _isDropdownOpen = isOpen;

            if (_isDropdownOpen)
                _animator.SetInteger("IsActive", 1);
            else
                _animator.SetInteger("IsActive", 2);
        }
    }

    private bool IsDropdownOpen() => transform.Find("Dropdown List") != null;
}
