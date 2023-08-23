using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject Baloon;

    int score = 0;
    float second = 50;

    List<GameObject> Baloons = new List<GameObject>();


    [SerializeField]
    List<Material> Materials = new List<Material>();


    MeshRenderer meshRenderer;
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

            ChangeColor(newBaloon);


        }

    }
  
    void ChangeColor(GameObject baloon)
    {
        meshRenderer = baloon.GetComponent<MeshRenderer>(); 
        int colorID = Random.Range(0, 8);
        switch (colorID)
        {
            case 0:
                meshRenderer.material = Materials[0];
                    break;
            case 1:
                meshRenderer.material = Materials[1];
                baloon.name = "Red";
                break;
            case 2:
                meshRenderer.material = Materials[2];
                break;
            case 3:
                meshRenderer.material = Materials[3];
                break;
            case 4:
                meshRenderer.material = Materials[4];
                break;
            case 5:
                meshRenderer.material = Materials[5];
                break;
            
            
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
                ChangeColor(b);
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
                if (hit.collider.name=="Red")
                {
                    second -= 10;
                }
                else
                {
                    second += 10;
                }
            }

        }
    }
    void Score()
    {
        score += 10;
        ReturnScore();
        
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
        second -= Time.deltaTime;
        Debug.Log((int)second);
        
    }
}
     

