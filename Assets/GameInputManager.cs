using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class GameInputManager
{

    static Dictionary<string, KeyCode> keyMapping;
    static string[] keyMaps = new string[8]
    {
        "Attack1",
        "Previous1",
        "Next1",
        "Combine1",
        "Attack2",
        "Previous2",
        "Next2",
        "Combine2"
    };
    static KeyCode[] defaults = new KeyCode[8]
    {
        KeyCode.Space,
        KeyCode.K,
        KeyCode.L,
        KeyCode.V,
        KeyCode.Minus,
        KeyCode.Q,
        KeyCode.E,
        KeyCode.RightShift
    };

    static GameInputManager()
    {
        InitializeDictionary();
    }

    private static void InitializeDictionary()
    {
        keyMapping = new Dictionary<string, KeyCode>();
        for (int i = 0; i < keyMaps.Length; ++i)
        {
            keyMapping.Add(keyMaps[i], defaults[i]);
        }
    }

    public static void SetKeyMap(string keyMap, KeyCode key)
    {
        if (!keyMapping.ContainsKey(keyMap))
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        keyMapping[keyMap] = key;
    }

    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keyMapping[keyMap]);
    }

    public static bool GetKeyUp(string keyMap)
    {
        return Input.GetKeyUp(keyMapping[keyMap]);
    }
}