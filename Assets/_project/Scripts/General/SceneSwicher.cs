using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwicher : MonoBehaviour
{
    public void SwichScene(int sceneId)
    {
        SceneManager.LoadSceneAsync(sceneId);
    }
}
