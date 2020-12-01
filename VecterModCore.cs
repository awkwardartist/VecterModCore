using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Reflection;
using UnityEngine;
using BepInEx;

namespace BepVecterModCore
{
    [BepInPlugin("vecterModCore", "VecterModCore", "1.0.3")]
    [BepInProcess("Vecter.exe")]
    public class VecterModCore : BaseUnityPlugin
    {
        static string modSection;
        static bool HasAddedUI = false;
        public bool musicPathChangerEnabled;
        public static bool rainbowLiteEnabled;
        public ColourScheme scheme;
        public MusicPlayer player;
        public static List<string> ModSettings = new List<string>();


        void Start()
        {
            Debug.Log("I'm working with bep");
            HasAddedUI = false;
            ModSettings.Add("- ModCore");
        }
        void Update()
        {
            OptionsMenu2 menu;
            menu = Resources.FindObjectsOfTypeAll<OptionsMenu2>().First();
            ChangeMenuUI();

            if (menu.SelectedOption == "ModCore" && go.GeneralGameState.isOptionsMenuShowing)
            {
                menu.SelectedOption += "\n\nThanks for getting ModCore! Now other mods can piggyback off of\nthis one :)). \n\n'enter' to go to the modding discord :)\n[ Go To Discord ]".ToLowerInvariant();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Application.OpenURL("https://discord.gg/dskKGWbF5P");
                    
                }
            }
        }



        public static void ChangeMenuUI()
        {

            if (go.GeneralGameState.isOptionsMenuShowing && !HasAddedUI)
            {

                OptionsMenu2 menu;
                FieldInfo field_options = typeof(OptionsMenu2).GetField("options", BindingFlags.NonPublic | BindingFlags.Instance);
                List<string> options;
                options = field_options.GetValue(menu) as List<string>;


                //MenuOptions
                modSection = "------- Mods -------";
                options.Add(modSection);
                options.AddRange(ModSettings);

                HasAddedUI = true;
                menu = Resources.FindObjectsOfTypeAll<OptionsMenu2>().First();
            }
        }
    }
}

