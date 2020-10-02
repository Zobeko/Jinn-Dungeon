using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorChangeLevel : MonoBehaviour
{
    private int nextSceneIndex;
    

    // Start is called before the first frame update
    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
