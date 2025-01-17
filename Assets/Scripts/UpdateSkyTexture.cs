﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UpdateSkyTexture : MonoBehaviour
{
    
    public Material part1, part2a, part2b, part3;
    public Color color1, color2a, color2b, color3;
    public float skyFlashTime = 2f;

    private static UpdateSkyTexture me = null;

    public static void Part1()
    {
        me.SetMaterial( me.part1 );
        me.FlashColor( me.color1 );
    }

    public static void Part2a()
    {
        me.SetMaterial( me.part2a );
        me.FlashColor( me.color2a );
    }

    public static void Part2b()
    {
        me.SetMaterial( me.part2b );
        // don't flash because lightning will be flashing
    }

    public static void Part3()
    {
        me.SetMaterial( me.part3 );
        // don't flash because lightning will be flashing
    }

    void Start()
    {
        me = this;
        SetMaterial( part1 );
    }

    void Update()
    {
        if( Input.GetKeyDown( "c" ) )
        {
            Part2a();
        }
        if( Input.GetKeyDown( "v" ) )
        {
            Part2b();
        }
        if( Input.GetKeyDown( "b" ) )
        {
            Part3();
        }
        if( Input.GetKeyDown( "n" ) )
        {
            Part1();
        }
    }

    void SetMaterial( Material m )
    {
        // set sky color
        RenderSettings.skybox = m;
    }

    void FlashColor( Color c )
    {
        // do a flash of other color
        SteamVR_Fade.Start( c, 0 );

        // back to clear
        SteamVR_Fade.Start( Color.clear, skyFlashTime );
    }
}
