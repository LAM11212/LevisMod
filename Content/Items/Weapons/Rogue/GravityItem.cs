using LevisMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.Content.Items.Weapons.Rogue
{
    public class GravityItem : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Throwing;
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.shoot = ModContent.ProjectileType<Gravity>();
            Item.shootSpeed = 8;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item82;
            Item.rare = ItemRarityID.Purple;
            Item.autoReuse = false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 MousePos = Main.MouseWorld;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, MousePos.X, MousePos.Y);
            return false;
        }
    }
}
