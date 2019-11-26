using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Changing_Color : MonoBehaviour
{
    bool timer = true;
    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
	   StartCoroutine (updateColor());
    }

    IEnumerator updateColor(){
		while(timer){
			yield return new WaitForSeconds(5);
			rend.material.color = Color.red;
			yield return new WaitForSeconds(5);
			rend.material.color = Color.blue;
			yield return new WaitForSeconds(5);
			rend.material.color = Color.green;
		}
	}
}
