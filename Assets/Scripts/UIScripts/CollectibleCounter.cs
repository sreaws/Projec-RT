using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollectibleCounter : MonoBehaviour
{

    [SerializeField] private CharacterController2D controller;
    public Text counterText;
    public float counter;

    public void Update()
    {
        counter = controller.GetScore();
        //Debug.Log(counter);
        counterText.text = counter.ToString();
    }
}
