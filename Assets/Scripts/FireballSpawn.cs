using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawn : MonoBehaviour
{
    public float fireballTime;
    public bool isFireballTime;
    public float chargingFire;
    public GameObject fireball;
    public Camera MainCamera;
    public int numberOfObjects = 20;
    FireballLogic fireballLogic;
    FireballLogic currentFireball;
    public Transform camPos;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(fireCharging());
         
        
        
    }

    // Update is called once per frame
    void Update()
    {

        
           
        
    }
    
   public IEnumerator fireCharging()
    {
        Debug.Log("charge");
        while(true)
        {
            yield return new WaitForSeconds(5);
           spawnFireball();
        }
        
        
        
    }
    
   
    //spawnFireball spawns fireballs randomly 
    //in a circle five times larger than the orthographic 
    //size of the camera/ by the max number of spawns points a fireball can take
    //and then given a velocity along the y axis
    void spawnFireball()
    {   
        float radius = MainCamera.orthographicSize*5;
        float angle = Random.Range(1, 20) * Mathf.PI * 2/numberOfObjects;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        print(angle);
        Vector3 pos = transform.position + new Vector3(x, y, 0);
        print(angle);
        float angleDegrees = angle*Mathf.Rad2Deg;
        float angleRange = Random.Range(260, 280);
        Quaternion rot = Quaternion.Euler(0, 0, angleDegrees - angleRange);
      var currentFireball = ((GameObject)Instantiate(fireball, pos, rot)).GetComponent<FireballLogic>();
      
      currentFireball.GetComponent<Rigidbody2D>().velocity = currentFireball.transform.up * 5;
      
       Debug.DrawLine(Vector3.zero, new Vector3(0,100,0), Color.red);
      // currentFireball.launchFireball();
       
       //currentFireball.GetComponent<FireballLogic>().launchFireball();
    
        //fireballLogic.launchFireball();
        isFireballTime = false;
      

    }
}
