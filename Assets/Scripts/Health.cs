using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private Animator anim;
    private int heartsMax = 3;

    public int hearts;

    void Start()
    {
        anim = GetComponent<Animator>();
        hearts = MainManager.Instance.Hearts;
        Debug.Log(MainManager.Instance.Hearts);
        if (hearts == 0)
        {
            hearts = heartsMax;
        }
    }

    public void ChangeHearts(int change)
    {
        hearts += change;

        if (hearts > heartsMax)
        {
            hearts = heartsMax;
        }

        if (hearts <= 0)
        {
            Debug.Log("you dead bruv");
        }
    }

    void Update()
    {
        anim.SetInteger("Health", hearts);
    }

}
