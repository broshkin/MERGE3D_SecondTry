using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Fruits : MonoBehaviour
{
    public static GameObject fruit;
    public GameObject[] prefabs;
    public Vector3 startPos;
    public Quaternion startRot;
    public TrajectoryRenderer shit;
    private Vector3 speed;
    public float z_change;
    public static float y_change;
    public GameObject soundThrow;

    public Score scoreManager;

    public static bool gameOver = false;
    public GameObject nextFruit;
    public Image nextFruitIcon;
    public Sprite[] icons;

    public Button left;
    public Button right;
    public Button pusk;
    public Button up;
    public Button down;

    private string deviceType;
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(-0.15f, -0.2f, 0.6f);
        startRot = Quaternion.Euler(270, 0, 0);
        nextFruit = randomFruit();

        deviceType = YandexGame.EnvironmentData.deviceType;

        if (deviceType == "desktop")
        {
            left.gameObject.SetActive(false);
            right.gameObject.SetActive(false);
            pusk.gameObject.SetActive(false);
            up.gameObject.SetActive(false);
            down.gameObject.SetActive(false);
        }
        else
        {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            pusk.gameObject.SetActive(true);
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);
        }
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

    public void Pusk()
    {
        scoreManager.FinishCombo();
        Instantiate(soundThrow);
        var rb = fruit.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(speed, ForceMode.VelocityChange);
        fruit.transform.parent = null;
        StartCoroutine(NewFruit());
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
                rb.AddForce(speed, ForceMode.VelocityChange);
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
            var a = Instantiate(nextFruit, gameObject.transform);
            a.transform.localPosition = startPos;
            a.transform.localRotation = startRot;
            a.GetComponent<Rigidbody>().useGravity = false;
            nextFruit = randomFruit();
        }    
    }
    
    public void CreateFruit()
    {
        StartCoroutine(NewFruit());
    }

    GameObject randomFruit()
    {
        var a = Random.Range(1, 101);
        if (a <= 70)
        {
            nextFruitIcon.sprite = icons[0];
            return prefabs[0];
        }
        else if (a <= 90)
        {
            nextFruitIcon.sprite = icons[1];
            return prefabs[1];
        }
        else
        {
            nextFruitIcon.sprite = icons[2];
            return prefabs[2];
        }
    }


}
