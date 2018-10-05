using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public float rotationSpeed;
    public SpriteRenderer rend;
    public SpriteRenderer rend1;
    public SpriteRenderer rend2;
    public Transform other;
    public Color newColor;
    public float Timer;
    

    
    // Use this for initialization
    void Start () {
        rend.color = newColor;
        rend.color = new Color(1f, 1f, 1f);
        rend1.color = newColor;
        rend1.color = new Color(1f, 1f, 1f);
        rend2.color = newColor;
        rend2.color = new Color(1f, 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-3f * Time.deltaTime, 0, 0, Space.Self);
        //Skeppet åker konstant framåt

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
            rend.color = new Color(0f, 1f, 0f);
            rend1.color = new Color(0f, 1f, 0f);
            rend2.color = new Color(0f, 1f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
            rend.color = new Color(0f, 0f, 1f);
            rend1.color = new Color(0f, 0f, 1f);
            rend2.color = new Color(0f, 0f, 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(+1.5f * Time.deltaTime, 0, 0, Space.Self);
        }
        Debug.Log(Timer + 1 + "seconds");
        
        Timer = Timer + 1 * Time.deltaTime;
    }
}
