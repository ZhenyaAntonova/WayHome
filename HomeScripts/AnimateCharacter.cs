using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCharacter : MonoBehaviour
{
    Animator animator;
    PlayerController controller;
    [SerializeField] private HomeSceneManager sceneManager;
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();

    }
    
    void Update()
    {
        if(sceneManager.gameIsOn)
        {
            if (controller.isWalking)
            {
                animator.SetInteger("AnimationPar", 3);
            }
            else
            {
                animator.SetInteger("AnimationPar", 0);
            }
        }
        else
        {
            animator.SetInteger("AnimationPar", 0);
        }
    }
}
