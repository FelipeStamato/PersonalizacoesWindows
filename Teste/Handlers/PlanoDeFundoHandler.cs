using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Teste.Handlers
{
    public class PlanoDeFundoHandler
    {
        public string caminhoimagem;
        public PlanoDeFundoHandler(string caminhoimagem)
        {
            this.caminhoimagem = caminhoimagem;
        }
        public void Executa()
        {
            if (!File.Exists(caminhoimagem))
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
                        chave.SetValue("Wallpaper", caminhoimagem);
                        SystemParametersInfo(0x0014, 0, caminhoimagem, 0x01 | 0x02);
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

