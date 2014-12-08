using System.IO;
using System.Text;

namespace TrabalhoCache
{
    public static class ReportManager
    {
        #region Static Methods

        //Gera o relatório com os parametros de entrada e saida
        public static bool CreateReport(string path, CacheMemory cacheMemory, string originFile)
        {
            try
            {
                StringBuilder report = new StringBuilder();

                report.AppendLine(CreateHeader(originFile));
                report.AppendLine(cacheMemory.CreateReport());

                StreamWriter writer = new StreamWriter(path);
                writer.Write(report.ToString());

                writer.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Cria o cabeçalho do relatório
        private static string CreateHeader(string originFile)
        {
            StringBuilder header = new StringBuilder();
            header.AppendLine(string.Concat("Arquivo: ", originFile));
            header.AppendLine(string.Concat("Autor(es): ", "Bruno Maschio Joaquim"));

            return header.ToString();
        }

        #endregion
    }
}
