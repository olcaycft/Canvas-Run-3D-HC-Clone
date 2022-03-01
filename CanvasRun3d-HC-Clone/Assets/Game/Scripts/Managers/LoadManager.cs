using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Managers
{
    public class LoadManager : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene("UIScene", LoadSceneMode.Additive); //this is for open our ui scene as an additive
        }
    }
}