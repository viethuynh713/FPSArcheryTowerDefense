using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBase : MonoBehaviour
{
    public GameObject lookAtBase;

    // Start is called before the first frame update
    void Start()
    {
        lookAtBase = GameObject.FindGameObjectWithTag("Castle");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(lookAtBase.transform);
    }
}
