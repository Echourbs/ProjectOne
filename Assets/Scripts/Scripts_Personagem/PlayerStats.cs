﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTE
{
public class PlayerStats : MonoBehaviour
{
    [Header("Main Player Stats")]
    public string PlayerName;
    public int PlayerXP = 0;
    public int PlayerLevel = 1;
    public int PlayerHP = 50;//baseline = 50, +5 each level

    [Header("Player Attributes")]
    public List<PlayerAttributes> Attributes = new List<PlayerAttributes>();


    [Header("Player Skills Enabled")]
    public List<Skills>PlayerSkills = new List<Skills>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}
