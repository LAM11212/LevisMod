﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace LevisMod.Players
{
    public class RelationshipSystem : ModSystem
    {
        public static Dictionary<int, int> npcHearts = new();

        public override void SaveWorldData(TagCompound tag)
        {
            var list = new List<TagCompound>();

            foreach(var kvp in npcHearts)
            {
                list.Add(new TagCompound
                {
                    ["npcType"] = kvp.Key,
                    ["heartValue"] = kvp.Value
                });
            }
                tag["npcHearts"] = list;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            npcHearts = new Dictionary<int, int>();

            if (tag.TryGet("npcHearts", out List<TagCompound> list))
            {
                foreach (var entry in list)
                {
                    int npcType = entry.GetInt("npcType");
                    int heartValue = entry.GetInt("heartValue");
                    npcHearts[npcType] = heartValue;
                }
            }
        }
    }
}
