using RBot;

public class Script
{
    public ScriptInterface bot;

    public void ScriptMain(ScriptInterface Bot)
    {
        bot = Bot;
        Bot.Options.SafeTimings = true;
        Bot.Options.RestPackets = true;
        Bot.Options.ExitCombatBeforeQuest = true;

        Bot.Skills.StartTimer();
        Bot.Skills.StartSkills("skills/Generic.xml");

        ManaGolem();
    }

    public void ManaGolem()
    {
        bot.Bank.ToInventory("Voucher of Nulgath (non-mem)");
        bot.Bank.ToInventory("Voucher of Nulgath");
        bot.Bank.ToInventory("Gem of Nulgath");
        bot.Bank.ToInventory("Dark Crystal Shard");
        bot.Bank.ToInventory("Tainted Gem");
        bot.Bank.ToInventory("Totem of Nulgath");
        bot.Bank.ToInventory("Diamond of Nulgath");
        bot.Player.Join("elemental");

        while (!bot.ShouldExit())
        {
            bot.Quests.EnsureAccept(2566);

            bot.Player.HuntForItem("Mana Falcon", "Charged Mana Energy for Nulgath", 5, true);
            bot.Player.HuntForItem("Mana Golem", "Mana Energy for Nulgath", 1);

            bot.Quests.EnsureComplete(2566);

            bot.Player.Pickup("Unidentified 13", "Voucher of Nulgath (non-mem)", "Voucher of Nulgath", "Gem of Nulgath", "Dark Crystal Shard", "Tainted Gem", "Totem of Nulgath", "Unidentified 10", "Diamond of Nulgath");
        }
    }
}