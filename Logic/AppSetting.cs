using System;
using System.IO;
using System.Xml.Serialization;

namespace Logic
{
    public class AppSetting
    {
        private static readonly string r_FileAdress = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\AppSettings.xml";

        public string LastAccessToken { get; set; }

        public bool RememberUser { get; set; }

        private AppSetting()
        {
            LastAccessToken = null;
            RememberUser = false;
        }

        public static AppSetting LoadFromFile()
        {
            AppSetting obj = null;
            Stream stream = null;

            if (File.Exists(r_FileAdress))
            {
                try
                {
                    stream = new FileStream(r_FileAdress, FileMode.Open);
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSetting));
                    obj = serializer.Deserialize(stream) as AppSetting;
                }
                catch
                {
                    obj = new AppSetting();
                }
                finally
                {
                    stream.Dispose();
                }
            }
            else
            {
                obj = new AppSetting();
            }

            return obj;
        }

        public void Clear()
        {
            LastAccessToken = null;
            RememberUser = false;
        }

        public void SaveToFile()
        {
            if (!File.Exists(r_FileAdress))
            {
                using (File.Create(r_FileAdress))
                {
                }
            }

            using (Stream stream = new FileStream(r_FileAdress, FileMode.Truncate))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }
    }
}