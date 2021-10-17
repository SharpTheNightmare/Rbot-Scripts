using RBot;

public class Yami
{
	public ScriptInterface bot;

	public void ScriptMain(ScriptInterface Bot)
	{
		bot = Bot;
		Bot.Options.SafeTimings = true;
		Bot.Options.RestPackets = true;
		Bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.InfiniteRange = true;

		Bot.Skills.StartTimer();
		Bot.Skills.StartSkills("Skills/Generic.xml");

		YamiFarm();
	}

	public void YamiFarm()
	{
		bot.Player.Join("darkally");

		while (!bot.Inventory.Contains("Yami", 10))
		{
			bot.Quests.EnsureAccept(7409);

			bot.Player.HuntForItem("Dark Makai|Underworld Golem|Shadow|Legion Defector|Creeping Shadow", "Dark Wisp", 444);

			bot.Quests.EnsureComplete(7409);

			bot.Wait.ForDrop("Yami");

			bot.Player.Pickup("Yami");
		}
	}
}