using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,255,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    SpriteRenderer spriteRenderer;
     bool PackagePickedUp = false;
     Collider2D package = new Collider2D();
     Vector3[] PackagePositions = {
          new Vector3(15.6f, 1.8f, 0),
          new Vector3(20.4f, -15.9f, 0),
          new Vector3(18.1f, -42.6f, 0),
          new Vector3(-18.8f, -44.2f, 0),
          new Vector3(-27.1f, -33.5f, 0),
          new Vector3(-28.7f, -5f, 0),
          new Vector3(-51.5f, 3.9f, 0),
          new Vector3(-70.4f, -2f, 0),
          new Vector3(-68.5f, -38.6f, 0), 
     };

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   void OnCollisionEnter2D(Collision2D other) 
   {
        Debug.Log("CRASH!");
   }
    void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.tag == "Package")
        {
          Debug.Log("Package picked up.");
          spriteRenderer.color = hasPackageColor;
          package = other;
          other.gameObject.transform.position = new Vector3(9999f, 9999f, 0);
          PackagePickedUp = true;
        }
        else if(other.tag == "Customer" && PackagePickedUp)
        {
          Debug.Log("Package delivered.");
          PackagePickedUp = false;
          spriteRenderer.color = noPackageColor;
          package.gameObject.transform.position = PackagePositions[Random.Range(0, 9)];
        }
        else if(other.tag == "Customer" && !PackagePickedUp)
        {
          Debug.Log("Ouch!");
        }
   }
}
