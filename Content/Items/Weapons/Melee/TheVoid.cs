using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LevisMod.Content.Projectiles;

namespace LevisMod.Content.Items.Weapons.Melee
{
    internal class TheVoid : ModItem // pretty much just an item for me to clear bosses and test certain features, not really intended for player use.
    {

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 100000;
            Item.crit = 65;

            Item.value = Item.buyPrice(gold: 100000, silver: 50);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Bleeding, 1000);
        }

        public override void AddRecipes() // i might make this a permanant item idk yet.
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TerraBlade, 5);
            recipe.AddIngredient(ItemID.NightsEdge, 5);
            recipe.AddIngredient(ItemID.TrueNightsEdge, 5);
            recipe.AddIngredient(ItemID.TrueExcalibur, 5);
            recipe.AddIngredient(ItemID.Excalibur, 5);
            recipe.AddIngredient(ItemID.DirtBlock, 999);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 5);
            recipe.AddIngredient(ItemID.Gel, 1);
        }
    }
}
