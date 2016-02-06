using System;
using System.Net;

using Aragas.Core.Wrappers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PokeD.Core.Extensions;

using PokeD.SCON.Desktop.WrapperInstances;

namespace PokeD.SCON.Desktop
{
    public static class Program
    {
        static Game Game { get; set; }

        static Program()
        {
            AppDomainWrapper.Instance = new AppDomainWrapperInstance();
            FileSystemWrapper.Instance = new FileSystemWrapperInstance();
            TCPClientWrapper.Instance = new TCPClientFactoryInstance();
            InputWrapper.Instance = new InputWrapperInstance();
            ThreadWrapper.Instance = new ThreadWrapperInstance();

            PacketExtensions.Init();
        }

        //[STAThread]
        public static void Main(params string[] args)
        {
            if (Type.GetType("Mono.Runtime") != null) // -- Running on Mono
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            using (Game = new EmptyKeysUI(PlatformCode))
                Game.Run();
            
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
