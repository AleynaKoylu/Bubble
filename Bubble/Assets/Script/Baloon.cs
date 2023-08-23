using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{

    float speed=2f;

    Color color;
    private void OnEnable()
    {
        CancelInvoke("ActiveFalse");

        Invoke("ActiveFalse", 8f);

    }
 


    void BaloonMovement()
    {
       
        transform.Translate(0, -speed * Time.deltaTime, 0);
       
            
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
