 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Generate_ChangeColor : MonoBehaviour
{
    public GameObject Prefab_Sphere;
    public int numBalls = 30;
    private  GameObject[,] ballArray;
    public Color col;
    public int waitTime = 5;

    float y1 = 16.00f;
    float y2 = 11.0f;
    float y3 = 6.0f;
    
    public int duration = 4;
    // Start is called before the first frame update
    void Start()
    {
        ballArray = new GameObject[3,numBalls];
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < numBalls; j++){
                Prefab_Sphere = Instantiate(Prefab_Sphere, new Vector3((19.1f + j-1f),(16.0f - (5 * i)),0.0f), Quaternion.identity) as GameObject;
            int rand = Random.Range (0,3);
				if(rand == 1){
					col = Color.red;
				}
				else if(rand == 0){
					col = Color.blue;
				}
				else if(rand == 2){
					col = Color.green;
				}
				else{
					col = Color.black;
				}
				Prefab_Sphere.GetComponent<MeshRenderer>().material.color = col;
                Prefab_Sphere.transform.SetParent(gameObject.transform);
                ballArray[i,j] = Prefab_Sphere;
            }
		}
    }

    void Update()
    {
        
    }

    IEnumerator PathControl()
    {
        yield return new WaitForSeconds(waitTime);
        int rand = Random.Range(0, 3);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < numBalls; j++)
            {
                if (i != rand)
                    ballArray[i, j].transform.DOPause();
                else
                    ballArray[i,j].transform.DOPlay();
            }
        }
    }
}
