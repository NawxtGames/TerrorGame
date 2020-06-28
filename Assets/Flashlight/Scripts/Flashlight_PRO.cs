using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class Flashlight_PRO: MonoBehaviour
{
    [SerializeField()] GameObject Lights; // all light effects and spotlight
    [SerializeField()] AudioSource switch_sound; // audio of the switcher
    [SerializeField()] ParticleSystem dust_particles; // dust particles
    [SerializeField] float battery = 100.0f;
    [SerializeField] float batteryDischarge = 3;
    [SerializeField] float batteryCharge = 2;
    [SerializeField] bool hasBattery = false;
    [SerializeField]
    private Light spotlight;[SerializeField]
    private GameObject LightBttn;
    private Material ambient_light_material;
    private Color ambient_mat_color;
    private bool is_enabled = true;
    private bool isPressed = false;







    // Use this for initialization
    void Start() {

        // cache components
     /*   ambient_light_material=Lights.transform.Find("ambient").GetComponent<Renderer>().material;
        ambient_mat_color=ambient_light_material.GetColor("_TintColor");
      */  if(Application.platform==RuntimePlatform.Android)

            LightBttn.SetActive(true);
    }


    public void IsPressed() {
        isPressed=true;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)||isPressed||Input.GetKeyDown(KeyCode.Joystick1Button4)) {
           

            Switch();
            isPressed=false;
        }
        if(hasBattery) {
            if(is_enabled) {
                battery-=batteryDischarge*Time.deltaTime;
            } else {
                battery+=batteryCharge*Time.deltaTime;
                if(battery>=100) {
                    battery=100;
                }
            }
            if(battery<=0&&is_enabled) {
                Switch();
            }
        }

    }

    /// <summary>
    /// changes the intensivity of lights from 0 to 100.
    /// call this from other scripts.
    /// </summary>
    public void Change_Intensivity(float percentage) {
        percentage=Mathf.Clamp(percentage,0,100);


        spotlight.intensity=(8*percentage)/100;

        ambient_light_material.SetColor("_TintColor",new Color(ambient_mat_color.r,ambient_mat_color.g,ambient_mat_color.b,percentage/2000));
    }




    /// <summary>
    /// switch current state  ON / OFF.
    /// call this from other scripts.
    /// </summary>
    public void Switch() {

        is_enabled = !is_enabled;

        Lights.SetActive(is_enabled);

        if(switch_sound!=null)
            switch_sound.Play();
    }





    /// <summary>
    /// enables the particles.
    /// </summary>
    public void Enable_Particles(bool value) {
        if(dust_particles!=null) {
            if(value) {
                dust_particles.gameObject.SetActive(true);
                dust_particles.Play();
            } else {
                dust_particles.Stop();
                dust_particles.gameObject.SetActive(false);
            }
        }
    }


}
