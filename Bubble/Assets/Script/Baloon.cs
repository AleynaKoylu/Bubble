using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{

    float speed=2f;


    private void OnEnable()
    {
        

    }
 


    void BaloonMovement()
    {
       
        transform.Translate(0, -speed * Time.deltaTime, 0);
        if (transform.position.y >= 6.74f)
        {
            ActiveFalse();
        }
       
            
    }
    void ActiveFalse()
    {
        gameObject.SetActive(false);
    }
    
    void Update()
    {
        BaloonMovement();
    }
    
    
}
