using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.swcommands;
using System;
using System.Windows.Forms;

namespace RecordLineCSharpSldWorksCSharp.csproj
{

    partial class SolidWorksMacro
    {

        public SldWorks swAppEvents;

        public void Main()
        {

            // Set up events
            swAppEvents = (SldWorks)swApp;
            AttachEventHandlers();

            // Start macro recording
            swApp.RunCommand((int)swCommands_e.swCommands_RecordPauseMacro, "");

            // Write to VBA macro
            swApp.RecordLine("' Test");
            swApp.RecordLine("MsgBox(\"C:\\Test\\\")");

            // Write to C# macro
            swApp.RecordLineCSharp("// Test");
            swApp.RecordLineCSharp("System.Windows.Forms.MessageBox.Show(\"C:\\\\Test\\\\\");");

            // Write to VB.NET macro
            swApp.RecordLineVBnet("' Test");
            swApp.RecordLineVBnet("MsgBox(\"C:\\Test\\\")");

            
            //Stop the macro recordings
            swApp.RunCommand((int)swCommands_e.swCommands_StopMacro, "");
        }

        public void AttachEventHandlers()
        {
            AttachSWEvents();
        }

        public void AttachSWEvents()
        {
            swAppEvents.BeginRecordNotify += this.swAppEvents_BeginRecordNotify;
            swAppEvents.EndRecordNotify += this.swAppEvents_EndRecordNotify;
        }

        private int swAppEvents_BeginRecordNotify()
        {
            //Send message when the macro recording starts
            MessageBox.Show("Macro recording starting.");
            return 1;
        }

        private int swAppEvents_EndRecordNotify()
        {
            //Send message when macro recording ends
            MessageBox.Show("Macro recording ended.");
            return 1;
        }

        /// <summary>
        /// The SldWorks swApp variable is pre-assigned for you.
        /// </summary>
        public SldWorks swApp;


    }
}
