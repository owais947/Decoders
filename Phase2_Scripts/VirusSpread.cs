//code for citizens' behaviour and virus spread

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class VirusSpread : MonoBehaviour
{
    public static float speed;
    float shopReachTime, step;
    int nextShop;
    static int numberOfShops = 13;
    public static int numberOfInfected, infectedInMarket;

    Vector3[] shops = new Vector3[numberOfShops];

    public GameObject obj;

    public bool infected = false;
    public Material[] modes;
    SkinnedMeshRenderer myMesh;

    //this function is called everytime a person comes close to another
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Infected" && gameObject.tag != "Infected")
        {
            gameObject.tag = "Infected";        //if one of the people is infected, both are set to as infected
            infected = true;
            myMesh.material = modes[0];         //colour of the person is changed accordingly

            numberOfInfected++;                 
            infectedInMarket++;                 //number of infected people on the screen is increased by 1
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        speed = 0.75f;          //speed of citizens' movement is decided
        numberOfShops = 13;     //number of spots where citizens go in order to induce a busy market place
        numberOfInfected = 1;   //number of infected people at the start is 1
        infectedInMarket = 1;

        string nameOfCitizen = "Citizen (" + StartButtonScript.citizenInfected + ")";

        if (transform.name == nameOfCitizen)
            transform.tag = "Infected";

        myMesh = obj.GetComponent<SkinnedMeshRenderer>();

        //position of random spots are set
        shops[0] = new Vector3(-10,0,0);
        shops[1] = new Vector3(10, 0, 0);
        shops[2] = new Vector3(0, 0, -10);
        shops[3] = new Vector3(0, 0, 10);
        shops[4] = new Vector3(-10, 0, 10);
        shops[5] = new Vector3(-10, 0, -10);
        shops[6] = new Vector3(10, 0, -10);
        shops[7] = new Vector3(10, 0, 10);
        shops[8] = new Vector3(0, 0, 0);
        shops[9] = new Vector3(-5, 0, -5);
        shops[10] = new Vector3(-5, 0, 5);
        shops[11] = new Vector3(5, 0, -5);
        shops[12] = new Vector3(5, 0, 5);

        nextShop = Random.Range(0, numberOfShops-1);
        transform.LookAt(shops[nextShop]);
        
        //checks for the infected person in the starting
        if (transform.tag == "Infected")
        {
            infected = true;
            myMesh.material = modes[0];     //sets the colour red if infected
        }

        else
        {
            myMesh.material = modes[1];     //sets the colour green if not infected
        }
    }

    // Update is called once per frame
    public void Update()
    {
        step = speed * Time.deltaTime;

        //makes the person move until he or she reaches the spot randomly decided 
        if (transform.position != shops[nextShop])
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, shops[nextShop], step);
            shopReachTime = Time.time;      //records time when the person reaches the spot
        }
        else 
        {
            doShopping(shopReachTime);
        }
    }
    void doShopping(float reach)
    {
        //this helps to stop the person on the decides spots for 1 second to emulate the shopping process
        if (Time.time > reach + 1)
        {
            nextShop = Random.Range(0, numberOfShops);
            transform.LookAt(shops[nextShop]);      //sets the face of the citizen towards the next spot
        }
    }
    
}
