using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevisMod.Content.Projectiles;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.Content.Items.Weapons.Magic
{
    internal class RiftBlade : ModItem // fix bug where clicking during cooldown resets cooldown timer.
    {
        private bool onCoolDown;
        private int baseMana = 2;
        private int manaCap = 125;
        private int count = 0;
        private int cooldownStartTime = 0;
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 20;
            Item.mana = baseMana;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item6;
            Item.autoReuse = false;
        }

        public override bool CanUseItem(Player player)
        {
            if(onCoolDown)
            {
                if(Main.GameUpdateCount - cooldownStartTime < 1200)
                {
                    return false;
                }
                else
                {
                    onCoolDown = false;
                    count = 0;
                    Item.mana = baseMana;
                }
            }
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if(!CanUseItem(player))
            {
                return false;
            }

            Vector2 MousePos = Main.MouseWorld;

            if(!Collision.SolidCollision(MousePos, player.width, player.height))
            {
                count++;

                if (count < 10)
                {
                    Item.mana = Math.Min(Item.mana * 2, manaCap);
                }
                else
                {
                    onCoolDown = true;
                    cooldownStartTime = (int)Main.GameUpdateCount;
                }
                for(int i = 0; i < 70; i++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.TeleportationPotion);
                }

                player.position = MousePos;

                for(int i = 0; i < 70; i++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.TeleportationPotion);
                }
            }

            return true;
        }
    }
}
