using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_At_Camera : MonoBehaviour
{
    void Update()
    {
        this.transform.LookAt(GameObject.Find("Main Camera").transform.position);
    }
}
