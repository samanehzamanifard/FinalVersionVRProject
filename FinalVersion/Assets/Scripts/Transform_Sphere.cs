using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Transform_Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -9.0f){
		//gameObject.SetActive(false);
           Time.timeScale = 0;
	   }
    }

    void FixedUpdate(){
	   transform.position += Vector3.left * speed;
     }
}
