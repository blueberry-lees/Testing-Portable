using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPScript : MonoBehaviour
{
    public int heartAmount = 3;
    public GameObject[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frames
    void Update()
    {
        
    }

    [ContextMenu("Remove")]
    public void RemoveHeart()
    {
        heartAmount--;
        hearts[heartAmount].gameObject.SetActive(false);

        if (heartAmount == 0)
            Die();
    }

    public void Die()
    {
        Debug.Log("DED");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Respawn, etc.
    }
}
