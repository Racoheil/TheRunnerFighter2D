using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _currentAnimation;

    public static PlayerAnimation instance;
    void Awake()
    {
        instance = this;
    }

    public void ChangeAnimation(string animation)
    {
        if (_currentAnimation == animation) return;
        else _animator.Play(animation);
    }
}
