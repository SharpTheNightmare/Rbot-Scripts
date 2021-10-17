using System;
using RBot;
using RBot.Strategy;
using Newtonsoft.Json;

public class Script
{
    public void ScriptMain(ScriptInterface bot)
    {
        bot.Options.SafeTimings = true;
        bot.Options.RestPackets = true;
        bot.Options.ExitCombatBeforeQuest = true;
        bot.Options.InfiniteRange = true;
		
        bot.Skills.StartSkills("Skills/Generic.xml");
        
        bot.Strategy = JsonConvert.DeserializeObject<StrategyDatabase>("{\"$type\":\"RBot.Strategy.StrategyDatabase, RBot\",\"Navigators\":{\"$type\":\"System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[RBot.Strategy.INavigator, RBot]], mscorlib\"},\"ItemStrategies\":{\"$type\":\"System.Collections.Generic.List`1[[RBot.Strategy.ItemStrategy, RBot]], mscorlib\",\"$values\":[{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"icestormarena\",\"Monsters\":\"Arctic Wolf|Ice Elemental|Skeletal Ice Mage\",\"Preference\":10,\"Item\":\"Ice Needle\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"snowmore\",\"Monsters\":\"Jon S\'Nooooooo\",\"Preference\":10,\"Item\":\"Northern Crown\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.QuestStrategy, RBot\",\"Preference\":5,\"QuestID\":7279,\"Item\":\"Ice Diamond\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.QuestStrategy, RBot\",\"Preference\":5,\"QuestID\":7920,\"Item\":\"Ice-Ninth\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.QuestStrategy, RBot\",\"Preference\":5,\"QuestID\":7921,\"Item\":\"Frost SpiritReaver\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.QuestStrategy, RBot\",\"Preference\":5,\"QuestID\":7921,\"Item\":\"Frost SpiritReaver\'s Blade\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.QuestStrategy, RBot\",\"Preference\":5,\"QuestID\":7921,\"Item\":\"Glaceran Attunement\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"cryowar\",\"Monsters\":\"Super-Charged Karok\",\"Preference\":10,\"Item\":\"Glacial Crystal\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"frozenlair\",\"Monsters\":\"Frozen Legionnaire\",\"Preference\":10,\"Item\":\"Ice Spike\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"frozenlair\",\"Monsters\":\"Frozen Legionnaire\",\"Preference\":10,\"Item\":\"Ice Splinter\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"frozenlair\",\"Monsters\":\"Legion Lich Lord\",\"Preference\":10,\"Item\":\"Sapphire Orb\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"kingcoal\",\"Monsters\":\"Snow Golem\",\"Preference\":10,\"Item\":\"Frozen Coal\",\"TempItem\":true}]},\"DropAggregate\":{\"$type\":\"System.Collections.Generic.List`1[[System.String, mscorlib]], mscorlib\",\"$values\":[]}}", new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
        
        bot.Strategy.AggregateDrops("Ice-Ninth", false);
        bot.Strategy.AggregateDrops("Glaceran Attunement", false);
        bot.Strategy.Obtain("Ice-Ninth", 9);
        bot.Strategy.Obtain("Glaceran Attunement", 15);
    }
}
