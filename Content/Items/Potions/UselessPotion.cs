using LevisMod.Content.Items.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.Content.Items.Potions
{
    public class UselessPotion : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.buffType = 0;
            Item.buffTime = 0;
        }

        public override bool? UseItem(Player player)
        {
            Microsoft.Xna.Framework.Vector2 randomDir = new Microsoft.Xna.Framework.Vector2(Main.rand.NextFloat(-200f, 200f), Main.rand.NextFloat(-200f, -400f));
            player.velocity = randomDir;

            CombatText.NewText(player.Hitbox, Microsoft.Xna.Framework.Color.Purple, "Wheeee!");
            return true;
        }

        public override void AddRecipes()
        {
            Recipe uselessPotionRecipe = CreateRecipe();
            uselessPotionRecipe.AddIngredient(ItemID.DirtBlock, 25);
        }
    }
}
