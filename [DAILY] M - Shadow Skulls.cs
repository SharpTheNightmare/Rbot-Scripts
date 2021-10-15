// Converted from M - Shadow Skull
// Author: SharpTheNightmare
// Description: Daily Shadow Skull bot

using RBot;

public class ShadowSkulls
{
    public string OptionsStorage = "SharpTheNightmare M - Shadow Skull";
    public bool DontPreconfigure = true;

    public void ScriptMain(ScriptInterface bot)
    {
        bot.Options.SafeTimings = true;
        bot.Options.RestPackets = true;
        bot.Options.ExitCombatBeforeQuest = true;
        bot.Options.InfiniteRange = true;
        bot.Options.SkipCutscenes = true;
        bot.Skills.StartTimer();
        bot.Skills.StartSkills("Skills/Generic.xml");

    Checks:
        if (!bot.Player.IsMember)
            goto End;
        if (!bot.Quests.IsAvailable(492))
        {
            goto End;
        }
        if (bot.Inventory.Contains("Shadow Skull", 30))
        {
            goto End;
        }
        if (bot.Bank.Contains("Shadow Skull", 30))
        {
            goto End;
        }
        if (bot.Bank.Contains("Shadow Skull"))
        {
            bot.Player.LoadBank();
            bot.Bank.ToInventory("Shadow Skull");
        }
        if (bot.Quests.IsInProgress(492))
        {
            goto Main;
        }
    Main:
        if (bot.Player.DropExists("Shadow Skull"))
        {
            bot.Player.Pickup("Shadow Skull");
        }
        if (bot.Quests.IsAvailable(492))
        {
            if (!bot.Quests.IsInProgress(492))
            {
                bot.Quests.EnsureAccept(492);
            }
            if (bot.Map.Name != "bludrut4")
            {
                bot.Player.Join("bludrut4-999999", "r14", "Left");
            }
            bot.Player.HuntForItem("Shadow Serpent", "Shadow Scales", 5, true);
        }
    Map:
        if (bot.Quests.CanComplete(492))
        {
            goto Quest;
        }
        if (!bot.Inventory.ContainsTempItem("Shadow Scales", 5))
        {
            goto Main;
        }
        if (bot.Quests.IsAvailable(492))
        {
            goto Main;
        }
    Quest:
        bot.Quests.EnsureComplete(492);
        if (bot.Player.DropExists("Shadow Skull"))
        {
            bot.Player.Pickup("Shadow Skull");
        }
    End:
        if (bot.Player.DropExists("Shadow Skull"))
        {
            bot.Player.Pickup("Shadow Skull");
        }
        ScriptManager.StopScript();
    }
}