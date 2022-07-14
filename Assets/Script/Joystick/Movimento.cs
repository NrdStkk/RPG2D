using UnityEngine;

public class Movimento : MonoBehaviour
{

    /// <summary>
    /// Step #1
    /// We need a simple reference of joystick in the script
    /// that we need add it.
    /// </summary>
    public bl_Joystick Joystick;
    public bl_Joystick Joystick2;
    //==================ANDROID
    /*

    public float Speed = 2.8f;
    public float Speed2 = 30f;


     */
    public bool isKeyPressed;


    //==================PC
    public float Speed = 200f;



    void FixedUpdate()
    {
        //==================ANDROID
        /*

            float v = Joystick.Vertical;
            float h2 = Joystick2.Horizontal;
            */



        //==================PC

        int p = 30;

        float v = Joystick.Vertical * p;
        float h = Joystick2.Horizontal * p;


        Vector3 translate = (new Vector3(h, v, 0) * Time.deltaTime) * Speed;
        transform.Translate(translate);


    }

}
 