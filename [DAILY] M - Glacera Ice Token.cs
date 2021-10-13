// Converted from M - Glacera Ice Token
// Author: SharpTheNightmare/purple
// Description: daily mem glacera ice tokens bot

using RBot;

public class MemGlaceraIce
{
    public string OptionsStorage = "SharpTheNightmare M - Glacera Ice Token";
    public bool DontPreconfigure = true;

    public int questId = 3965;

    public void ScriptMain(ScriptInterface bot)
    {
        bot.Options.SafeTimings = true;
        bot.Options.RestPackets = true;
        bot.Options.SkipCutscenes = true;
        bot.Skills.StartTimer();
        bot.Skills.StartSkills("skills/Generic.xml");

    Check:
        if (bot.Inventory.Contains("Glacera Ice Token", 300))
        {
            goto End;
        }
        if (bot.Bank.Contains("Glacera Ice Token", 300))
        {
            goto End;
        }
        if (bot.Bank.Contains("Glacera Ice Token"))
        {
            bot.Bank.ToInventory("Glacera Ice Token");
        }
        bot.Player.Join("northstar-999999", "Enter", "Spawn");
        bot.Quests.EnsureAccept(questId);
    FrostInvader:
        bot.Player.HuntForItem("Frost Invader", "Dark Ice", 1, true);
        if (!bot.Quests.CanComplete(questId))
        {
            goto FrostInvader;
        }
        bot.Player.Jump("Blank", "Center");
        bot.Sleep(1000);
    Quest:
        bot.Quests.EnsureComplete(questId);
        bot.Player.Pickup("Glacera Ice Token");
    End:
        bot.Player.Pickup("Glacera Ice Token");
        if (!bot.Quests.CanComplete(questId))
        {
            goto Quest;
        }
        if (bot.Inventory.Contains("Glacera Ice Token"))
        {
            bot.Inventory.ToBank("Glacera Ice Token");
        }
        ScriptManager.StopScript();
    }
}