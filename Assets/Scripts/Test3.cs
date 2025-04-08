using UnityEngine;
using UnityEngine.SceneManagement;

public class Test3 : MonoBehaviour
{
    
  

    void Start()
    {
        SceneManager.LoadSceneAsync("Test_1", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Test_2", LoadSceneMode.Additive);
    }

}
