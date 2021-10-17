using RBot;

public class DarkSpiritOrb
{
    //Make sure to Turn OFF "Reaccept Quests Upon Turnin" and Turn ON "Auto Untarget Dead Targets" + "Auto Untarget Self" from Advanced Settings in AQW.
    //Edit your Map Number and required Quantity of Emblems of Nulgath to be farmed here. Make sure PrivateRooms is false to join your desired room.
    public string mapNumber = "6969";

    //▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇

    public string[] requiredItems = {
            "Dark Spirit Orb",
            "DoomCoin"
    };

    public void ScriptMain(ScriptInterface bot)
    {
        if (bot.Player.Cell != "Wait") bot.Player.Jump("Wait", "Spawn");

        //▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇

        //Edit all your settings here. If you don't know what the settings do, you may leave them at default values.//

        bot.Options.LagKiller = true;
        bot.Options.SafeTimings = true;
        bot.Options.RestPackets = true;
        bot.Options.AutoRelogin = true;
        bot.Options.InfiniteRange = true;
        bot.Options.PrivateRooms = false;
        bot.Options.ExitCombatBeforeQuest = true;

        //Edit your skill order here. Skill No. in RBot = Skill No. in AQW - 1.//

        bot.RegisterHandler(1, b =>
        {
            if (bot.Player.InCombat) bot.Player.UseSkill(4);
            if (bot.Player.InCombat) bot.Player.UseSkill(3);
            if (bot.Player.InCombat) bot.Player.UseSkill(2);
            if (bot.Player.InCombat) bot.Player.UseSkill(1);
        });
        bot.RegisterHandler(4, b =>
        {
            foreach (string item in requiredItems)
            {
                if (bot.Player.DropExists(item)) bot.Player.Pickup(item);
            }
            bot.Player.RejectExcept(requiredItems);
        });

        //▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇

        //You don't care about this//

        bot.Events.PlayerDeath += b =>
        {
            bot.Sleep(7500);
            ScriptManager.RestartScript();
        };
        bot.Events.PlayerAFK += b =>
        {
            ScriptManager.RestartScript();
        };

        bot.Player.LoadBank();
        foreach (string item in requiredItems)
        {
            if (bot.Bank.Contains(item)) bot.Bank.ToInventory(item);
        }

        //▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇

        while (!bot.Inventory.Contains("Dark Spirit Orbs", 10500))
        {
            while (!bot.Inventory.Contains("DoomCoin", 100)) generalFarm(bot, "maul", "r2", "Left", 2089, "*");
            questComplete(bot, 2089);
        }

        //▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇
    }

    //▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇

    public void questComplete(ScriptInterface bot, int questID, int itemID = -1)
    {
    maintainCompleteLoop:
        bot.Options.AggroMonsters = false;
        bot.Quests.EnsureAccept(questID);
        bot.Quests.EnsureComplete(questID, itemID, false, 3);
        if (bot.Quests.IsInProgress(questID)) bot.Player.Logout();
        bot.Quests.EnsureAccept(questID);
        if (bot.Quests.CanComplete(questID)) goto maintainCompleteLoop;
    }

    public void generalFarm(ScriptInterface bot, string mapName, string cellName, string padName, int questID, string monsterName)
    {
        {
            if (bot.Map.Name != mapName)
            {
                bot.Options.AggroMonsters = false;
                if (bot.Player.Cell != "Wait") bot.Player.Jump("wait", "Spawn");
                bot.Player.Join($"{mapName}-{mapNumber}", cellName, padName);
            }
            if (bot.Player.Cell != cellName) bot.Player.Jump(cellName, padName);
            bot.Options.AggroMonsters = true;
            bot.Quests.EnsureAccept(questID);
            bot.Player.Attack(monsterName);
        }
    }
}

//▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇