﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuysuccess : UIControl
{

    public GameObject panel;

    public void DisableBuysuccess()
    {
        Invoke("panelfalse", 1);
    }
    public void panelfalse()
    {
        transform.parent.GetComponent<Animator>().SetBool("open", false);
        panel.SetActive(false);
    }
}
