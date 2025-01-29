using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Verse; // Required for ModsConfig

[HarmonyPatch(typeof(RimWorld.SkillRecord))] // Target the SkillRecord class
[HarmonyPatch("Interval")] // Target the Interval method
public static class Patch_SkillRecord_Interval
{
    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            if (instruction.opcode == OpCodes.Call && instruction.operand is MethodInfo method &&
                method == AccessTools.PropertyGetter(typeof(ModsConfig), nameof(ModsConfig.AnomalyActive)))
            {
                // Replace call to ModsConfig.AnomalyActive with constant "true"
                yield return new CodeInstruction(OpCodes.Ldc_I4_1);
                continue;
            }
            yield return instruction;
        }
    }
}
