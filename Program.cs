using System;
using System.Net;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PokeD.Core.Extensions;

namespace PokeD.SCON.Desktop
{
    public static class Program
    {
        static Program()
        {
            PacketExtensions.Init();
        }

        public static void Main(params string[] args)
        {
            if (Type.GetType("Mono.Runtime") != null) // -- Running on Mono
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            using (var game = new EmptyKeysUI(PlatformCode))
                game.Run();
            
        }
        private static void PlatformCode(Game client)
        {
            client.Window.ClientSizeChanged += ((EmptyKeysUI) client).OnResize;
            client.IsMouseVisible = true;
            client.Window.Position = new Point(0, 0);
            client.Window.AllowUserResizing = true;

            ((EmptyKeysUI) client).Resize(new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height));
        }
    }
}
