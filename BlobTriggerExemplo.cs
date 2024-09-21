using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Company.FunctionBlobStorage
{
    public class BlobTriggerExemplo
    {
        [FunctionName("BlobTriggerExemplo")]
        public void Run([BlobTrigger("samples-workitems/{name}", Connection = "e18219_STORAGE")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            StreamWriter writer = new StreamWriter(@"D:\Code\AzureFunctionBlobStorage\blob.txt");
            writer.WriteLine($"Blob adicionado: {name}");
            byte[] conteudo = new byte[2048];
            myBlob.Read(conteudo, 0, conteudo.Length);
            writer.WriteLine(Encoding.UTF8.GetString(conteudo, 0, conteudo.Length));
            writer.Close();
        }
    }
}
