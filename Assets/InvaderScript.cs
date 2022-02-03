using System.Collections;using System.Collections.Generic;using UnityEngine;public class InvaderScript : MonoBehaviour{
    public float invaderSpeed = -0.1f;
    private float invaderDir = -3f;

// Start is called before the first frame update
    void Start()    {
        float xval = Random.Range(GeneralScript.left+1, GeneralScript.right-1);
        float yval = Random.Range(0, GeneralScript.top);
        transform.position = new Vector3(xval, yval, 0);
    }

    // Update is called once per frame
    void Update()    {
        if (GeneralScript.freezeGame == true)
            return;

        float xtrans = Time.deltaTime * invaderDir;
        float ytrans = Time.deltaTime * invaderSpeed;        transform.Translate(xtrans, ytrans, 0);        if (transform.position.x < GeneralScript.left)
        {
            invaderDir = 5f;
        }
        else if (transform.position.x > GeneralScript.right)
        {
            invaderDir = -3f;
        }        if (transform.position.y <= GeneralScript.bottom)
        {
            GameObject.Find("Main Camera").GetComponent<GeneralScript>().GameOver();
        }    }    void OnTriggerEnter(Collider other)    {        if(other.tag.Equals("CannonBall"))
        {
            print("OnTriggerEnter");
            Destroy(gameObject);
            GameObject.Find("Main Camera").GetComponent<GeneralScript>().Shot(); 
        }    }}
