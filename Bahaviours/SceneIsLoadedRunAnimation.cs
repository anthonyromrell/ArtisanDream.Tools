using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIsLoadedRunAnimation : MonoBehaviour
{
    public float loadTime = 2;

    private void Awake()
    {
        SceneManager.sceneLoaded += Loaded;
    }

    private void Loaded(Scene arg0, LoadSceneMode arg1)
    {
        StartCoroutine(WaitOnLoad());
    }

    private IEnumerator WaitOnLoad()
    {
        yield return new WaitForSeconds(loadTime);
        var anim = GetComponent<Animator>();
        anim.SetTrigger("IsLoaded");
    }
}