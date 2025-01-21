using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator animator;
    CharacterMovement movementScript;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource runSound;
    [SerializeField] private PlanetsSceneManager sceneManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        movementScript = GetComponent<CharacterMovement>();
        if(GameManager.playerColor != null)
        {
            GetComponent<SkinnedMeshRenderer>().materials = GameManager.playerColor;
        }   
    }

    void Update()
    {
        if(sceneManager.gameIsOn)
        {
            if (movementScript.isJumping)
            {
                animator.SetInteger("AnimationPar", 2);
                runSound.Stop();
            }
            else if (movementScript.isRunning)
            {
                animator.SetInteger("AnimationPar", 1);

                if (!runSound.isPlaying)
                {
                    runSound.Play();
                }
            }
            else
            {
                animator.SetInteger("AnimationPar", 0);
                runSound.Stop();
            }
        }
        else
        {
            animator.SetInteger("AnimationPar", 0);
            runSound.Stop();
        }
    }

    public void PlayJumpSound()
    {
        if (!jumpSound.isPlaying && sceneManager.gameIsOn)
        {
            jumpSound.PlayOneShot(jumpSound.clip);
        }
    }
}
