using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Create_Name : MonoBehaviour
{
    [SerializeField]
    GameObject instantiated_gameobject;
    public void OnMouseOver()
    {
        Debug.Log("Entering Mouse Over");
        //GameObject instantiated_gameobject = Instantiate(name_prefab);
        if(instantiated_gameobject != null)
        {
            instantiated_gameobject.transform.position = this.GetComponent<MeshCollider>().bounds.center;
            TMP_Text text = instantiated_gameobject.GetComponentInChildren<TMP_Text>();
            text.text = this.name;
        }

    }

    private void OnMouseExit()
    {
        instantiated_gameobject.transform.position = new Vector3(100, 100, 100);
    }
}
