using ColossalFramework;
using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlteringHistory
{
    public class BuildingExtension : BuildingExtensionBase
    {
        public override void OnBuildingCreated(ushort id)
        {
            if(Manager.Current_Settings.Auto_Historic)
            {
                var buildingManager = Singleton<BuildingManager>.instance;

                for(int x = 0; x < buildingManager.m_buildings.m_buffer.Length; x++)
                {
                    var info = buildingManager.m_buildings.m_buffer[x].Info;
                    var ai = info.m_buildingAI;

                    ai.SetHistorical(id, ref buildingManager.m_buildings.m_buffer[x], true);
                }
            }
        }
    }
}
