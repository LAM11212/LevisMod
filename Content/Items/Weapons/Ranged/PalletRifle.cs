using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ID;


namespace LevisMod.Content.Items.Weapons.Ranged
{
    internal class PalletRifle : ModItem
    {

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 20;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item11;
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 25;
            Item.knockBack = 3f;
            Item.noMelee = true;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 7f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 2f);
        }
    }
}
