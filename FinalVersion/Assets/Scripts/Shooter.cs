using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shooter : MonoBehaviour
{
    public float shotForce = 1000f;
    public float moveSpeed = 10f;

    void Update()
    {
        float h = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) * Time.deltaTime * moveSpeed;
        float v = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) * moveSpeed;
        
    }
}