using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevisMod.Content.Items.Ores;
using LevisMod.Content.Items.Weapons.Melee;
using LevisMod.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.Content.Items.Accessories
{

    public class AT_Field : ModItem
    {
        public bool isInvulnerable = false;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.value = Item.buyPrice(gold: 75);
            Item.rare = ItemRarityID.Lime;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<InvulnerabilityPlayer>().isInvulnerable = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "InvulnerabilityEffect", "Grants 3 seconds of invulnerability when hit."));
        }
    }

    
}
