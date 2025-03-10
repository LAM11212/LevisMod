using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Transactions;
using LevisMod.Content.Items.Materials;
// to fix the armor you need to create a sprite sheet titled Eva_01_Helmet_Head.png, Eva_01_Breastplate_Body, Eva_01_Leggings_Legs, and make them sprite sheets of the walking animation, check calamity for more details.
namespace LevisMod.Content.Items.Armor.EVA_01_Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class Eva_01_Helmet : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(gold: 10000);
            Item.defense = 15;
        }

        /*
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            //return body.type == ModContent.ItemType<enter breastplate here>() && legs.type == ModContent.ItemType<enter leggings here>();
        }
        */

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
        /* this method will be used to set an armor buff when the player has the entire set, must make the entire set first, your own localized value for the set.
        public override void UpdateArmorSet(Player player)
        {
            
        }
        */

        public override void UpdateEquip(Player player)
        {
            player.GetDamage<RangedDamageClass>() += 0.1f;
            player.GetCritChance<RangedDamageClass>() += 5f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<MechanicalComponent>(5).
                AddTile(TileID.Anvils).Register();
        }
    }
}
