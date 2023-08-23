using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject Baloon;

    public int score = 0;
    float second = 20;

    List<GameObject> Baloons = new List<GameObject>();

    [SerializeField]
    TextMeshProUGUI SecondTxt;
    [SerializeField]
    TextMeshProUGUI ScoreTxt;

    public float time;

    [SerializeField]
    GameObject popEffect;

    [SerializeField]
    AudioSource audioSource;


    void Start()
    {

        LoadBaloon();
        InvokeRepeating("ShowBaloon", 0, 1f);
        SecondTxt.text = second.ToString();
        WriteScore();

    }

    public void IncreasingSpeed()
    {
        time += Time.deltaTime;

        if (time >= time + 50)
        {

        }
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

                GameObject newEffect = Instantiate(popEffect, hit.transform.position,Quaternion.identity);
                newEffect.GetComponent<ParticleSystem>().startColor = hit.collider.GetComponent<MeshRenderer>().material.color;

                Destroy(newEffect, .5f);
                audioSource.Play();
                hit.collider.gameObject.SetActive(false);
                
                if (hit.collider.name=="Red")
                {
                    second -= 10;
                }
                else
                {
                    second += 2;
                    Score();
                }
            }

        }
    }
    void Score()
    {
        score += 10;
        ReturnScore();
        WriteScore();
    }
    int ReturnScore()
    {
        return score;
    }
    void Second()
    {
        second -=Time.deltaTime;
        int time = (int)second;
        SecondTxt.text =time.ToString();
        if (time == 0)
        {
            Time.timeScale = 0;
        }
    }
    public void WriteScore()
    {
        ScoreTxt.text = score.ToString();
    }
    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Mouse0)&&Time.timeScale==1)
        {
            BaloonPop();
        }
        Second();
        
        
    }
}
     

