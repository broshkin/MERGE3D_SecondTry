using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileManager : MonoBehaviour
{
    public Button left;
    public bool _left = false;
    public Button right;
    public bool _right = false;
    public Button up;
    public bool _up = false;
    public Button down;
    public bool _down = false;
    public GameObject camera;
    public GameObject govno;

    public void Start()
    {
        camera = GameObject.Find("1").transform.GetChild(0).gameObject;
        govno = GameObject.Find("1");
    }

    private void FixedUpdate()
    {
        if (_down)
        {
            Fruits.y_change += 0.5f;
        }
        if (_up)
        {
            Fruits.y_change -= 0.5f;
        }
        if (_left)
        {
            govno.GetComponent<RotateCamera>().RotLeft();
        }
        if (_right)
        {
            govno.GetComponent<RotateCamera>().RotRight();
        }
    }

    public void Pusk()
    {
        camera.GetComponent<Fruits>().Pusk();
    }
    public void Left(bool _)
    {
        _left = _;
    }
    public void Right(bool _)
    {
        _right = _;
    }
    public void Up(bool _)
    {
        _up = _;
    }
    public void Down(bool _)
    {
        _down = _;
    }


}
