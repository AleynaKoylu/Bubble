using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{

    float speed;

    MeshRenderer meshRenderer;

    [SerializeField]
    List<Material> Materials = new List<Material>();

    GameManager gameManager;
    GameObject GameManageR;
    private void OnEnable()
    {
        GameManageR = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = GameManageR.GetComponent<GameManager>();
        CancelInvoke("ActiveFalse");

        Invoke("ActiveFalse", 13f);

        ChangeColor(gameObject);

        speed = gameManager.bSpeed;
    }
   
    public void ChangeColor(GameObject bl)
    {
        meshRenderer = bl.GetComponent<MeshRenderer>();
        int colorID = Random.Range(0, 8);
        switch (colorID)
        {
            case 0:
                meshRenderer.material = Materials[0];
                bl.name = Materials[0].name;
                break;
            case 1:
                meshRenderer.material = Materials[1];
                bl.name = Materials[1].name;
                break;
            case 2:
                meshRenderer.material = Materials[2];
                bl.name = Materials[2].name;
                break;
            case 3:
                meshRenderer.material = Materials[3];
                bl.name = Materials[3].name;
                break;
            case 4:
                meshRenderer.material = Materials[4];
                bl.name = Materials[4].name;
                break;
            case 5:
                meshRenderer.material = Materials[5];
                bl.name = Materials[5].name;
                break;


        }
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ylimit") && gameObject.name != "Red")
        {
            gameManager.score -= 5;
            gameManager.second -= 10f;
            gameManager.WriteSecond();
            gameManager.WriteScore();
        }
    }


}
