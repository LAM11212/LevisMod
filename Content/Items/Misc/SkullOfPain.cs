using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.Content.Items.Misc
{
    public class SkullOfPain : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Green;
            Item.useStyle = ItemUseStyleID.Swing;
        }

        public override bool? UseItem(Player player)
        {
            for(int i = 0; i < 100; i++)
            {
                float randomDirX = Main.rand.NextFloat(player.position.X - 300, player.position.X + 300);
                float randomDirY = Main.rand.NextFloat(player.position.Y - 400, player.position.Y - 100);
                NPC.NewNPC(null, (int)randomDirX, (int)randomDirY, NPCID.SkeletronHead);
            }
            CombatText.NewText(player.Hitbox, Microsoft.Xna.Framework.Color.DarkRed, "YOU FOOL");
            return true;
        }
    }
}
