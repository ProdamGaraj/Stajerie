using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagerie
{
    public class Entity
    {
        public void WriteJson(string path)
        {
            string json = JsonConvert.SerializeObject(this);
            bool firstItem = false;
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                if (fileStream.Length == 0)
                {
                    fileStream.Close();
                    File.AppendAllText(path, "[");
                    firstItem = true;
                }
                else
                {
                    fileStream.Seek(-1, SeekOrigin.End);
                    if (fileStream.ReadByte() == ']') fileStream.SetLength(fileStream.Length - 1);
                    fileStream.Seek(0, SeekOrigin.Begin);
                }
            }
            if (firstItem)
            {
                File.AppendAllText(path, json + "]");
            }
            else
            {
                File.AppendAllText(path, "," + json + "]");
            }
        }
    }
}
