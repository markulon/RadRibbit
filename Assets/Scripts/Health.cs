using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int levelToLoad = 0;
    private Animator anim;
    private int heartsMax = 3;

    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log(MainManager.Instance.Hearts);
        if (MainManager.Instance.Hearts == 0)
        {
            MainManager.Instance.Hearts = heartsMax;
        }
    }

    public void ChangeHearts(int change)
    {
        MainManager.Instance.Hearts += change;

        if (MainManager.Instance.Hearts > heartsMax)
        {
            MainManager.Instance.Hearts = heartsMax;
        }

        if (MainManager.Instance.Hearts <= 0)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    void Update()
    {
        anim.SetInteger("Health", MainManager.Instance.Hearts);
    }

}
