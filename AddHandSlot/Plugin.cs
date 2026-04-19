using BepInEx;
using HarmonyLib;
using ModCore;
using ModCore.Data;

namespace AddHandSlot;

[BepInDependency("Pikachu.CSFF.ModCore", ModCoreVersion)]
[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
[ModNamespace(PluginName)]
public class Plugin : BaseUnityPlugin<Plugin>
{
    private const string PluginGuid = "Pikachu.CSFF.CardSizeReduce";
    public const string PluginName = "CardSizeReduce";
    public const string PluginVersion = "3.3.0";

    private static readonly Harmony Harmony = new(PluginGuid);

    protected override void OnAwake()
    {
        Harmony.PatchAll();

        ConfigManager.Bind();

        Loader.LoadCompleteEvent += PerkCtrl.ModifyAddHandSlotPerkNum;
        Loader.LoadCompleteEvent += PerkCtrl.ModifyAddEncumbranceLimitNum;
    }
}