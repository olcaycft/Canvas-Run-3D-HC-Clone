using Game.Scripts.Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Managers
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        [SerializeField] private int level = 1;
        private int currentLevel;
        private int nextLevel;

        private void Awake()
        {
            //DontDestroyOnLoad(gameObject);
            
            LoadLevel(1); //loading scene
            Invoke(nameof(LoadFirstScene), 3f);
            
            if (PlayerPrefs.GetInt("Level") < level)
            {
                PlayerPrefs.SetInt("Level", level);
            }
            else
            {
                level = PlayerPrefs.GetInt("Level");
            }
        }

        private void LoadFirstScene()
        {
            if (PlayerPrefs.GetInt("Level", 1) + 2 < SceneManager.sceneCountInBuildSettings)
            {
                LoadLevel(PlayerPrefs.GetInt("Level", 1) + 2);
            }
            else
            {
                //LoadLevel(SceneManager.sceneCountInBuildSettings - 1); //infinitelevel
                LoadLevel(3);//first level
            }
        }

        private void LoadLevel(int index)
        {
            currentLevel = index;
            Camera camera = Extentions.Camera;
            if (camera != null)
            {
                camera.cullingMask = 0;
            }

            Invoke(nameof(LoadScene), 0f);
        }

        private void LoadScene()
        {
            SceneManager.LoadScene(currentLevel);
        }

        public void PlayCurrentLevel()
        {
            LoadLevel(currentLevel);
        }

        public void PlayNextLevel()
        {
            nextLevel = currentLevel + 1;
            level++;
            PlayerPrefs.SetInt("Level", level);
            if (nextLevel < SceneManager.sceneCountInBuildSettings)
            {
                LoadLevel(nextLevel);
            }
            else
            {
                //LoadLevel(SceneManager.sceneCountInBuildSettings - 1);// if nextlevel bigger then my scene count play infinite level
                LoadLevel(3); //first level
            }
        }
        
    }
}