using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    private void LoadGamePlay(int sceneHashed)
    {
        SceneManager.LoadScene(sceneHashed);
    }
}
