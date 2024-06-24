using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Teste.entities
{
    public class Wallpaper
    {
        public static void DefinirWallpaper(string caminhoImagem)
        {
            if (!File.Exists(caminhoImagem))
            {
                Console.WriteLine("O caminho da imagem não existe.");
                return;
            }
            try
            {
                string chaveRegistro = @"Control Panel\Desktop";
                using (RegistryKey chave = Registry.CurrentUser.OpenSubKey(chaveRegistro, true))
                {


                    if (chave != null)
                    {
                        chave.SetValue("Wallpaper", caminhoImagem);
                        SystemParametersInfo(0x0014, 0, caminhoImagem, 0x01 | 0x02);
                        Console.WriteLine("Mudança realizada.");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao abrir chave de registro.");
                    }
                }               
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    }
}



// Comando dentro de uma classe de handler para evitar armazenamento da magma
// Dar uma olhada app serviço

