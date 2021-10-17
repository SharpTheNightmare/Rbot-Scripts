// Converted from M - Glacera Ice Token
// Author: SharpTheNightmare
// Description: daily mem glacera ice tokens bot

using RBot;

public class GlaceraIce
{
    public string OptionsStorage = "SharpTheNightmare M - Glacera Ice Token";
    public bool DontPreconfigure = true;

    public string map = "northstar-999999";

    public int questId;

    public void ScriptMain(ScriptInterface bot)
    {
        bot.Options.SafeTimings = true;
        bot.Options.RestPackets = true;
        bot.Options.SkipCutscenes = true;
        bot.Skills.StartTimer();
        bot.Skills.StartSkills("Skills/Generic.xml");

    Checks:
        if (bot.Player.IsMember)
            questId = 3965;
        else
            questId = 3966;

        if (!bot.Quests.IsAvailable(questId))
            goto End;

        if (bot.Quests.IsInProgress(questId))
            goto FrostInvader;

        if (bot.Inventory.Contains("Glacera Ice Token", 300))
            goto End;

        bot.Player.LoadBank();
        if (bot.Bank.Contains("Glacera Ice Token", 300))
            goto End;

        if (bot.Bank.Contains("Glacera Ice Token"))
        {
            bot.Bank.ToInventory("Glacera Ice Token");
        }

    JoinMap:
        bot.Player.Join(map, "Enter", "Spawn");
        bot.Quests.EnsureAccept(questId);

    FrostInvader:
        if (bot.Map.Name != map)
            goto JoinMap;

        bot.Player.HuntForItem("Frost Invader", "Dark Ice", 1, true);

        if (!bot.Quests.CanComplete(questId))
            goto FrostInvader;

        bot.Player.Jump("Blank", "Center");
        bot.Sleep(1000);
    Quest:
        bot.Quests.EnsureComplete(questId);
        bot.Player.Pickup("Glacera Ice Token");
    End:
        bot.Player.Pickup("Glacera Ice Token");
        if (bot.Quests.CanComplete(questId))
            goto Quest;

        if (bot.Quests.IsAvailable(questId))
            goto Checks;

        if (bot.Inventory.Contains("Glacera Ice Token"))
            bot.Inventory.ToBank("Glacera Ice Token");
        ScriptManager.StopScript();
    }
}