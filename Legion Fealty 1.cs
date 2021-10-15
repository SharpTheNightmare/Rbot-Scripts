using System;
using RBot;
using RBot.Strategy;
using Newtonsoft.Json;

public class LegionFealtyOne
{
    public void ScriptMain(ScriptInterface bot)
    {
        bot.Options.SafeTimings = true;
        bot.Options.RestPackets = true;
        bot.Options.ExitCombatBeforeQuest = true;
        
        bot.Skills.StartSkills("Skills/Generic.xml");
        
        bot.Strategy = JsonConvert.DeserializeObject<StrategyDatabase>("{\"$type\":\"RBot.Strategy.StrategyDatabase, RBot\",\"Navigators\":{\"$type\":\"System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[RBot.Strategy.INavigator, RBot]], mscorlib\"},\"ItemStrategies\":{\"$type\":\"System.Collections.Generic.List`1[[RBot.Strategy.ItemStrategy, RBot]], mscorlib\",\"$values\":[{\"$type\":\"RBot.Strategy.QuestStrategy, RBot\",\"Preference\":5,\"QuestID\":6897,\"Item\":\"Revenant\'s Spellscroll\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"revenant\",\"Monsters\":\"Ultra Aeacus\",\"Preference\":10,\"Item\":\"Aeacus Empowered\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"revenant\",\"Monsters\":\"Forgotten Soul\",\"Preference\":10,\"Item\":\"Tethered Soul\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"shadowrealmpast\",\"Monsters\":\"Pure Shadowscythe|Shadow Guardian|Shadow Warrior\",\"Preference\":10,\"Item\":\"Darkened Essence\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"necrodungeon\",\"Monsters\":\"5 Headed Dracolich\",\"Preference\":10,\"Item\":\"Dracolich Contract\",\"TempItem\":false}]},\"DropAggregate\":{\"$type\":\"System.Collections.Generic.List`1[[System.String, mscorlib]], mscorlib\",\"$values\":[]}}", new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
        
        bot.Strategy.AggregateDrops("Revenant\'s Spellscroll", false);
        bot.Strategy.Obtain("Revenant\'s Spellscroll", 20);
    }
}
