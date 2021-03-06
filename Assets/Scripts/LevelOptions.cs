﻿using System.Collections;
using System.Collections.Generic;

public static class LevelOptions
{
    private static string gametype, level,gameguide;
    private static int noplayers;
    public static string GameType
    {
        get
        {
            return gametype;
        }
        set
        {
            gametype = value;
        }
    }
    public static string Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
    public static int NoPlayers
    {
        get
        {
            return noplayers;
        }
        set
        {
            noplayers = value;
        }
    }
    public static string GameGuide
    {
        get
        {
            return gameguide;
        }
        set
        {
            gameguide = value;
        }
    }
}
