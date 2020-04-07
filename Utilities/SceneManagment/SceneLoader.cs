using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    public enum LoadTypes
    {
        LoadScene,
        LoadSceneAdditive,
        LoadSceneAsync
    }

    public LoadTypes loadType;
    
    public void LoadScene (Object sceneObj) //Note this is experimental will not work in build with Scenes
    {
       
        SceneManager.LoadScene(sceneObj.name);
        
        switch (loadType)
        {
            case LoadTypes.LoadScene:
                SceneManager.LoadScene(sceneObj.name);
                break;
            case LoadTypes.LoadSceneAsync:
                SceneManager.LoadSceneAsync(sceneObj.name);
                break;
            case LoadTypes.LoadSceneAdditive:
                SceneManager.LoadScene(sceneObj.name, LoadSceneMode.Additive);
                break;
        }
    }

    public void LoadScene(int index)
    {
        switch (loadType)
        {
            case LoadTypes.LoadScene:
                SceneManager.LoadScene(index);
                break;
            case LoadTypes.LoadSceneAsync:
                SceneManager.LoadSceneAsync(index);
                break;
            case LoadTypes.LoadSceneAdditive:
                SceneManager.LoadScene(index, LoadSceneMode.Additive);
                break;
        }
    }

    public void LoadScene (string byName)
    {
        switch (loadType)
        {
            case LoadTypes.LoadScene:
                SceneManager.LoadScene(byName);
                break;
            case LoadTypes.LoadSceneAsync:
                SceneManager.LoadSceneAsync(byName);
                break;
            case LoadTypes.LoadSceneAdditive:
                SceneManager.LoadScene(byName, LoadSceneMode.Additive);
                break;
        }
    }
}