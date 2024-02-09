using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum LoadTypes
    {
        LoadScene,
        LoadSceneAdditive,
        LoadSceneAsync
    }

    public LoadTypes loadType;

    public void LoadScene(Object sceneObj)
    {
        LoadSceneInternal(sceneObj.name);
    }

    public void LoadScene(int index)
    {
        LoadSceneInternal(index.ToString());
    }

    public void LoadScene(string byName)
    {
        LoadSceneInternal(byName);
    }
    
    public void LoadScene(Object sceneObj, LoadTypes type)
    {
        loadType = type;
        LoadScene(sceneObj);
    }
    
    private void LoadSceneInternal(string sceneName)
    {
        switch (loadType)
        {
            case LoadTypes.LoadScene:
                SceneManager.LoadScene(sceneName);
                break;
            case LoadTypes.LoadSceneAsync:
                SceneManager.LoadSceneAsync(sceneName);
                break;
            case LoadTypes.LoadSceneAdditive:
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
                break;
        }
    }
}