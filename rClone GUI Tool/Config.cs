using IniParser;
using IniParser.Model;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace rClone_GUI
{
    public class Config
    {
        protected FileIniDataParser parser = new FileIniDataParser();
        protected IniData data;
        protected KeyDataCollection settings;
        protected string config = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.ini";

        public Config()
        {
            FileIniDataParser parser = new FileIniDataParser();

            if (!File.Exists(config))
            {
                data = new IniData();
                data.Sections.AddSection("Settings");

                data["Settings"].AddKey("LocalPath", "..");
                data["Settings"].AddKey("Filter", "");
                data["Settings"].AddKey("Overwrite", "Skip");

                parser.WriteFile(config, data);
            }

            data = parser.ReadFile(config);

            Settings = data["Settings"];
        }

        public string this[string key]
        {
            get { return Settings[key]; }
            set { Settings[key] = value; }
        }

        public KeyDataCollection Settings { get => settings; set => settings = value; }

        public void Save()
        {
            parser.WriteFile(config, data);
        }

        public static String GetPath()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.ini";
        }
    }
}