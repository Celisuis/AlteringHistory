using AlteringHistory;
using ColossalFramework.IO;
using ColossalFramework.UI;
using Harmony;
using ICities;
using System;
using System.IO;
using System.Reflection;

namespace AlteringHistory
{
    public class AlteringHistory : IUserMod
    {
        public string Name => "Altering History";

        public string Description => "Enable/Disable Historical Building Settings on a Global Scale";
        

        public AlteringHistory()
        {
            CheckDirectories();
            Manager.LoadSettings();
        }

        private void CheckDirectories()
        {
            if (!Directory.Exists(DataLocation.localApplicationData + @"\Altering History\"))
                Directory.CreateDirectory(DataLocation.localApplicationData + @"\Altering History\");
        }

        public void OnSettingsUI(UIHelper helper)
        {
            helper.AddCheckbox("Auto-Enable Historic Buildings", Manager.Current_Settings.Auto_Historic, OnAutoCheckChanged);
            
        }

       private void OnAutoCheckChanged(bool value)
        {
            Manager.Current_Settings.Auto_Historic = value;

            Manager.SaveSettings();
        }


    }
}
