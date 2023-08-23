using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject Baloon;

    int score = 0;
    int second = 50;

    List<GameObject> Baloons = new List<GameObject>();


    void Start()
    {

        LoadBaloon();
        InvokeRepeating("ShowBaloon", 0, 1f);
    }
    void LoadBaloon()
    {
        
        for (int i = 0; i < 10; i++)
        {
            GameObject newBaloon = Instantiate(Baloon, new Vector3(Random.Range(-2.30f, 2.30f), Random.Range(-4.8f,-6.5f), 1f), Quaternion.Euler(0,0,-180));
            
            Baloons.Add(newBaloon);
          
            newBaloon.SetActive(false);
        }
    }
    
   void ShowBaloon()
    {
        foreach (var b in Baloons)
        {
            if (b.activeSelf == false)
            {
                b.SetActive(true);
                b.transform.position = new Vector3(Random.Range(-2.30f, 2.30f), Random.Range(-4.8f, -6.5f), 1f);
                break;
            }
        }
    }

    void BaloonPop()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, 100))
        {
            if (hit.collider.CompareTag("Baloon"))
            {
                hit.collider.gameObject.SetActive(false);
                Score();
                
            }

        }
    }
    void Score()
    {
        score += 10;
        ReturnScore();
        Debug.Log(score);
    }
    int ReturnScore()
    {
        return score;
    }
  
    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            BaloonPop();
        }
    }
}
     

