using ColossalFramework;
using ColossalFramework.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlteringHistory
{
    public static class BuildingManagerExtension
    {
        
        public static void EnableHistoricalBuildings()
        {
            if (!BuildingManager.exists || !SimulationManager.exists || LoadingManager.instance.m_loadedEnvironment == null)
            {
                return;
            }

            int buildingsAltered = 0;
            var buildingManager = Singleton<BuildingManager>.instance;

            for(int x = 0; x < buildingManager.m_buildings.m_buffer.Length; x++)
            {
                try
                {
                    buildingManager.m_buildings.m_buffer[x].m_flags |= Building.Flags.Historical;
                    buildingsAltered++;
                }
                catch(Exception ex)
                {
                    UIView.ForwardException(new ModException("[Altering History] Failed to Alter Buildings.", ex));
                }
            }

            DebugOutputPanel.AddMessage(ColossalFramework.Plugins.PluginManager.MessageType.Message, $"[Altering History] {buildingsAltered} made historic.");
        }


       
        public static void DisableHistoricalBuildings()
        {
            if (!BuildingManager.exists || !SimulationManager.exists || LoadingManager.instance.m_loadedEnvironment == null)
            {
                return;
            }

            int buildingsAltered = 0;
            var buildingManager = Singleton<BuildingManager>.instance;

            for (int x = 0; x < buildingManager.m_buildings.m_buffer.Length; x++)
            {
                try
                {
                    buildingManager.m_buildings.m_buffer[x].m_flags &= ~Building.Flags.Historical;
                    buildingsAltered++;
                }
                catch (Exception ex)
                {
                    UIView.ForwardException(new ModException("[Altering History] Failed to Alter Buildings.", ex));
                }
            }

            DebugOutputPanel.AddMessage(ColossalFramework.Plugins.PluginManager.MessageType.Message, $"[Altering History] {buildingsAltered} made non-historic.");

        }
    }
}
