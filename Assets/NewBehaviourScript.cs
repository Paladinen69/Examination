using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    public float rotationSpeed; // svänghastighet
    public SpriteRenderer spaceShipRend;   
    public SpriteRenderer spaceShipRend1;
    public SpriteRenderer spaceShipRend2; //Jag gjorde 3 olika rends eftersom skeppet består av 3 sprites så jag gav en till varje, lyckades inte göra till en enda stor 
    
    public Color newColor; //Dens färg
    public int Timer;
    public float BlueColor;
    public float RedColor;
    public float GreenColor; // variabler för dom 3 färgerna röd, blå, grön
    public float fastRotation; // snabb svängning
    public float slowRotation; //långsam svängning
    private float randomStartValueX;  //slumpmässiga x värdet
    private float randomStartValuey;  //slumpmässiga y värdet
    private float startSpeed;         //farten den får i början
     public Transform shipPosition;   //dens position


    // Use this for initialization
    void Start()
    {
        randomStartValueX = (Random.Range(-5, 5));
        randomStartValuey = (Random.Range(-8, 8)); // slumpar startpositionen

        spaceShipRend.color = newColor;
        spaceShipRend.color = new Color(1f, 1f, 1f);
        spaceShipRend1.color = newColor;
        spaceShipRend1.color = new Color(1f, 1f, 1f);
        spaceShipRend2.color = newColor;
        spaceShipRend2.color = new Color(1f, 1f, 1f); // när spelet startar så blir den vit, pga alla färger har samma värde.
        BlueColor = 0;
        GreenColor = 0;
        RedColor = 0; // varje färg har var sin variabel
        Timer = 1;
        fastRotation = 3; //Roterar snabbare
        slowRotation = 1; // Roterar långsammare


        startSpeed = (Random.Range(0f, -8f)); // Ger skeppet en extra fart som är 'random'



        transform.Translate(randomStartValueX, randomStartValueX, 10); //sätter skeppet på slumpmässigt ställe när spelet startas.
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(startSpeed * Time.deltaTime, 0, 0, Space.Self); //skeppet åker snabbt beroende på slumpen (startSpeed)

        

        transform.Translate(-3f * Time.deltaTime * (0.25f * Timer) , 0, 0, Space.Self);
        //Skeppet åker konstant framåt oavsett FPS. Jag skrev -3f istället för 3f eftersom jag vände skeppet åt fel håll och då ändrade jag bara vilken riktning.
        //Variablen Timer ligger där så skeppet åker snabbare ju längre tid som gått.

        if (Input.GetKey(KeyCode.A))
        {
            GreenColor = 1;
            BlueColor = 0;
            RedColor = 0; //sätter alla andra färger på 0 innan den får sin färg
            transform.Rotate(0f, 0f, rotationSpeed * slowRotation * Time.deltaTime * (0.1f * Timer)); //Denna roterar långsammare än D, alltså roterar den långsammare åt höger än vänster
            spaceShipRend.color = new Color(0f, GreenColor, 0f);                               //Timer är där så den roterar snabbare ju mer tid som gått
            spaceShipRend1.color = new Color(0f, GreenColor, 0f);
            spaceShipRend2.color = new Color(0f, GreenColor, 0f);
            //Skeppet svänger vänster när man trycker A genom att den roterar. Den blir också färgen grön pga variablen GreenColor. Den sätter alla andra färger på 0
        }
        if (Input.GetKey(KeyCode.D))
        {
            BlueColor = 1;
            GreenColor = 0;
            RedColor = 0; //sätter alla andra färger på 0 innan den får sin färg
            transform.Rotate(0f, 0f, -rotationSpeed * fastRotation * Time.deltaTime * (0.1f * Timer)); //Denna roterar snabbare än A, alltså roterar den snabbare åt höger än vänster
            spaceShipRend.color = new Color(0f, 0f, BlueColor);                                 //Timer är där så den roterar snabbare ju mer tid som gått
            spaceShipRend1.color = new Color(0f, 0f, BlueColor);
            spaceShipRend2.color = new Color(0f, 0f, BlueColor);
        }//Skeppet svänger höger när man trycker D genom att den roterar. Den blir också färgen Blå pga variablen BlueColor. Den sätter alla andra färger på 0      
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(+1.5f * Time.deltaTime, 0, 0, Space.Self);
            //Skeppet åker hälften så långsamt. Vanligtvis åker den -3f * Time.deltaTime, men när det läggs till +1.5f så blir det -3f + 1,5 f = -1.5f.
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BlueColor = Random.Range(0f, 1f);
            RedColor = Random.Range(0f, 1f);
            GreenColor = Random.Range(0f, 1f);
            spaceShipRend.color = new Color(RedColor, GreenColor, BlueColor);
            spaceShipRend1.color = new Color(RedColor, GreenColor, BlueColor);
            spaceShipRend2.color = new Color(RedColor, GreenColor, BlueColor);
            //Ger en randomvärde på varje Color-Variabel när man trycker Space
        }



        if (Time.fixedTime == Timer)
        {
            print("Timer: " + Timer);
            Timer = Timer + 1;
            //Räknar varje sekund. Time.fixedTime räknar varje gång det gått 1 sekund. Sedan printas antalet sekunder, 1 sekund högre än den förra.
        }
        if (transform.position.x > 10.5 || shipPosition.position.x < -10.5)
        {
            shipPosition.position = new Vector3(shipPosition.position.x * -1, shipPosition.position.y);
        }
        if (transform.position.y > 6.5 || shipPosition.position.y < -6.5)
        {
            shipPosition.position = new Vector3(shipPosition.position.x, shipPosition.position.y * -1); // när man går utanför kamerans perpektiv så warpar man till stället tvärt emot (* -1 inverterar)
        }
    }

}
