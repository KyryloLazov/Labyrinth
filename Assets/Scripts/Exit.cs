using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] int scrollNeeded = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            if(collision.transform.GetComponent<PlayerInteraction>().CheckScrolls() < scrollNeeded)
            {
                Debug.Log("Not enouqh keys!");
            }

            else
            {
                Debug.Log("You Win!");
            }
        }
    }
}