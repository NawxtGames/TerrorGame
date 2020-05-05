using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectObject: MonoBehaviour
{
    [SerializeField]
    private float Reach = 4.0F;
    [SerializeField]
    private string Character = "e";
    [SerializeField]
    private bool isPressedActionBttn = false;
    [SerializeField]
    private GameObject actionBttn;


    private void Start() {

        if(actionBttn==null) {
            actionBttn=GameObject.Find("ActionBttn");
        }
    }

    // Update is called once per frame
    void Update() {
        if(Application.platform==RuntimePlatform.Android)

            actionBttn.active=false;

        // Set origin of ray to 'center of screen' and direction of ray to 'cameraview'
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F,0.5F,0F));

        RaycastHit hit; // Variable reading information about the collider hit

        // Cast ray from center of the screen towards where the player is looking
        if(Physics.Raycast(ray,out hit,Reach)) {

            IInteract action = (IInteract)hit.collider.GetComponent<IInteract>();
            if(action!=null) {
                if(Application.platform==RuntimePlatform.Android)

                    actionBttn.active=true;

                if(Input.GetKeyDown(Character)||isPressedActionBttn) {
                    action.Execute(hit);
                }
            }  
        }
        if(Application.platform==RuntimePlatform.Android)

            isPressedActionBttn=false;

    }

    public void Execute() {
        isPressedActionBttn=true;
    }
}



