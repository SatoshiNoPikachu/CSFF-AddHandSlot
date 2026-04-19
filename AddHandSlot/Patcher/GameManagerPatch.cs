using AddHandSlot.Line;
using AddHandSlot.ScrollView;
using AddHandSlot.Stat;
using HarmonyLib;

namespace AddHandSlot.Patcher;

[HarmonyPatch(typeof(GameManager))]
public static class GameManagerPatch
{
    [HarmonyPostfix, HarmonyPatch("Awake")]
    public static void Awake_Postfix(GameManager __instance)
    {
        LineCtrl.ForceAddHandSlot();
        LineCtrl.ModifyHandSlotNum();

        StatCtrl.ForceModifyEncumbranceLimit(true);
        StatCtrl.Forced();

        InspectionPopupScroll.Create();
    }

    [HarmonyPostfix, HarmonyPatch("ChangeStatValue")]
    public static IEnumerator ChangeStatValue_Postfix(IEnumerator result, InGameStat _Stat, float _Value)
    {
        while (result.MoveNext()) yield return result.Current;

        StatCtrl.OnStatValueChange(_Stat, _Value);
    }
}