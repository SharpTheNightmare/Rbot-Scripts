// Converted from M - Shurpu Blaze Token
// Author: SharpTheNightmare
// Description: daily mem sharpu blaze tokens bot

using RBot;

public class MemSharpuBlaze
{
    public string OptionsStorage = "SharpTheNightmare M - Shurpu Blaze Token";
    public bool DontPreconfigure = true;

    public int questId;

    public void ScriptMain(ScriptInterface bot)
    {
        bot.Options.SafeTimings = true;
        bot.Options.RestPackets = true;
        bot.Options.SkipCutscenes = true;
        bot.Skills.StartTimer();
        bot.Skills.StartSkills("Skills/Generic.xml");
        if (bot.Player.IsMember)
            questId = 2210;
        else
            questId = 2209;

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
            bot.Player.LoadBank();
            bot.Bank.ToInventory("Shurpu Blaze Token");
        }
        bot.Player.Join("xancave-999999", "r11", "Left");
        bot.Quests.EnsureAccept(questId);
    RingGuardian:
        bot.Player.Hunt("Shurpu Ring Guardian");
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
        if (bot.Quests.CanComplete(questId))
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