using HarmonyLib;
using Verse;

[StaticConstructorOnStartup]
public static class ForcePerfectMemory_Startup
{
    static ForcePerfectMemory_Startup()
    {
        var harmony = new Harmony("axilotl.forceperfectmemory");
        harmony.PatchAll();
        Log.Message("ForcePerfectMemory Harmony patches applied.");
    }
}