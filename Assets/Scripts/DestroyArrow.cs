using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {
       Debug.Log(other.name.ToString());
       Destroy(gameObject);
   }
}
