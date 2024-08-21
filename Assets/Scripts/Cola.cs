using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Cola : MonoBehaviour
{
    public Logic logicScript;//script - Logic
    public int speed; //speed of player movement
    float horizontal;//left right
    float vertical;//up down
    public bool keyCollected; //if key is collected

    public GameObject keyItem;
    Rigidbody2D rb;

    public HPScript health;
   // AnimatorControllerParameter DamageTaken;???


    private void Start()
    {
        transform.position = Vector3.zero; //spwan point
        keyCollected = false;
    }


    void OnTriggerEnter2D(Collider2D collision) //if collide with trigger
    {
        if (collision.CompareTag("Key")) //if it's key
        {
            KeyCollected(collision.gameObject); //get function keycollected from logic script and execute it
        }

        if (collision.CompareTag("Trap")) //if it's key
        {
            TakeDamage(collision.gameObject); //get function keycollected from logic script and execute it
        }

        //if (collision.CompareTag("Object")) //if it's key
        //{
        //    Collected(collision.gameObject); //get function keycollected from logic script and execute it
        //    //keyCollected = true;  //key is collected (bollen = true)
        //}

    }

    public void KeyCollected(GameObject key)
    {
        keyCollected = true;  //key is collected (bollen = true)
        Destroy(key.gameObject);
        Debug.Log("Key Collected!");
        keyItem.gameObject.SetActive(true);
    }

    public void Collected(GameObject obj)
    {
        Destroy(obj.gameObject);
        Debug.Log("Object Collected!");
        //keyItem.gameObject.SetActive(true);
    }

    public void TakeDamage(GameObject trap)
    {
        health.RemoveHeart();
        Debug.Log("damaged!");
      
    }


    private void Awake() //execute once before the application starts.
    {
        rb = GetComponent<Rigidbody2D>();
    }


    
    void Update()// Update is called once per frame
    {

        horizontal = Input.GetAxis("Horizontal") * speed;
        vertical = Input.GetAxis("Vertical") * speed;

    }

    private void FixedUpdate() //physics stuff
    {
        rb.velocity = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
    }
}
