using ColossalFramework.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace AlteringHistory
{
    public static class Manager
    {

        public static Settings Current_Settings { get; set; }

        public static void SaveSettings()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("altering-history");
            xmlDoc.AppendChild(rootNode);

            XmlNode autoNode = xmlDoc.CreateElement("auto-enable");
            autoNode.InnerText = Current_Settings.Auto_Historic.ToString();

            rootNode.AppendChild(autoNode);

            xmlDoc.Save(DataLocation.localApplicationData + @"\Altering History\Settings.xml");
        }

        public static void LoadSettings()
        {

            if (File.Exists(DataLocation.localApplicationData + @"\Altering History\Settings.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(DataLocation.localApplicationData + @"\Altering History\Settings.xml");

                XmlNode autoNode = xmlDoc.SelectSingleNode("/altering-history/auto-enable");

                Settings loadedSettings = new Settings
                {
                    Auto_Historic = bool.Parse(autoNode.InnerText)
                };

                Current_Settings = loadedSettings;

                DebugOutputPanel.AddMessage(ColossalFramework.Plugins.PluginManager.MessageType.Message, "[Altering History] Loaded Settings File.");
            }
            else
            {
                DebugOutputPanel.AddMessage(ColossalFramework.Plugins.PluginManager.MessageType.Warning, "[Altering History] Couldn't find Settings File. Initializing New One.");

                Settings newSettings = new Settings
                {
                    Auto_Historic = false,
                };

                Current_Settings = newSettings;

                SaveSettings();
            }
        }
    }
}
