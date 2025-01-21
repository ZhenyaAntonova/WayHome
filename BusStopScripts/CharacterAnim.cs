using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    Animator animator;
    CharactersMoving moveScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        moveScript = GetComponentInParent<CharactersMoving>();
    }

    
    void Update()
    {
        if(!moveScript.stopped)
        {
            animator.SetInteger("AnimationPar", 1);
        }
        else
        {
            animator.SetInteger("AnimationPar", 0);
        }
    }
}
