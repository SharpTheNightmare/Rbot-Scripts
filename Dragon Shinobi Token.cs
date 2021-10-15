using System;
using RBot;
using RBot.Strategy;
using Newtonsoft.Json;

public class DragonShinobi
{
    public void ScriptMain(ScriptInterface bot)
    {
        bot.Options.SafeTimings = true;
        bot.Options.RestPackets = true;
        bot.Options.ExitCombatBeforeQuest = true;
        bot.Options.InfiniteRange = true;

        bot.Skills.StartSkills("Skills/Generic.xml");

        bot.Strategy = JsonConvert.DeserializeObject<StrategyDatabase>("{\"$type\":\"RBot.Strategy.StrategyDatabase, RBot\",\"Navigators\":{\"$type\":\"System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[RBot.Strategy.INavigator, RBot]], mscorlib\"},\"ItemStrategies\":{\"$type\":\"System.Collections.Generic.List`1[[RBot.Strategy.ItemStrategy, RBot]], mscorlib\",\"$values\":[{\"$type\":\"RBot.Strategy.QuestStrategy, RBot\",\"Preference\":5,\"QuestID\":7924,\"Item\":\"Dragon Shinobi Token\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"shadowfortress\",\"Monsters\":\"2nd Head of Orochi|3rd Head of Orochi|4th Head of Orochi|5th Head of Orochi\",\"Preference\":10,\"Item\":\"Perfect Orochi Scales\",\"TempItem\":false}]},\"DropAggregate\":{\"$type\":\"System.Collections.Generic.List`1[[System.String, mscorlib]], mscorlib\",\"$values\":[]}}", new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });

        bot.Strategy.AggregateDrops("Dragon Shinobi Token", false);
        bot.Strategy.Obtain("Dragon Shinobi Token", 300);
    }
}
