using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public Transform cannonBallPrefab;
    public float cannonSpeed = 1.0f;
    private float rot = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, GeneralScript.bottom, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GeneralScript.freezeGame == true)
            return;

        float rotate = Input.GetAxis("Rotate") * Time.deltaTime * rot;
        if (rotate != 0)
        {
            print("in rotate");
            transform.position = new Vector3(0, GeneralScript.bottom, 0);
            transform.Rotate(0, 0, -rotate);
            if (transform.eulerAngles.z < 180)
            {
                if (transform.eulerAngles.z > 90)
                {
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }
            }
            else
            {
                if (transform.eulerAngles.z < 270)
                {
                    transform.eulerAngles = new Vector3(0, 0, 270);
                }
            }
        }

        float xtrans = Input.GetAxis("Horizontal") * Time.deltaTime * cannonSpeed;
        if (xtrans != 0)
        {
            print("in move");
            transform.Translate(xtrans, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            if (transform.position.x > GeneralScript.right)
                transform.position = new Vector3(GeneralScript.right, transform.position.y, transform.position.z);
            else if (transform.position.x < GeneralScript.left)
                transform.position = new Vector3(GeneralScript.left, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown("space"))
        {
            Instantiate(cannonBallPrefab, transform.position, transform.rotation);
        }

    }    
}

