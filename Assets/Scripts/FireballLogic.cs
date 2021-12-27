using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLogic : MonoBehaviour
{
    FireballSpawn fireballSpawn;
    public Rigidbody2D fireRBD;
    public GameObject fireball;
    public GameObject zilla;
    public Vector2 shrinkTarget;
    public Vector2 currentSize;
    public float shrinkSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentSize = this.gameObject.transform.localScale;
        shrinkTarget = new Vector2(0.01f, 0.01f);
        selfDestruct();
        
    }

    
    // Update is called once per frame
    void Update()
    {
        currentSize = this.gameObject.transform.localScale;
    }

    void selfDestruct()
    {
        if(gameObject.tag != "Countered")
        {
            Destroy(gameObject, 10);
        }
        
       
    }
   
    public void OnMouseDown()
    {
        fireRBD.velocity = new Vector2(0, 0);
        gameObject.tag = "Countered";
        gravityList();
        selfDestruct();
        
         //Destroy(gameObject);

    }

     public void gravityList()
    {
     
        {
             
            while(currentSize.x > shrinkTarget.x && currentSize.y > shrinkTarget.y)
            {
                currentSize.x--;
                currentSize.y--;
                
                Debug.Log("boop");

            }
            return;
            //gravityPull(listedFire);
           // listedFire.GetComponent<Rigidbody>().(transform.forward * 50);
           
        }
        
    }
    
    
   
    
    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
