using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_At_Mouse : MonoBehaviour
{

    void Update()
    {

        if(Input.GetAxis("Mouse X") < 0)
            {
            this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y + 0.001f, this.transform.rotation.z, this.transform.rotation.w);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y - 0.001f, this.transform.rotation.z, this.transform.rotation.w);
        }

        if (Input.GetAxis("Mouse Y") < 0)
        {
            this.transform.rotation = new Quaternion(this.transform.rotation.x - 0.001f, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            this.transform.rotation = new Quaternion(this.transform.rotation.x + 0.001f, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
        }
    }
}
