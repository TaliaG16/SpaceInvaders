using System.Collections;using System.Collections.Generic;using UnityEngine;public class CannonBallScript : MonoBehaviour{    private float totalTime;    public float cannonBallSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()    {
        totalTime = 0;
    }

    // Update is called once per frame
    void Update()    {        if (GeneralScript.freezeGame == true)
            return;        float ytrans = Time.deltaTime * cannonBallSpeed;        transform.Translate(0, ytrans, 0);        totalTime += Time.deltaTime;        if(transform.position.y >= GeneralScript.top)
        {
            Destroy(gameObject);
        }    }}
