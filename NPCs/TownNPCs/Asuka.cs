using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevisMod.Content.Items.Potions;
using LevisMod.Content.Items.Weapons.Melee;
using LevisMod.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.NPCs.TownNPCs
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
            Main.npcFrameCount[NPC.type] = 21; // match with aseprite frames
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 600;
            NPCID.Sets.AttackType[NPC.type] = 2;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            AnimationType = NPCID.Dryad;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs) // spawn condition.
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemID.WoodenArrow)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Asuka",
                "Asuka Langley",
                "Asuka Langley Soryu"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Gift";
            button2 = "Talk";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            int x = Main.rand.Next(4);
            if (firstButton)
            {
                if (Main.player[Main.myPlayer].HeldItem.type == ItemID.Diamond ||
                    Main.player[Main.myPlayer].HeldItem.type == ItemID.GingerbreadCookie ||
                    Main.player[Main.myPlayer].HeldItem.type == ItemID.Banana ||
                    Main.player[Main.myPlayer].HeldItem.type == ModContent.ItemType<Cigarette>())
                {
                    HandleLovedGift();
                    int npcType = this.NPC.type;
                    RelationshipSystem.npcHearts[npcType] = RelationshipSystem.npcHearts.GetValueOrDefault(npcType, 0) + 2;
                    Main.NewText("She loved it!");
                }
                else
                {
                    HandleLovedGift();
                    int npcType = this.NPC.type;
                    RelationshipSystem.npcHearts[npcType] = RelationshipSystem.npcHearts.GetValueOrDefault(npcType, 0) + 1;
                    Main.NewText("Shes seen better.");
                }
            }
            else if (!firstButton)
            {
                Main.npcChatText = GetChat();
            }
            
        }

        public static void HandleLovedGift()
        {
            Player player = Main.LocalPlayer;
            Item heldItem = player.HeldItem;

            if(heldItem != null && !heldItem.IsAir && heldItem.stack > 0)
            {
                heldItem.stack--;
            }
        }

        public override void AddShops()
        {
            NPCShop shop = new(Type);
            shop.Add(ModContent.ItemType<ProgressiveKnife>());
            shop.Add(ItemID.Jetpack);
        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<Asuka>());
            int randChat = Main.rand.Next(4);
            var player = Main.LocalPlayer;
            int npctype = this.NPC.type;
            int hearts = RelationshipSystem.npcHearts.GetValueOrDefault(npctype, 0);
            if(hearts < 4)
            {
                switch (randChat)
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
            else if(hearts >= 4 && hearts < 8)
            {
                switch (randChat)
                {
                    case 0:
                        return "y'know, you're not so bad..";
                    case 1:
                        return "I feel like I've met you before";
                    case 2:
                        return "ughhh everyone around here is so boring, except for you..";
                    case 3:
                        return "I just know Im going to make it some day";
                    default:
                        return "I wonder what the world will look like after we're gone..";
                }
            }
            else if (hearts >= 8)
            {
                switch (randChat)
                {
                    case 0:
                        return "hey, you want to hang out later?";
                    case 1:
                        return "another day in paradise...";
                    case 2:
                        return "I really miss having someone to talk to.. maybe you could listen?";
                    case 3:
                        return "I wonder what my mom would say if she could see me now.";
                    default:
                        return "*she sings gently*";
                }
            }
            else
            {
                return "baka...";
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