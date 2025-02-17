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
    internal class ProgressiveKnife : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 300;
            Item.crit = 8;

            Item.value = Item.buyPrice(platinum: 10, gold: 700);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;

            Item.shoot = ModContent.ProjectileType<ProgressiveKnifeProjectile>();
            Item.shootSpeed = 10;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.RapidHealing, 50);
        }
    }
}
