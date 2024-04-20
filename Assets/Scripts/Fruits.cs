using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public static GameObject fruit;
    public GameObject prefab;
    public Vector3 startPos;
    public Quaternion startRot;
    public TrajectoryRenderer shit;
    private Vector3 speed;
    public float z_change;
    public float y_change;
    public GameObject soundThrow;

    public Score scoreManager;

    public static bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(-0.15f, -0.2f, 0.6f);
        startRot = Quaternion.Euler(270, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.childCount > 0)
        {
            if (fruit != gameObject.transform.GetChild(0).gameObject)
            {
                fruit = gameObject.transform.GetChild(0).gameObject;
                fruit.GetComponent<Rigidbody>().useGravity = false;
            }
            float verticalInput = Input.GetAxis("Vertical");

            y_change += -verticalInput / 2;

            if (y_change > 50)
            {
                y_change = 50;
            }
            if (y_change < 0)
            {
                y_change = 0;
            }
            speed = fruit.transform.GetChild(0).forward * 3 + Vector3.up / 5 + transform.right / 6.66f;
      
        }
        else
        {
            shit.lineRendererComponent.positionCount = 0;
        }
    }
    public void Update()
    {
        if (gameObject.transform.childCount > 0)
        {
            if (fruit != gameObject.transform.GetChild(0).gameObject)
            {
                fruit = gameObject.transform.GetChild(0).gameObject;
                fruit.GetComponent<Rigidbody>().useGravity = false;
            }
            shit.ShowTrajectory(fruit.transform.GetChild(0).position, speed);
            fruit.transform.GetChild(0).localRotation = Quaternion.Euler(y_change + fruit.transform.GetChild(0).localRotation.x, fruit.transform.GetChild(0).localRotation.y, fruit.transform.GetChild(0).localRotation.z);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                scoreManager.FinishCombo();
                Instantiate(soundThrow);
                var rb = fruit.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.AddForce(speed, ForceMode.Impulse);
                fruit.transform.parent = null;
                StartCoroutine(NewFruit());
            }
        }
        else
        {
            shit.lineRendererComponent.positionCount = 0;
        }
    }

    IEnumerator NewFruit()
    {
        yield return new WaitForSeconds(0.5f);
        if (!gameOver)
        {
            var a = Instantiate(prefab, gameObject.transform);
            a.transform.localPosition = startPos;
            a.transform.localRotation = startRot;
            a.GetComponent<Rigidbody>().useGravity = false;
        }    
    }


}
