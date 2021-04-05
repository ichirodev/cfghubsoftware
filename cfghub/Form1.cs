using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cfghub
{
    public partial class CFGHUB : Form
    {
        /** @brief A Class that stores the information of every cfg
         */
        private class CfgFolder
        {
            private string Name { get; set; }
            private string Size { get; set; }
            private string Directory { get; set; }
            private string LastUpdate { get; set; }

            public CfgFolder(string n, string s, string d, string u)
            {
                Name = n;
                Size = s;
                Directory = d;
                LastUpdate = u;
            }
            public void SetName(string n)
            {
                Name = n;
            }
            public void SetSize(string s)
            {
                Size = s;
            }
            public void SetDir(string d)
            {
                Directory = d;
            }
            public void SetLastUpdate(string u)
            {
                LastUpdate = u;
            }

            /** @brief Returns one of the four atributes depending on the given parameter.
             * 
             *  @param name
             *  @return Returns the name (CFG/Savegame name) as a string.
             *  @param size 
             *  @return Returns the size on MB as a string.
             *  @param directory 
             *  @return Returns the full directory of the CFG/Savegame folder as a string.
             *  @param update
             *  @return Returns the last date when the folder was updated as a formatted string.
             *  
             *  @return If the parameter is unknown the function returns "err".
             */
            public string Get(string what)
            {
                if (what == "name")
                {
                    return Name;
                }
                if (what == "size")
                {
                    return Size;
                }
                if (what == "directory")
                {
                    return Directory;
                }
                if (what == "update")
                {
                    return LastUpdate;
                }
                return "err";
            }

            /** @brief Set all the atributes of the object as null 
             */
            public void Wipe()
            {
                Name = null;
                Size = null;
                Directory = null;
                LastUpdate = null;
            }

            /** @brief Get the atributes as a formatted string
             *  @param putUsername decides wheter put %username% or not in the directory
             */
            public string toString(bool putUsername) {
                string ts = Name;
                ts += "|";
                ts += Size;
                ts += "|";
                if (putUsername)
                {
                    ts += Directory;
                } else
                {
                    ts += SetWindowsUniversalUsername(Directory);
                }
                ts += "|";
                ts += LastUpdate;

                return ts;
            }
            /** @brief Changes Windows username for %username%
             */
            private string SetWindowsUniversalUsername(string s)
            {
                char[] separator = { '\\' };
                string[] ss = s.Split(separator);
                ss[2] = "%username%"; // C: = index 0, Users = index 1, USERNAME = index 2
                string newDirString = "";

                for (int i = 0; i < ss.Length; i++)
                {
                    newDirString += ss[i];
                    /*
                     * Dont write the last '\', otherwhise it will create a new directory 
                     */
                    if (i != ss.Length - 1)
                    {
                        newDirString += @"\";
                    }
                }

                return newDirString;
            }
        }

        /*
         * Variables and objects that communicate between the whole project
         */
        private CfgFolder CfgManager;
        private List<CfgFolder> CFGList;
        private string gameFolderName;
        private string CFGHUBTfPath = @"C:\Users\%username%\Documents\cfghub\cfghub.dat";
        private string CFGHUBFPath = @"C:\Users\%username%\Documents\cfghub\";
        public CFGHUB()
        {
            // fill list at the start of the program
            CfgManager = new CfgFolder("", "", "", ""); // Init object
            CFGList = new List<CfgFolder>(); // Init list
            CFGHUBTfPath = GetWindowsUsername(CFGHUBTfPath); // Change %username% for the actual user name from Windows
            InitializeComponent();
            OnStartRetrieveBackUp();
        }

        /*
         *      ___  __            
         *  \  / |  (_  | |  /\  |  
         *   \/ _|_ __) |_| /--\ |_                
         */

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /** @brief Add a CFG/Savegame
         * 
         *  By pressing this button two things happen:
         *      1.- It stores the CFG/Savegame on the cfghub folder
         *      2.- It writes on a file the added CFG/Savegame data
         *
         */
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            /*
             * Let the user add Items only if the input is valid.
             * A folder needs to be selected with BAdd and text
             * on TBName should have a lenght of at least 1.
             */
            if (gameFolderName != null && TBName.Text.Length >= 1 && CheckForDuplicatedDirectory(gameFolderName) == false)
            {
                /*
                 * Get LV data from different places
                 */
                string gameFolderSize = GetDirectorySize(gameFolderName).ToString();
                string timeNow = DateTime.Now.ToString(@"MM\/dd\/yy h\:mm tt");
                /*
                 * Add Item to the LV
                 */
                ListViewItem myList = new ListViewItem(TBName.Text);
                myList.SubItems.Add(timeNow); // Get time of when the button is pressed
                myList.SubItems.Add(gameFolderName); // Get the folder name, see BAdd_Click() for more information
                myList.SubItems.Add(gameFolderSize + " MB");
                LVFolders.Items.Add(myList); // Update LV
                /*
                 * Fill CfgManager object with data to write in cfghub/cfghub.txt
                 */
                CfgManager.SetName(TBName.Text);
                CfgManager.SetLastUpdate(timeNow);
                CfgManager.SetDir(gameFolderName);
                CfgManager.SetSize(gameFolderSize);
                writeToFile(CfgManager.toString(false));
                /*
                 * Add object to the list
                 */
                CFGList.Add(new CfgFolder(TBName.Text, gameFolderSize, gameFolderName, timeNow));
                /*
                 * Copy the CFG/Savegame folder to the CFGHUB folder
                 * Using CopyFolder, the first parameter is the folder where the original folder is
                 * and the second one is the CFGHUB Folder, because it has "%username%" and C# doesn't recognizes
                 * it we change "%username%" and put the actual Windows username on it to copy
                 * folders without problem.
                 */
                CopyFolder(gameFolderName, GetWindowsUsername(CFGHUBFPath));
                /*
                 * Wipe CfgManager and wait for new information to be put inside.
                 */
                CfgManager.Wipe();
            } else
            {
                FireWindowEW("Warning", "Select a folder and write a name of more than one character long. " +
                    "Also, make sure the directory you are trying to add is not already on the list.");
            }
        }

        /** @brief Delete a selected folder on the ListView 
         */
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem myListItem in LVFolders.SelectedItems)
            {
                foreach (CfgFolder cfgFolderIterator in CFGList)
                {
                    if (cfgFolderIterator.Get("directory") == myListItem.SubItems[2].Text)
                    {
                        /*
                         * Delete item's folder
                         */
                        if (DeleteDirectoryBackupFrom(cfgFolderIterator.Get("directory")))
                        {
                            Console.WriteLine("Success! Folder was removed.");
                        } else
                        {
                            Console.WriteLine("Something happened, we couldn't remove the folder.");
                        }

                        /*
                         * Remove line from the cfghub/cfghub.txt file
                         */
                        if (RemoveLineFromFile(@"" + cfgFolderIterator.toString(false), CFGHUBTfPath))
                        {
                            Console.WriteLine("Success! cfghub.txt updated");
                        } else
                        {
                            Console.WriteLine("Something happened, we couldn't overwrite the cfghub.txt file");
                        }

                        CFGList.Remove(cfgFolderIterator); // Remove the item from CFGList
                    }
                    break;
                }
                myListItem.Remove(); // Remove the item from LV
            }
        }

        /** @brief Open the selected folder on the ListView
         */
        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem myListItem in LVFolders.SelectedItems)
            {
                foreach (CfgFolder cfgFolderIterator in CFGList)
                {
                    if (cfgFolderIterator.Get("directory") == myListItem.SubItems[2].Text)
                    {
                        string currentPath = @"";
                        currentPath += myListItem.SubItems[2].Text;
                        System.Diagnostics.Process.Start("explorer.exe", currentPath);
                    }
                }
            }
        }

        private void LVFolders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /** @brief Open the Folder Browser Dialog and store the directory of a
         *  selected folder.
         */
        private void BAdd_Click(object sender, EventArgs e)
        {
            /*
             * Open a fbd and store the selected folder on the variable gameFolderName
             * in order to use it later.
             */
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                gameFolderName = fbd.SelectedPath;
            }
        }

        /** @brief Update a selected CFG/Savegame by replacing the back-up with new up-to-date files
         */
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string oldLineAtDatFile = null;
            string newLineAtDatFile = null;
            bool updateStatus = true;

            foreach (ListViewItem myListItem in LVFolders.SelectedItems)
            {
                // Copies again the selected CFG's folder from the source folder.
                gameFolderName = GetWindowsUsername(CFGHUBFPath);
                CopyFolder(myListItem.SubItems[2].Text, gameFolderName);
                // Update LV Last update
                myListItem.SubItems[1].Text = DateTime.Now.ToString(@"MM\/dd\/yy h\:mm tt");
                /*
                 * Search at the List and change the last update, get a string to replace from the dat file
                 */
                foreach (CfgFolder cfgFolderIterator in CFGList)
                {
                    if (cfgFolderIterator.Get("directory") == myListItem.SubItems[2].Text)
                    {
                        oldLineAtDatFile = cfgFolderIterator.toString(false);
                        cfgFolderIterator.SetLastUpdate(DateTime.Now.ToString(@"MM\/dd\/yy h\:mm tt"));
                        newLineAtDatFile = cfgFolderIterator.toString(false);
                    }
                }
            }
            updateStatus = UpdateLineAtFile(oldLineAtDatFile, newLineAtDatFile, CFGHUBTfPath);
            if (updateStatus == false)
            {
                FireWindowEW("Error", "Something happened and we couldn't update your CFG/Savegame. Check if the" +
                    "game folder is not on read-mode only.");
            }
        }

        /** @brief Update all the CFGs/Savegames by replacing the back-ups with new up-to-date files
         */
        private void ButtonUpdateAll_Click(object sender, EventArgs e)
        {
            string oldLineAtDatFile = null;
            string newLineAtDatFile = null;
            bool updateStatus = true;

            foreach (ListViewItem myListItem in LVFolders.Items)
            {
                // Copies again the selected CFG's folder from the source folder.
                gameFolderName = GetWindowsUsername(CFGHUBFPath);
                CopyFolder(myListItem.SubItems[2].Text, gameFolderName);
                // Update LV Last update
                myListItem.SubItems[1].Text = DateTime.Now.ToString(@"MM\/dd\/yy h\:mm tt");
                /*
                 * Search at the List and change the last update, get a string to replace from the dat file
                 */
                foreach (CfgFolder cfgFolderIterator in CFGList)
                {
                    if (cfgFolderIterator.Get("directory") == myListItem.SubItems[2].Text)
                    {
                        oldLineAtDatFile = cfgFolderIterator.toString(false);
                        cfgFolderIterator.SetLastUpdate(DateTime.Now.ToString(@"MM\/dd\/yy h\:mm tt"));
                        newLineAtDatFile = cfgFolderIterator.toString(false);
                    }
                }
                // Update the file with the new update date
                updateStatus = UpdateLineAtFile(oldLineAtDatFile, newLineAtDatFile, CFGHUBTfPath);
                if (updateStatus == false)
                {
                    FireWindowEW("Error", "Something happened and we couldn't update a CFG/Savegame. Check if the" +
                        " game folders are not on read-mode only.");
                }
            }
        }

        /*      ___  __  _ 
         * |\/|  |  (_  /  
         * |  | _|_ __) \_ 
         */

        /** @brief Change %username% for the actual Windows Username.
         */
        private string GetWindowsUsername(string dir)
        {
            char[] separator = { '\\' };
            string[] ss = dir.Split(separator);
            /*
             * Search for the index that stores "%username%" and change it
             */
            for (int i = 0; i < ss.Length; i++)
            {
                if (ss[i] == "%username%")
                {
                    ss[i] = Environment.UserName;
                }
            }
            /*
             * Put together the indexes from the ss array on a new string
             */
            string myNewString = "";
            for (int i = 0; i < ss.Length; i++)
            {
                myNewString += ss[i];
                /*
                 * Put a backslash after every index, excluding the last one.
                 */
                if (i != ss.Length - 1)
                {
                    myNewString += @"\";
                }
            }

            return myNewString;
        }

        /*  _ ___     _                        __  _       _     ___ 
         * |_  |  |  |_   |\/|  /\  |\ |  /\  /__ |_ |\/| |_ |\ | |  
         * |  _|_ |_ |_   |  | /--\ | \| /--\ \_| |_ |  | |_ | \| |    
         */

        /** @brief Returns the size on Megabytes of a given directory.
         * 
         *  The full directory should be given as the user reads it from its computer. 
         *  
         *  @param d directory as a string
         *  @return size in Megabytes as a double
         */
        private double GetDirectorySize(string d)
        {
            double folderSize = 0;
            /*
             * Move throught the directory and get the size of every file, then add 'em all.
             */
            DirectoryInfo di = new DirectoryInfo(d);
            FileInfo[] fi = di.GetFiles("*.*", SearchOption.AllDirectories);
            for (int i = 0; i < fi.Count(); i++)
            {
                folderSize += fi[i].Length;
            }

            return folderSize / 1000000; // Divide it by a million to get the size in MB, then return that number
        }

        /** @brief Check if the directory is already added
         */
        private bool CheckForDuplicatedDirectory(string dirAboutToBeAdded)
        {
            foreach (CfgFolder cfgFolderIterator in CFGList)
            {
                if (dirAboutToBeAdded == cfgFolderIterator.Get("directory"))
                {
                    return true;
                }
            }
            return false;
        }

        /** @brief Write a string into the file cfghub.txt
         */
        private void writeToFile(string i)
        {
            try
            {
                using (FileStream fs = new FileStream(CFGHUBTfPath, FileMode.Append, FileAccess.Write))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(i);
                    sw.Close();
                    fs.Close();
                }
            }
            catch
            {
                FireWindowEW("Error", "CFGHUB can't open/write on the cfghub/cfghub.txt file, " +
                    "make sure CFGHUB is running as Administrator and cfghub/cfghub.txt is not on read-mode only");
            }

        }

        /** @brief Removes a line from a given file
         *  @param line The line you want to find in the file and remove.
         *  @param path The path where your text file is.
         *  
         *  @return true if the line was removed
         *  @return false if the line wasn't removed mostly due to problems with the file
         */
        private bool RemoveLineFromFile(string line, string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    return false;
                }
                string thisLine;
                StreamReader sr = new StreamReader(path);

                StreamWriter sw = new StreamWriter(path + "tmp");
                    
                while (sr.Peek() >= 0)
                {
                    /*
                     * Write everything as long as the strings (line from parameters and thisLine) are different
                     */
                    thisLine = sr.ReadLine();
                    if (thisLine != line)
                    {
                        sw.WriteLine(thisLine);
                     }
                }
                sr.Close();
                sw.Close();
                File.Delete(path);
                File.Move(path + "tmp", path);
            } catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                return false;
            }
            return true;
        }

        /** @brief Updates a line at a file
         *  @param oldLine The line you want to remove from the file
         *  @param newLine The line you want to add to the file instead of oldLine
         *  @param path The path where your text file is.
         *  
         *  @return true if the line was updated
         *  @return false if the line wasn't updated mostly due to problems with the file
         */
        private bool UpdateLineAtFile(string oldLine, string newLine, string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    return false;
                }
                string thisLine;
                StreamReader sr = new StreamReader(path);

                StreamWriter sw = new StreamWriter(path + "tmp");

                while (sr.Peek() >= 0)
                {
                    /*
                     * Once found the line we wanted change it and write anything else normally
                     */
                    thisLine = sr.ReadLine();
                    if (thisLine != oldLine)
                    {
                        sw.WriteLine(thisLine);

                    } else
                    {
                        sw.WriteLine(newLine);
                    }
                }
                sr.Close();
                sw.Close();
                File.Delete(path);
                File.Move(path + "tmp", path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                return false;
            }
            return true;
        }

        /** @brief Copy a root folder from a source to a target.
         *  @param sourceDir Source folder
         *  @param targetDir Target folder
         */
        private static void CopyFolder(string sourceDir, string targetDir)
        {
            /*
             * Put the new folder name in the source root.
             * If this isn't done, everything from the source would
             * be copied to the target without making a new separated folder.
             */
            char[] separator = { '\\' };
            string[] ss = sourceDir.Split(separator);
            if (targetDir[targetDir.Length - 1] == '\\')
            {
                targetDir += ss[ss.Length - 1];
            } else
            {
                targetDir += "\\";
                targetDir += ss[ss.Length - 1];
            }

            /*
             * Copying the actual data
             */
            var ds = new DirectoryInfo(sourceDir);
            var dt = new DirectoryInfo(targetDir);

            CopyAll(ds, dt);
        }

        /** @brief Recursive function that copies all the directories and data from an specific folder
         *  @param ds DirectoryInfo from the source
         *  @param dt DirectoryInfo from the target
         */
        private static void CopyAll(DirectoryInfo ds, DirectoryInfo dt)
        {
            Directory.CreateDirectory(dt.FullName);
            /*
             * Copy all the files from the source
             */
            foreach (FileInfo fi in ds.GetFiles())
            {
                fi.CopyTo(Path.Combine(dt.FullName, fi.Name), true);
            }

            /*
             * Start searching through all the subdirectories with recursivity.
             */
            foreach (DirectoryInfo diSourceSubdirectory in ds.GetDirectories())
            {
                DirectoryInfo nextTargetSubdir = dt.CreateSubdirectory(diSourceSubdirectory.Name);
                CopyAll(diSourceSubdirectory, nextTargetSubdir);
            }
        }

        /** @brief Delete the directory of the backup
         *  @param directoryToDelete receives the directory where the backup was made from.
         *  @return true if the folder was deleted or never existed
         *  @return false if the folder couldn't be removed
         */
        private bool DeleteDirectoryBackupFrom(string directoryToDelete)
        {
            char[] separator = { '\\' };
            string[] ss = directoryToDelete.Split(separator);
            string fullDirectory = @"" + GetWindowsUsername(CFGHUBFPath) + ss[ss.Length - 1];
            try {
                var directoryExists = Directory.Exists(fullDirectory);
                return directoryExists;
            } catch (Exception deleteDirectoryBackupFromError){
                FireWindowEW("Error", deleteDirectoryBackupFromError.Message);
                return false;
            }
        }

        private void OnStartRetrieveBackUp()
        {
            /*
             * Read from the cfghub.txt file and load data to display in the LV 
             */
            string thisLine = "";
            char[] separator = { '|' };
            string[] ss = new string[4];
            try
            {
                using (FileStream fs = new FileStream(CFGHUBTfPath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while(sr.Peek() >= 0)
                        {
                            thisLine = sr.ReadLine();
                            ss = thisLine.Split(separator);
                            /*
                             * Add Item to the list
                             */
                            CFGList.Add(new CfgFolder(ss[0], ss[1], GetWindowsUsername(ss[2]), ss[3])); // Push it to the list

                            /*
                             * Add Item to the LV
                             */
                            ListViewItem myList = new ListViewItem(ss[0]);
                            myList.SubItems.Add(ss[3]); // Get time of when the button is pressed
                            myList.SubItems.Add(GetWindowsUsername(ss[2])); // Get the folder name, see BAdd_Click() for more information
                            myList.SubItems.Add(ss[1] + " MB");
                            LVFolders.Items.Add(myList); // Update LV
                            /*
                             * Clear pivots
                             */
                            thisLine = null;
                            ss = null;
                        }
                    }
                }
            } catch (Exception e)
            {
                FireWindowEW("Error", "cfghub folder doesn't exists on the defined path and couldn't be created.\n" +
                    "Search the file \'mkdir\' on your CFGHUB installation folder and run it as Administrador");
                Console.WriteLine(e);
            }
        }
        /** @brief Shows a MessageBox with only title and message
         */
        private void FireWindowEW(string title, string message)
        {
            MessageBox.Show(message, title);
        }
        /** @brief Exports your backups as a zip
         */
        private void ButtonExport_Click(object sender, EventArgs e)
        {
            /*
             * Select the path where the zip is gonna be exported at
             */
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult folderResult = folderDialog.ShowDialog();
            if (folderResult == DialogResult.OK)
            {
                /*
                 * Create the name for the zip file
                 */
                string exportDirectory = folderDialog.SelectedPath;
                exportDirectory += "\\cfghub-backup-";
                exportDirectory += DateTime.Now.ToString(@"MM\-dd\-yy\_h\-mm\-ss");
                exportDirectory += ".zip";
                string zipFolder = GetWindowsUsername(CFGHUBFPath);
                Console.WriteLine("Status for back-up {0} -> {1}", zipFolder, exportDirectory);
                ZipFile.CreateFromDirectory(zipFolder, exportDirectory, CompressionLevel.Optimal, false);
                /*
                 * Check if the file was created
                 */
                if (File.Exists(exportDirectory)) {
                    FireWindowEW("Export successful", "Back-up file exported successfully...");
                } else
                {
                    FireWindowEW("Export failed", "Back-up file export failed, try again or try to export in a different directory...");
                }
            } 
        }

        private void ButtonRecover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Select a file";
            openFile.Filter = "ZIP Files (*.zip)|*.zip";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                /* Delete old content from CFGHUB's folder */
                DirectoryInfo cfghubdir = new DirectoryInfo(GetWindowsUsername(CFGHUBFPath));
                foreach (FileInfo fileInside in cfghubdir.GetFiles())
                {
                    fileInside.Delete();

                }
                foreach (DirectoryInfo dirInside in cfghubdir.GetDirectories())
                {
                    dirInside.Delete(true);
                }

                /* Export CFGHUB content */
                try
                {
                    ZipFile.ExtractToDirectory(openFile.FileName, GetWindowsUsername(CFGHUBFPath));
                    FireWindowEW("Back-up imported successfully", "In order to see changes on CFGHUB restart the program...");
                } catch (Exception RecoverExtractToDirectoryE)
                {
                    FireWindowEW("Error", RecoverExtractToDirectoryE.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InformationButton_Click(object sender, EventArgs e)
        {

        }

        private void DonateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
