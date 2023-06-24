using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ToastyQoLCalamity.Content.NPCs;

namespace ToastyQoLCalamity.Content.Tiles
{
    public class ArenaTileClone : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Arena");
            AddMapEntry(new Color(128, 0, 0), name);
        }

        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            return false;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                if (!NPC.AnyNPCs(ModContent.NPCType<BulletHellSimulator>()))
                {
                    WorldGen.KillTile(i, j, false, false, false);
                    if (!Main.tile[i, j].HasTile && Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j, 0f, 0, 0, 0);
                    }
                }
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = Main.DiscoR / 255f;
            g = 0f;
            b = 0f;
        }
    }
}
