using System;
using System.Collections.Generic;
using UnityEngine;
namespace MapEditor
{
    public static class Logger
    {
        public static void Log(string Module, string description)
        {
            Debug.Log("Module name: " + Module + "\n Status: " + description);
        }
    }
}