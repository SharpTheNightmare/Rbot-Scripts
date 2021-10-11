using RBot;

public class Script
{

	public void ScriptMain(ScriptInterface bot)
	{
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;

		bot.Skills.StartTimer();
		bot.Skills.StartSkills("skills/Generic.xml");

		ManaGolem(bot);
	}

	public void ManaGolem(ScriptInterface bot)
	{
		bot.Inventory.BankAllCoinItems();

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