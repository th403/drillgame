using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameCommonData
{
    public static WLProperty<float> bgmVolume;
    public static WLProperty<float> seVolume;

    public static void InitData()
    {
        //pretend
        bgmVolume = new WLProperty<float>();
        seVolume = new WLProperty<float>();

        //to do: set by data file
    }
}
