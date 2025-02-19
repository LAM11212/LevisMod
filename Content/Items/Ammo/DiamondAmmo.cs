using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.GameContent.Creative;
using LevisMod.Content.Projectiles;
using Terraria.ModLoader;

namespace LevisMod.Content.Items.Ammo
{
    internal class DiamondAmmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 1.25f;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<DiamondAmmoProjectile>();
        }
    }
}
