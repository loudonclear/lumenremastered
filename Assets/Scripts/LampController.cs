using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour {

    public List<Fade> targets;
    public AudioClip forward, backward;

    private Animator animator;
    private AudioSource audio;

    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            Fade obj = targets[i];
            obj.AltFade();
        }

        bool lit = animator.GetBool("lit");

        if (lit)
        {
            audio.clip = backward;
        } else
        {
            audio.clip = forward;
        }

        audio.Play();
        animator.SetBool("lit", !lit);
    }

}
