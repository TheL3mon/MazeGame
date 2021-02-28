using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playModeSwitch : MonoBehaviour
{
    Rigidbody2D camBody;
    float camHorizontal;
    float camVertical;
    float camSpeed = 60f;

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    Vector3 targetLocation;


    public bool isPlayMode = false;
    GameObject globalCanvas;

    void Start()
    {
        Cursor.visible = false;
        camBody = GameObject.Find("Main Camera").GetComponent<Rigidbody2D>();
        globalCanvas = GameObject.Find("WorldCanvas");
    }

    void Update()
    {
        if(Input.GetKeyDown("joystick button 0")){
            if(isPlayMode==false){
                isPlayMode = true;                
                GameObject newPlayer = GameObject.Instantiate(Resources.Load("char"), new Vector3(5f,5f,0), Quaternion.identity) as GameObject;
                newPlayer.tag = "Player";
            }
            else{
                isPlayMode = false;
                GameObject.Find("Main Camera").transform.position = new Vector3(0,0,-10f);
                GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 45f;
                Destroy(GameObject.FindGameObjectWithTag("Player"));
            }
        }

        if(Input.GetKeyDown("joystick button 1")){
            SceneManager.LoadScene(0);
        }

        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }

        camHorizontal = Input.GetAxis("HorizontalTurn");
        camVertical = Input.GetAxis("VerticalTurn");
    }

    void FixedUpdate() {
        if(isPlayMode==true){
            targetLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
            targetLocation.z = -10;
            GameObject.Find("Main Camera").transform.position = Vector3.SmoothDamp(GameObject.Find("Main Camera").transform.position, targetLocation, ref velocity, dampTime);
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 6.5f;
        }
        else{
            camBody.velocity = new Vector2(camHorizontal * camSpeed, camVertical * camSpeed);

            if(Input.GetAxis("RightTrigger") != 0 && GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize >= 10){
                GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize -= 1f;
            }
            else if(Input.GetAxis("LeftTrigger") != 0){
                GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize += 1f;
            }
        }
    }
}
