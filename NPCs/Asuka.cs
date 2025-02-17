using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevisMod.Content.Items.Weapons.Melee;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.NPCs
{
    public class Asuka : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defense = 40;
            NPC.lifeMax = 300;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCHit1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[NPC.type] = 24;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 600;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            AnimationType = 22;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs) // spawn condition.
        {
            for(var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach(Item item in player.inventory)
                {
                    if (item.type == ItemID.WoodenArrow)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override List<String> SetNPCNameList()
        {
            return new List<String>()
            {
                "Asuka",
                "Asuka-Langley",
                "Asuka-Langley_soryu"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Talk";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            int x = Main.rand.Next(4);
            if (firstButton)
            {
                shopName = "Asukas Shop";
            } 
            else if(!firstButton && x == 0)
            {
                Main.npcChatText = "I don't want to die. I don't want to die. I don't want to die. I don't want to die. ";
            } else if(!firstButton && x == 1)
            {
                Main.npcChatText = "*you hear a faint humming tune* \"fly me to the moon, and let me play among the stars, let me see what spring is like on jupiter and ma- HEY WHAT ARE YOU DOING?\"";
            } else if(!firstButton && x == 2)
            {
                Main.npcChatText = "shall I get you a stool?";
            } else if(!firstButton && x == 3)
            {
                Main.npcChatText = "I hope theres more to my life than this.";
            }
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            if(shopName == "Asukas Shop")
            {
                int nextSlot = 0;
                items[nextSlot] = new Item(ModContent.ItemType<ProgressiveKnife>())
                {
                    shopCustomPrice = 1000
                };
                nextSlot++;

                items[nextSlot] = new Item(ItemID.IronPickaxe);
                nextSlot++;

                items[nextSlot] = new Item(ItemID.Jetpack);
                nextSlot++;
            }
        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<Asuka>());
            switch (Main.rand.Next(4))
            {
                case 0:
                    return "BAKA SHINJI";
                case 1:
                    return "Misato likes to act all high and mighty as if Im not way stronger and prettier too..";
                case 2:
                    return "ughhh this place is so boring, say you wanna get outta here with me?";
                case 3:
                    return "Eva-02 kicks ass, and so does it's pilot.";
                default:
                    return "what do you want?";
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 30;
            knockback = 5f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 8;
            randExtraCooldown = 10;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.WoodenArrowFriendly;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.CloudinaBottle);
        }
    }
}