using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) //checks how many enemies are in scene
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //goes to the next scene in build settings
        }
    }
}
