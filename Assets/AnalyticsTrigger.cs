using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsTrigger : MonoBehaviour
{

    public enum AnalyticsEvent
    {
        //Water Level
        WaterLevel1Room1,
        WaterLevel1Room2,
        WaterLevel1Room3,
        WaterLevel1Room4,
        WaterLevel1MisteryRoom,
        WaterLevel1ShinyRoom,
        FinishedWaterLevel1,
        FinishedWaterChapter,

        //Earth Level
        EarthLevel1Room1,
        EarthLevel1Room2,
        EarthLevel1Room3,
        EarthLevel1Room4,
        EarthLevel1MisteryRoom,
        EarthLevel1ShinyRoom,
        EarthLevel1Secret,
        FinishedEarthChapter,

        //Fire Levels
        FireLevel1Room1,
        FireLevel1Room2,
        FireLevel1Room3,
        FireLevel1Room4,
        FireLevel1Room5,
        FireLevel1MisteryRoom,
        FinishedFireLevel1,

        FireLevel2Room1,
        FireLevel2Room2,
        FireLevel2Room3,
        FinishedFireChapter,

        //Air Level
        AirLevel1Room1,
        AirLevel1PressurePlatesRoom,
        AirLevel1TornadoRoom,
        AirLevel1KeyRoom,
        AirLevel1GemRoom,
        AirLevel1FinalRoom,
        FinishedAirChapter,

        //Electricity Level
        ElectricityLevel1Room1,
        ElectricityLevel1Room2,
        ElectricityLevel1ChestRoom,
        ElectricityLevel1MisteryRoom,
        ElectricityLevel1ShinyRoom,
        ElectricityLevel1FinalRoom,
        FinishedElectricityLevel,

        //Wizard Levels
        WizardLevel1Room0,
        WizardLevel1Room1,
        WizardLevel1Room2,
        WizardLevel1Room3,
        WizardLevel1Room4,
        WizardLevel1Room5,
        WizardLevel1Room6,
        WizardLevel1Room7,
        WizardLevel1SecretRoom,
        WizardLevel1FinalRoom,

        //Enemies That killed you
        BouncingBall,
        EvilMole,
        EvilTree,
        Water,
        Tornado,
        WaterBoss,
        WaterBossWizard,
        Wizard
    }

    public AnalyticsEvent analyticEventTobeTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         AnalyticsResult analyticsResult = Analytics.CustomEvent(analyticEventTobeTriggered.ToString()); 
    }
}
