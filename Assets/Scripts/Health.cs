using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int levelToLoad = 0;
    private Animator anim;
    private int heartsMax = 3;

    [SerializeField] private float delayBeforeActivation = .5f; // Time in seconds

    void Start()
    {
        anim = GetComponent<Animator>();
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
            StartCoroutine(WaitAndLoadScene(delayBeforeActivation)); // 5 seconds wait
        }
    }

    void Update()
    {
        anim.SetInteger("Health", MainManager.Instance.Hearts);
    }

    private IEnumerator WaitAndLoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelToLoad);
    }

}
