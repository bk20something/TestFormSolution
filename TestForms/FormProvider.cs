using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForms
{
    //This class is used to provide all forms to application
    //It uses the Singleton pattern so forms are only created once and then saved here
    public class FormProvider
    {
        //Forms managed by FormProvider
        //MainMenu
        //RosterDisplay
        //RosterLoad
        //SplashScreen
        //AddSolider
        //SelectOutPool

        //MainMenu Start 
        private static MainMenuForm _mainMenu;
        public static MainMenuForm MainMenu
        {
            get
            {
                if (_mainMenu == null || _mainMenu.IsDisposed) 
                {
                    _mainMenu = new MainMenuForm();
                }
                return _mainMenu;
            }
        }

        //RosterDisplay Start
        private static RosterDisplayForm _rosterDisplay;
        public static RosterDisplayForm RosterDisplay
        {
            get
            {
                if (_rosterDisplay == null || _rosterDisplay.IsDisposed)
                {
                    _rosterDisplay = new RosterDisplayForm();
                }
                return _rosterDisplay;
            }
        }

        //RosterLoad Start
        private static RosterLoadForm _rosterLoad;
        public static RosterLoadForm RosterLoad
        {
            get
            {
                if (_rosterLoad == null  || _rosterLoad.IsDisposed)
                {
                    _rosterLoad = new RosterLoadForm();
                }
                return _rosterLoad;
            }
        }

        //SplashScreen Start
        private static SplashScreenForm _splashScreen;
        public static SplashScreenForm SplashScreen
        {
            get
            {
                if (_splashScreen == null)
                {
                    _splashScreen = new SplashScreenForm();
                }
                return _splashScreen;
            }
        }

        //AddSolider Start
        private static AddSoliderForm _addSolider;
        public static AddSoliderForm AddSolider
        {
            get
            {
                if (_addSolider == null || _addSolider.IsDisposed)
                {
                    _addSolider = new AddSoliderForm();
                }
                return _addSolider;
            }
        }

        //SelectOutPool Start
        private static SelectOutPoolForm _selectOutPool;
        public static SelectOutPoolForm SelectOutPool
        {
            get
            {
                if (_selectOutPool == null || _selectOutPool.IsDisposed)
                {
                    _selectOutPool = new SelectOutPoolForm();
                }
                return _selectOutPool;
            }
        }
    }
}
