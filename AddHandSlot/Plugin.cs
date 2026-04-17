using BepInEx;
using HarmonyLib;
using ModCore;
using ModCore.Data;

namespace AddHandSlot;

[BepInDependency("Pikachu.CSTI.ModCore", ModCoreVersion)]
[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
[ModNamespace(PluginName)]
public class Plugin : BaseUnityPlugin<Plugin>
{
    private const string PluginGuid = "Pikachu.AddHandSlot";
    public const string PluginName = "AddHandSlot";
    public const string PluginVersion = "3.2.0";

    private static readonly Harmony Harmony = new(PluginGuid);

    protected override void OnAwake()
    {
        Harmony.PatchAll();

        ConfigManager.Bind();

        PreloadData();
    }

    private static void PreloadData()
    {
        Loader.PreloadData<GameStat>("AddHandSlot:HandSlotNum", ResourcesJson.HandSlotNum);
        Loader.PreloadData<GameStat>("AddHandSlot:EncumbranceLimitNum", ResourcesJson.EncumbranceLimitNum);

        Loader.PreloadData<CharacterPerk>("AddHandSlot:Pk_AddHandSlot", ResourcesJson.Pk_AddHandSlot);
        Loader.PreloadData<CharacterPerk>("AddHandSlot:Pk_AddEncumbranceLimit", ResourcesJson.Pk_AddEncumbranceLimit);

        Loader.LoadCompleteEvent += PerkCtrl.ModifyAddHandSlotPerkNum;
        Loader.LoadCompleteEvent += PerkCtrl.ModifyAddEncumbranceLimitNum;
    }
}