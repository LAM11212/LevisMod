using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevisMod.Content.Items.Buffs;
using LevisMod.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.Content.Items.Potions
{
    public class Cigarette : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.useStyle = ItemUseStyleID.DrinkLong;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 20;
            Item.consumable = true;
            Item.rare = ItemRarityID.LightRed;
            Item.buffType = ModContent.BuffType<CigaretteBuff>();
            Item.buffTime = 5400;
        }

        public override bool ConsumeItem(Player player)
        {
            for(int i = 0; i < 20; i++)
            {
                Dust.NewDust(player.position, player.width, player.height, DustID.Smoke, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe cigRecipe = CreateRecipe();
            cigRecipe.AddIngredient(ItemID.AshBlock, 10);
            cigRecipe.AddIngredient(ItemID.Fireblossom, 5);
            cigRecipe.AddIngredient(ModContent.ItemType<Tobacco>(), 5);
            cigRecipe.Register();
        }
    }
}
