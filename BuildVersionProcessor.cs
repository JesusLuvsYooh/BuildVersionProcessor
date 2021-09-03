// Credits:
// JamesDev for original script inspiration
// && JesusLuvsYooh StephenAllenGames.co.uk for auto build feature and editing.
// && Nick for beating me to a fix

// This file must be in an "Editor" folder (Unity/Assets/Editor) for example. 
// Set autoIncreamentBuildVersion to false, to disable auto version changing
// This script should increase the end number of your version
// So..  0 would become 1    -     1.1 would become 1.2    -    1.2.3 would become 1.2.4

// Version 1.1:
// Fixed where matching numbers like 6.0.6 would go to 7.0.7 (should have been 6.0.7)

using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

class BuildVersionProcessor : IPreprocessBuildWithReport
{
    private bool autoIncreamentBuildVersion = true;

    public int callbackOrder { get { return 0; } }
    public void OnPreprocessBuild(BuildReport report)
    {
        //Debug.Log("MyCustomBuildProcessor.OnPreprocessBuild for target " + report.summary.platform + " at path " + report.summary.outputPath);
        if (autoIncreamentBuildVersion) { IncrementVersion(); }
    }

    [MenuItem("File/Manually Increment Build Version", priority = 1)]
    public static void ButtonIncrementVersion()
    {
        Debug.Log("Button Increment Version called.");
        IncrementVersion();
    }

    private static void IncrementVersion()
    {
        string versionCurrent = Application.version;
        string[] versionParts = versionCurrent.Split('.');

        if (versionParts != null && versionParts.Length > 0)
        {
            int versionIncremented = int.Parse(versionParts[versionParts.Length - 1]);
            versionIncremented += 1;
            versionParts[versionParts.Length - 1] = versionIncremented.ToString();
            PlayerSettings.bundleVersion = string.Join('.', versionParts);

            Debug.Log("Version:  " + versionCurrent + "  increased to:  " + PlayerSettings.bundleVersion);
        }
        else
        {
            Debug.Log("Version has no data, check Unity - Player Settings - Version, input box at top.");
        }
    }
 }
