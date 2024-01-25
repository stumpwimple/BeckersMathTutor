using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallScript : MonoBehaviour
{
    bool attachedToMouse = false;
    public string sign;
    public GameObject explosion;

    void Start()
    {

       sign = GameObject.Find("SignText").GetComponent<Text>().text; // This grabs the sign of the equation from the Canvas/SignText GameObject


    }

    void OnMouseOver()
    {
        //print(gameObject.name);

        if (Input.GetKeyDown(KeyCode.Mouse0) && attachedToMouse == false)
        {
            attachedToMouse = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && attachedToMouse == true)
        {
            attachedToMouse = false;
        }
    }
    void Update()
    {
        
        if (attachedToMouse)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; //Trying to steady the ball after bounces *BUG
            gameObject.GetComponent<Rigidbody>().rotation = Quaternion.identity; //Trying to steady the ball after bounces *BUG
            var v3 = Input.mousePosition;
            v3.z = 17f;
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(v3);

        }


    }
    void OnCollisionEnter(Collision col)
    {
        bool isBallOppositeColor = false;

        if (col.gameObject.tag != gameObject.tag && col.gameObject.tag != "Terrain") { isBallOppositeColor = true; }
        //print("Collided with: " + col);
        if (sign == "-"&& isBallOppositeColor&&col.gameObject!=null)
        {
            GameObject sprite = Instantiate(explosion, gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
        if (sign == "+" && isBallOppositeColor)
        {
            print("This is what happens if its a plus problem" + col.gameObject.tag);
        }
    }
}