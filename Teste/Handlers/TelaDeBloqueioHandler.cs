using System;
using Microsoft.Win32;
using Teste.Servicos;

namespace Teste.Handlers
{
    public class TelaDeBloqueioHandler
    {
        public string caminhoimagem;
        public TelaDeBloqueioHandler(string caminhoimagem)
        {
            this.caminhoimagem = caminhoimagem;
        }

        public void Executa()
        {
            try
            {
                RegistroAppServico registro = new RegistroAppServico(RegistryHive.LocalMachine, RegistryView.Registry64);
                registro.EscreveValorRegistro(@"SOFTWARE\Microsoft\Windows\CurrentVersion\PersonalizationCSP", "LockScreenImagePath", caminhoimagem, RegistryValueKind.String);
                registro.EscreveValorRegistro(@"SOFTWARE\Microsoft\Windows\CurrentVersion\PersonalizationCSP", "LockScreenImageUrl", caminhoimagem, RegistryValueKind.String);
                registro.EscreveValorRegistro(@"SOFTWARE\Microsoft\Windows\CurrentVersion\PersonalizationCSP", "LockScreenImageStatus", "1", RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
