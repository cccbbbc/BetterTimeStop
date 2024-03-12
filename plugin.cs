using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace SuperDash
{
    [BepInPlugin("com.Cole.BetterTimeStop", "BetterTimeStop", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin BetterTimeStop loaded!");

            Harmony harmony = new Harmony("com.Cole.BetterTimeStop");


            MethodInfo original = AccessTools.Method(typeof(TimeStop), "Awake");
            MethodInfo patch = AccessTools.Method(typeof(myPatches), "Awake_BetterTimeStop_Plug");
            harmony.Patch(original, new HarmonyMethod(patch));
        }

        public class myPatches
        {
            public static void Awake_BetterTimeStop_Plug(ref float ___duration)
            {
                ___duration = 30f;

            }
        }
    }
}
