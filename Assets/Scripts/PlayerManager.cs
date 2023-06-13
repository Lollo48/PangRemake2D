using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerMouvement PlayerMouvement;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        PlayerMouvement = GetComponent<PlayerMouvement>();

    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        PlayerMouvement.HandleAllMouvement();

    }




}
