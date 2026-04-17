using BepInEx;
using HarmonyLib;
using ModCore;
using ModCore.Data;
using ModCore.Services;

namespace AddHandSlot;

[BepInDependency("Pikachu.CSFF.ModCore", ModCoreVersion)]
[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
[ModNamespace(PluginName)]
public class Plugin : BaseUnityPlugin<Plugin>
{
    private const string PluginGuid = "Pikachu.CSFF.CardSizeReduce";
    public const string PluginName = "CardSizeReduce";
    public const string PluginVersion = "3.2.0";

    private static readonly Harmony Harmony = new(PluginGuid);

    protected override void OnAwake()
    {
        Harmony.PatchAll();

        ConfigManager.Bind();
        
        LocalizationService.RegisterPath(PluginPath, "AddHandSlot_");

        PreloadData();
    }

    private static void PreloadData()
    {
        Loader.PreloadData<GameStat>("AddHandSlot_HandSlotNum", ResourcesJson.HandSlotNum);
        Loader.PreloadData<GameStat>("AddHandSlot_EncumbranceLimitNum", ResourcesJson.EncumbranceLimitNum);

        Loader.PreloadData<CharacterPerk>("AddHandSlot_Pk_AddHandSlot", ResourcesJson.Pk_AddHandSlot);
        Loader.PreloadData<CharacterPerk>("AddHandSlot_Pk_AddEncumbranceLimit", ResourcesJson.Pk_AddEncumbranceLimit);

        Loader.LoadCompleteEvent += PerkCtrl.ModifyAddHandSlotPerkNum;
        Loader.LoadCompleteEvent += PerkCtrl.ModifyAddEncumbranceLimitNum;
        Loader.LoadCompleteEvent += PerkAddToTab;
    }

    private static void PerkAddToTab()
    {
        var tab = UniqueIDScriptable.GetFromID<PerkTabGroup>("9be1b5be8f64df444b73828b99159b0c");
        tab.ContainedPerks.Add(Database.GetData<CharacterPerk>("AddHandSlot_Pk_AddHandSlot"));
        tab.ContainedPerks.Add(Database.GetData<CharacterPerk>("AddHandSlot_Pk_AddEncumbranceLimit"));
    }
}