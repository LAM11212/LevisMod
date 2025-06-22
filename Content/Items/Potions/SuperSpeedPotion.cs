using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevisMod.Content.Items.Buffs;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.Content.Items.Potions
{
    public class SuperSpeedPotion : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 11;
            Item.height = 21;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.buffType = ModContent.BuffType<SuperSpeedBuff>();
            Item.buffTime = 5400;
        }
    }
}
