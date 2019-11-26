using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BallMechanics : MonoBehaviour
{
    public static float y0 = 16.00f;
    public static float y1 = 11.0f;
    public static float y2 = 6.0f;

    public PathType pathSystem = PathType.CatmullRom;
    public Vector3[] pathVal1 = { new Vector3(20.0f, y0, 0.0f), new Vector3(-20.0f, y0, 0.0f) };//new Vector3[2];
    public Vector3[] pathVal2 = { new Vector3(20.0f, y1, 0.0f), new Vector3(-20.0f, y1, 0.0f) };//new Vector3[2];
    public Vector3[] pathVal3 = { new Vector3(20.0f, y2, 0.0f), new Vector3(-20.0f, y2, 0.0f) };//new Vector3[2];

    public int duration = 5;

    public int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.transform.position.y == y0)
        {
            gameObject.transform.DOPath(pathVal1, duration, pathSystem).SetId("path1");
        }
        else if (gameObject.transform.position.y == y1)
        {
            gameObject.transform.DOPath(pathVal2, duration, pathSystem).SetId("path2");
        }
        else if (gameObject.transform.position.y == y2)
        {
            gameObject.transform.DOPath(pathVal3, duration, pathSystem).SetId("path3");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 1) { count = 1; }
        if (count >= 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MeshRenderer>().material.color == gameObject.GetComponent<MeshRenderer>().material.color)
        {
                count++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MeshRenderer>().material.color == gameObject.GetComponent<MeshRenderer>().material.color)
        {
            if (other.gameObject.GetComponent<BallMechanics>().count > count)
                count = other.gameObject.GetComponent<BallMechanics>().count;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MeshRenderer>().material.color == gameObject.GetComponent<MeshRenderer>().material.color)
        {
            int otherCount = other.gameObject.GetComponent<BallMechanics>().count;
            if (otherCount > 1)
                count -= otherCount;
            else
                count--;
        }
            
    }

}
