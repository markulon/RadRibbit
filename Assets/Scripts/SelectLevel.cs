using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] private int levelToLoad = 0;

    void Start(){
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
