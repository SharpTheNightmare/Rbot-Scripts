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
        
        bot.Skills.StartSkills("Skills/Generic.xml");
        
        bot.Strategy = JsonConvert.DeserializeObject<StrategyDatabase>("{\"$type\":\"RBot.Strategy.StrategyDatabase, RBot\",\"Navigators\":{\"$type\":\"System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[RBot.Strategy.INavigator, RBot]], mscorlib\"},\"ItemStrategies\":{\"$type\":\"System.Collections.Generic.List`1[[RBot.Strategy.ItemStrategy, RBot]], mscorlib\",\"$values\":[{\"$type\":\"RBot.Strategy.QuestStrategy, RBot\",\"Preference\":5,\"QuestID\":4432,\"Item\":\"Void Aura\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.QuestStrategy, RBot\",\"Preference\":5,\"QuestID\":4432,\"Item\":\"Void Aura\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.QuestStrategy, RBot\",\"Preference\":5,\"QuestID\":4432,\"Item\":\"Void Aura\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"timespace\",\"Monsters\":\"Astral Ephemerite\",\"Preference\":10,\"Item\":\"Astral Ephemerite Essence\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"greenguardwest\",\"Monsters\":\"Black Knight\",\"Preference\":10,\"Item\":\"Black Knight Essence\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"mudluk\",\"Monsters\":\"Tiger Leech\",\"Preference\":10,\"Item\":\"Tiger Leech Essence\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"aqlesson\",\"Monsters\":\"Carnax\",\"Preference\":10,\"Item\":\"Carnax Essence\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"necrocavern\",\"Monsters\":\"Chaos Vordred\",\"Preference\":10,\"Item\":\"Chaos Vordred Essence\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"hachiko\",\"Monsters\":\"Dai Tengu\",\"Preference\":10,\"Item\":\"Dai Tengu Essence\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"timevoid\",\"Monsters\":\"Unending Avatar\",\"Preference\":10,\"Item\":\"Unending Avatar Essence\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"dragonchallenge\",\"Monsters\":\"Void Dragon\",\"Preference\":10,\"Item\":\"Void Dragon Essence\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"maul\",\"Monsters\":\"Creature Creation\",\"Preference\":10,\"Item\":\"Creature Creation Essence\",\"TempItem\":false},{\"$type\":\"RBot.Strategy.DropStrategy, RBot\",\"Map\":\"citadel\",\"Monsters\":\"Belrot the Fiend\",\"Preference\":10,\"Item\":\"Belrot the Fiend Essence\",\"TempItem\":false}]},\"DropAggregate\":{\"$type\":\"System.Collections.Generic.List`1[[System.String, mscorlib]], mscorlib\",\"$values\":[]}}", new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
        
        bot.Strategy.AggregateDrops("Void Aura", false);
        bot.Strategy.Obtain("Void Aura", 7500);
    }
}
