using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string sceneName = "NextScene"; // Name of the scene to switch to
    [SerializeField] private float delay = 5f; // Time delay before switching scenes

    private float timer = 0f; // Timer to keep track of the elapsed time

    public GameObject spaceToSkipUI;
    private bool canSkip;

    private void Start()
    {
        spaceToSkipUI.SetActive(false);
        canSkip = false;
    }
    private void Update()
    {
        // Increase the timer based on the time elapsed since the last frame
        timer += Time.deltaTime;

        // Check if the specified delay has passed
        if (timer >= delay)
        {
            // Reset the timer
            timer = 0f;

            // Switch to the specified scene
            SceneManager.LoadScene(sceneName);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (canSkip == true)
            {
                SceneManager.LoadScene(sceneName);
            }
            else if(canSkip == false)
            {
                spaceToSkipUI.SetActive(true);
                canSkip = true;
            }
        }
      
    }
     
}
