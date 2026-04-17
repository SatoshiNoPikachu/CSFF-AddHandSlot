using HarmonyLib;
using UnityEngine;

namespace AddHandSlot.Patcher;

[HarmonyPatch(typeof(InGameCardBase))]
internal static class InGameCardBasePatch
{
    [HarmonyPostfix, HarmonyPatch("LateUpdate")]
    public static void LateUpdate_Postfix(InGameCardBase __instance)
    {
        if (__instance is null) return;
        if (__instance.transform.localScale.x < 1.25f) return;

        if (__instance.Destroyed || !__instance.CurrentParentObject) return;
        if (__instance.IsPulsing || __instance.IsTimeAnimated || __instance.IsPerformingAction) return;
        if (__instance.transform.parent != __instance.CurrentParentObject) return;
        if (__instance.IsHovered && __instance.ImpossibleAction == null &&
            __instance.PossibleAction == null && __instance.HasAction) return;

        __instance.transform.localScale = Vector3.MoveTowards(__instance.transform.localScale, __instance.InitialScale,
            50 * Time.deltaTime);
    }
}