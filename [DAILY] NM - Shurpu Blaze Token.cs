// Converted from M - Shurpu Blaze Token
// Author: SharpTheNightmare/purple
// Description: daily mem sharpu blaze tokens bot

using RBot;

public class NoMemSharpuBlaze
{
    public string OptionsStorage = "SharpTheNightmare M - Shurpu Blaze Token";
    public bool DontPreconfigure = true;

    public int questId = 2209;

    public void ScriptMain(ScriptInterface bot)
    {
        bot.Options.SafeTimings = true;
        bot.Options.RestPackets = true;
        bot.Options.SkipCutscenes = true;
    Check:
        if (bot.Inventory.Contains("Shurpu Blaze Token", 300))
        {
            goto End;
        }
        if (bot.Bank.Contains("Shurpu Blaze Token", 300))
        {
            goto End;
        }
        if (bot.Bank.Contains("Shurpu Blaze Token"))
        {
            bot.Bank.ToInventory("Shurpu Blaze Token");
        }
        bot.Player.Join("xancave-999999", "r11", "Left");
        bot.Quests.EnsureAccept(questId);
    RingGuardian:
        bot.Player.Kill("*");
        if (!bot.Quests.CanComplete(questId))
        {
            goto RingGuardian;
        }
        bot.Sleep(1000);
    Quest:
        bot.Quests.EnsureComplete(questId);
        bot.Player.Pickup("Shurpu Blaze Token");
    End:
        bot.Player.Pickup("Shurpu Blaze Token");
        if (!bot.Quests.CanComplete(questId))
        {
            goto Quest;
        }
        if (bot.Inventory.Contains("Shurpu Blaze Token"))
        {
            bot.Inventory.ToBank("Shurpu Blaze Token");
        }
        ScriptManager.StopScript();
    }
}