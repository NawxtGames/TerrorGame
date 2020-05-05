// DoorDetectionLite.cs
// Created by Alexander Ameye
// Version 3.0.0

using UnityEngine;
using UnityEngine.UI;

[HelpURL("https://alexdoorsystem.github.io/liteversion/")]
public class DoorDetectionLite : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Doors button for android")]
    private GameObject DoorBtnUI;
    private bool isPressed = false;


    [Header("Raycast Settings")]
    [Tooltip("Raycast reach")]
    public float Reach = 4.0F;
    private bool InReach;
    [SerializeField]
    private string Character = "e";
    [SerializeField]
    private Color DebugRayColor;

    public void Slide(){

        go.GetComponent<DoorSlidingLite>().Slide();
    }
    GameObject go;
    public void IsPressed(){
        isPressed = true;
    }


    
     void Update(){
          Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0F));
          RaycastHit hit; 
          if (Physics.Raycast(ray, out hit, Reach)){
              if (hit.collider.tag == "Door" || hit.collider.tag == "Sliding"){
                  InReach = true;
                  DoorBtnUI.SetActive(true);
                  GameObject Door = hit.transform.gameObject;
                  if (Input.GetKeyDown(Character) || isPressed || Input.GetKeyDown(KeyCode.Joystick1Button0)){
                      isPressed = false;
                      if (hit.collider.tag == "Door"){

                                  StartCoroutine(hit.collider.GetComponent<DoorRotationLite>().Move());


                      }
                      else if (hit.collider.tag == "Sliding"){
                          go = hit.transform.gameObject;
                          StartCoroutine("Slide");
                      }
                  }
              }
              else{
                  InReach = false;
                  DoorBtnUI.SetActive(false);
              }
          }

          else{
              InReach = false;
          }
          Debug.DrawRay(ray.origin, ray.direction * Reach, DebugRayColor);
      }

   

    
}
