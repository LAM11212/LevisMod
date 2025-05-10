using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.Content.Items.Misc
{
    public class PortableHome : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.useStyle = ItemUseStyleID.Swing;
        }

        public override bool? UseItem(Player player)
        {
            Microsoft.Xna.Framework.Point tilePos = Main.MouseWorld.ToTileCoordinates();

            for(int x = tilePos.X; x < tilePos.X + 10; x++)
            {
                for(int y = tilePos.Y; y < tilePos.Y + 10; y++)
                {
                    bool isEdge = x == tilePos.X || x == tilePos.X + 9 || y == tilePos.Y || y == tilePos.Y + 9;

                    if (isEdge)
                    {
                        WorldGen.KillTile(x, y, false, false, true);
                        WorldGen.PlaceTile(x, y, TileID.WoodBlock, forced: true, mute: true);
                        if(Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                    }
                    else
                    {
                        WorldGen.PlaceWall(x, y, WallID.Wood, true);
                        if(Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                    }
                }
            }

            WorldGen.PlaceTile(tilePos.X + 6, tilePos.Y + 8, TileID.Chairs, forced: true);
            WorldGen.PlaceTile(tilePos.X + 4, tilePos.Y + 8, TileID.Tables, forced: true);
            WorldGen.PlaceTile(tilePos.X + 4, tilePos.Y + 4, TileID.Torches, forced: true);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendTileSquare(-1, tilePos.X + 3, tilePos.Y + 8, 3);
                NetMessage.SendTileSquare(-1, tilePos.X, tilePos.Y + 8, 3);
                NetMessage.SendTileSquare(-1, tilePos.X + 4, tilePos.Y + 5, 3);
            }

            int doorX = tilePos.X;
            int doorY = tilePos.Y + 6;

            for(int i = doorY; i <= doorY + 2; i++)
            {
                WorldGen.KillTile(doorX, i, false, false, true);
            }
           
            WorldGen.PlaceTile(doorX, doorY, TileID.ClosedDoor, forced: true);

            int door2X = tilePos.X + 9;
            int door2Y = tilePos.Y + 6;

            for(int y = door2Y; y <= door2Y + 2; y++)
            {
                WorldGen.KillTile(door2X, y, false, false, true);
            }

            WorldGen.PlaceTile(door2X, door2Y, TileID.ClosedDoor, forced: true);

           
            


            return true;
        }
    }
}
