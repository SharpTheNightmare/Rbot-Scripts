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

		YamiFarm(bot);
	}

	public void YamiFarm(ScriptInterface bot)
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