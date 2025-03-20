using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevisMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.Content.Items.Weapons.Melee
{
    public class BlackCleaver : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 50;
            Item.crit = 75;

            Item.value = Item.buyPrice(platinum: 10, gold: 700);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.TryGetGlobalNPC<NPCs.BleedGlobalNPC>(out var bleedNPC))
            {
                bleedNPC.applyBleed(target, 300);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            //recipe.AddIngredient<phage>
            //recipe.AddIngredient<Caulfields warhammer>
            //recipe.AddIngredient<Ruby Crystal>
        }
    }
}
