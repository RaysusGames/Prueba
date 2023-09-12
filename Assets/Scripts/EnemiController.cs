
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiController : MonoBehaviour
{

    public GameObject player;

    public float initialPos;

    public float maxPos;

    public List<GameObject> enemy = new List<GameObject>();

    public float pos;


    // Start is called before the first frame update
    void Start()
    {
        initialPos = player.transform.position.y;

        maxPos =  5;
    }

    // Update is called once per frame
    void Update()
    {

        
        if(player.transform.position.x >= maxPos)
        {

            Debug.Log("si");
            Generate();
            maxPos += 10;
            return;

        }
    }

    public void Generate()
    {
        float x = player.transform.position.x +20f ;

        float e = Random.Range(0,2);

        if (e == 1)
        {

              Instantiate(enemy[Random.Range(0,enemy.Count)], new Vector3(x, 0,0 ), Quaternion.identity);

        }
        if(e == 2)
        {

             Instantiate(enemy[Random.Range(0,enemy.Count)], new Vector3(x, -1.3f ,0 ), Quaternion.identity);
    }   

        }

     
      
       

   
}
