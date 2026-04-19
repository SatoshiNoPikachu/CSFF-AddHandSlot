using AddHandSlot.Line;
using ModCore.Games;
using ModCore.Games.Extensions;
using UnityEngine;

namespace AddHandSlot.Stat;

public class StatCtrl(string uid)
{
    public const string UidHandSlotNum = "AddHandSlot:HandSlotNum";

    public const string UidEncumbranceLimitNum = "AddHandSlot:EncumbranceLimitNum";

    static StatCtrl()
    {
        Game.DestroyEvent += () => _forced = false;
    }

    private static bool _forced;

    public static void OnStatValueChange(InGameStat stat, float change)
    {
        if (change is 0) return;

        var model = stat?.StatModel;
        if (model is null) return;

        var curValue = (int)stat.CurrentValue(Game.Gm);

        switch (model.UniqueID)
        {
            case UidHandSlotNum:
                LineCtrl.ModifyHandSlotNum(curValue);
                break;
            case UidEncumbranceLimitNum:
                if (_forced) ModifyEncumbranceLimit(change);
                break;
        }
    }

    internal static void Forced() => _forced = true;

    /// <summary>
    /// 修改负重上限
    /// </summary>
    public static void ForceModifyEncumbranceLimit(bool flag = false)
    {
        var stat = new StatCtrl(UidEncumbranceLimitNum).InGame;
        if (stat is null) return;

        if (ConfigManager.IsEnable("Config", "ForceModifyEncumbrance"))
        {
            var config = ConfigManager.Get<int>("Config", "AddEncumbranceNum");
            if (config is null) return;

            var value = config.Value;
            var change = value - (_forced ? stat.CurrentBaseValue : 0);
            if (change is not 0)
            {
                stat.CurrentBaseValue = value;
                ModifyEncumbranceLimit(change);
            }

            ConfigManager.Get<bool>("Config", "ForceModifyEncumbrance")!.Value = false;
        }
        else if (flag) ModifyEncumbranceLimit(stat.CurrentBaseValue);
    }

    /// <summary>
    /// 修改负重上限
    /// </summary>
    /// <param name="num">上限值</param>
    private static void ModifyEncumbranceLimit(float num)
    {
        var gm = Game.Gm;
        gm.StartCoroutine(gm.ChangeStatMinMaxValues(gm.InGamePlayerWeight, new Vector2(0, num)));
    }

    public GameStat Stat { get; } = UniqueIDScriptable.GetFromID<GameStat>(uid);

    public InGameStat InGame => GameManager.Instance is not null && Stat is not null ? Stat.InGame : null;
}