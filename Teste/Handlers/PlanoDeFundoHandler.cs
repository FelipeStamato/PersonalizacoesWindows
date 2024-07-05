using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Teste.Servicos;

namespace Teste.Handlers
{
    public class PlanoDeFundoHandler
    {
        private readonly string caminhoimagem;

        public PlanoDeFundoHandler(string caminhoimagem)
        {
            this.caminhoimagem = caminhoimagem;
        }
        public void Executa()
        {
            try
            {
                VerificaArquivo(caminhoimagem);
                CriaChave();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao definir o papel de parede: " + ex.Message);
            }
        }
        private void VerificaArquivo(string caminhoimagem)
        {
            if (!File.Exists(caminhoimagem))
            {
                throw new FileNotFoundException("O arquivo especificado não existe.", caminhoimagem);
            }
        }
        private void CriaChave()
        {
            RegistroAppServico registro = new RegistroAppServico(RegistryHive.CurrentUser, RegistryView.Registry64);
            registro.EscreveValorRegistro(@"Control Panel\Desktop", "Wallpaper", caminhoimagem, RegistryValueKind.String);
            registro.EscreveValorRegistro(@"Control Panel\Desktop", "WallpaperStyle", "6", RegistryValueKind.String);
            registro.EscreveValorRegistro(@"Control Panel\Desktop", "TileWallpaper", "0", RegistryValueKind.String);
            SystemParametersInfo(20, 0, caminhoimagem, 0x01 | 0x02);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    }
}
