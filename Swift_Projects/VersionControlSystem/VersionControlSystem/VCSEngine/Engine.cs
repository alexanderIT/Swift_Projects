using DiffMatchPatch;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersionControlSystem.Repository;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using VersionControlSystem.Data;
using System.Linq.Expressions;

namespace VersionControlSystem.VCSEngine
{
    public class Engine
    {
        private DbContext context;

        private IRepository<User> users;
        private IRepository<NewFile> files;
        private IRepository<FileVersion> versions;

        private TextBox textFile => Application.OpenForms["Form1"]
                .Controls["textFile"] as TextBox;
        private TextBox textBoxRegisterUser => Application.OpenForms["Form3"]
                .Controls["textBoxRegisterUser"] as TextBox;
        private ComboBox comboBoxUsers => Application.OpenForms["Form1"]
                .Controls["comboBoxUsers"] as ComboBox;
        private TextBox textBoxComments => Application.OpenForms["Form1"]
                .Controls["textBoxComments"] as TextBox;
        private RichTextBox richTextBoxCurrentVersion => Application.OpenForms["Form2"]
                .Controls["richTextBoxCurrentVersion"] as RichTextBox;
        private RichTextBox richTextBoxLastVersion => Application.OpenForms["Form2"]
                .Controls["richTextBoxLastVersion"] as RichTextBox;
        private Button buttonCheck_In => Application.OpenForms["Form1"]
                .Controls["buttonCheck_In"] as Button;

        private List<Diff> diffs;
        private Color[] colors1 => new Color[3] { Color.LightGreen, Color.LightSalmon, Color.White, };
        private Color[] colors2 => new Color[3] { Color.DarkRed, Color.DarkOrange, Color.White };
        public string savePath;
        public string currentFileName;

        public Engine()
        {
            this.context = new VCSDBContext();
            this.users = new GenericRepository<User>(this.context);
            this.files = new GenericRepository<NewFile>(this.context);
            this.versions = new GenericRepository<FileVersion>(this.context);
            this.savePath = this.GetFileDirectory();



        }

        public Engine(DbContext context)
        {
            this.context = context;
            this.users = new GenericRepository<User>(this.context);
            this.files = new GenericRepository<NewFile>(this.context);
            this.versions = new GenericRepository<FileVersion>(this.context);
            this.savePath = this.GetFileDirectory();


        }
        public string GetFileNameFromDirectory()
        {
            var txtFiles = Directory.GetFiles(savePath, "*.txt")
                                      .Select(path => Path.GetFileName(path))
                                      .FirstOrDefault();
            return txtFiles;
        }


        public void GetFileFromDirectory()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                try
                {
                    string text = System.IO.File.ReadAllText(file);

                    textFile.Text = text;
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error: Could not read file from hardisk.Original error: {0}", ex.Message);
                }
            }
        }

        public string GetFileContentOfDirectory(string directory)
        {
            using (StreamReader str = new StreamReader(directory))
            {
                string directoryContent = str.ReadToEnd();
                return directoryContent;
            }
        }

        public void SaveFileInDirectory(string file)
        {
            SaveFileDialog savefile = new SaveFileDialog();

            savefile.FileName = ".txt";
            //savefile.CreatePrompt = true;
            savefile.OverwritePrompt = true;

            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                savePath = Path.GetDirectoryName(savefile.FileName);
                try
                {
                    currentFileName = savefile.FileName;
                }
                catch (NullReferenceException)
                {
                    currentFileName = Path.GetFullPath(savePath);
                }


                using (StreamWriter sw = new StreamWriter(currentFileName))
                {

                    savefile.OverwritePrompt = true;
                    sw.WriteLine(file);
                }
            }
        }

        public void DeleteFile()
        {
            string[] filePaths = Directory.GetFiles(savePath);
            foreach (string filePath in filePaths)
                File.Delete(filePath);
        }

        public void RegisterNewUser()
        {
            if (textBoxRegisterUser.Text == "")
            {
                MessageBox.Show("Insert user name!");
            }
            else
            {
                string userName = textBoxRegisterUser.Text;
                User newUser = new User()
                {
                    Name = userName
                };
                this.users.Add(newUser);
                this.users.SaveChanges();
            }

        }

        public void ListRegisterUser()
        {
            var registerUsers = users.All().ToList();

            comboBoxUsers.DataSource = new BindingSource(registerUsers, null);
            comboBoxUsers.DisplayMember = "Name";
            comboBoxUsers.ValueMember = "Id";
        }

        public string GetLatestVersion()
        {
            int lastId = this.versions.All()
                .OrderByDescending(i => i.Id)
                .Select(i => i.Id)
                .FirstOrDefault();
            try
            {
                string lastFile = this.versions.GetById(lastId).File.File1;
                return lastFile;
            }
            catch (Exception)
            {
                throw new NullReferenceException("The content of file is emptry or null!");
            }
        }
        private string GetFileDirectory()
        {

            int lastId = this.files.All()
                .OrderByDescending(i => i.Id)
                .Select(i => i.Id)
                .FirstOrDefault();
            try
            {
                string lastFileDirectory = this.files.GetById(lastId).SaveDirectory;
                return lastFileDirectory;
            }
            catch (Exception)
            {
                throw new NullReferenceException("File directory is emptry or null!");
            }
        }

        public void AddFileToVCS()
        {
            this.SaveFileInDirectory(textFile.Text);
            try
            {
                string lastFile = this.GetLastFile().File1;
            }
            catch (NullReferenceException)
            {
                NewFile newFile = new NewFile()
                {
                    File1 = textFile.Text,
                    Comment = textBoxComments.Text,
                    SaveDirectory = savePath

                };

                this.files.Add(newFile);
                this.files.SaveChanges();
                MessageBox.Show("Add file to Version Control Systems is Completed!");
            }


            if (!IsEqual(this.GetLastFile().File1, textFile.Text))
            {
                NewFile newFile = new NewFile()
                {
                    File1 = textFile.Text,
                    Comment = textBoxComments.Text
                };

                this.files.Add(newFile);
                this.files.SaveChanges();
                MessageBox.Show("Add file to Version Control Systems is Completed!");
            }
            else
            {
                MessageBox.Show("This file already added in Version Control Systems!");
            }


        }

        public void CheckOut()
        {
            int userId = GetUserId();

            NewFile currentFile = GetLastFile();
            currentFile.Locked = userId;
            this.files.Update(currentFile);
            this.files.SaveChanges();
            MessageBox.Show("Check_Out Completed!");
        }

        public void LockTextBox()
        {
            var lockedUserId = this.files.All()
               .OrderByDescending(i => i.Id)
               .Select(i => i.Locked)
               .FirstOrDefault();

            if (lockedUserId != null)
            {
                string lastFile = this.GetLastFile().File1;
                string currFile = textFile.Text;
                string selectedName = comboBoxUsers.GetItemText(comboBoxUsers.SelectedItem);

                var userName = this.users.GetById((int)lockedUserId).Name;

                if (selectedName != userName && lastFile == currFile)
                {
                    this.textFile.ReadOnly = true;
                }
                else
                {
                    this.textFile.ReadOnly = false;
                }
            }
            else
            {
                textFile.ReadOnly = false;
            }
        }

        private NewFile GetLastFile()
        {
            int lastId = this.files.All()
                .OrderByDescending(i => i.Id)
                .Select(i => i.Id)
                .FirstOrDefault();

            NewFile currentFile = this.files.GetById(lastId);
            return currentFile;
        }

        private int GetUserId()
        {
            string selectedName = comboBoxUsers.GetItemText(comboBoxUsers.SelectedItem);

            int userId = this.users.All()
                 .Where(n => n.Name == selectedName)
                 .Select(n => n.Id)
                 .FirstOrDefault();
            return userId;
        }

        public void CheckIn()
        {
            string lastVersion;
            NewFile currentFile = GetLastFile();
            int id = GetUserId();

            if (currentFile.Locked != null && currentFile.Locked != id)
            {
                MessageBox.Show("This file is check out from user another and cannot check in execute!");
            }
            else
            {
                bool isSame = this.textFile.Text != this.GetLastFile().File1;
                string lastFileContent = this.GetLastFile().File1;

                NewFile newFile = new NewFile()
                {
                    File1 = (lastFileContent == null || isSame) ? textFile.Text : lastFileContent,
                    Comment = textBoxComments.Text,
                    SaveDirectory = savePath
                };

                this.files.Add(newFile);
                this.files.SaveChanges();


                try
                {
                    lastVersion = this.GetLatestVersion();
                }
                catch (NullReferenceException)
                {

                    NewFile lastFile = GetLastFile();

                    int userId = GetUserId();

                    FileVersion newVersion = new FileVersion()
                    {
                        Creator = userId,
                        Date = DateTime.Now,
                        FileId = lastFile.Id
                    };
                    this.versions.Add(newVersion);
                    this.versions.SaveChanges();

                    MessageBox.Show("Check_In Completed!");
                }

                if (!IsEqual(this.GetLatestVersion(), this.GetLastFile().File1))
                {
                    NewFile lastFile = GetLastFile();

                    int userId = GetUserId();

                    FileVersion newVersion = new FileVersion()
                    {
                        Creator = userId,
                        Date = DateTime.Now,
                        FileId = lastFile.Id
                    };
                    this.versions.Add(newVersion);
                    this.versions.SaveChanges();

                    MessageBox.Show("Check_In Completed!");
                }
                else
                {
                    MessageBox.Show("Current file is already exist in database and Check_In operation is'n possible!");
                }
                this.textBoxComments.Clear();
                this.buttonCheck_In.Enabled = false;
            }
        }

        private bool IsEqual(string str1, string str2)
        {
            return String.Equals(str1, str2);
        }

        public void ShowDifferenceBetweenTwoFile()
        {
            diff_match_patch DIFF = new diff_match_patch();

            List<Chunk> chunklist1;
            List<Chunk> chunklist2;

            diffs = DIFF.diff_main(richTextBoxCurrentVersion.Text, richTextBoxLastVersion.Text);
            DIFF.diff_cleanupEfficiency(diffs);

            chunklist1 = collectChunks(richTextBoxCurrentVersion);
            chunklist2 = collectChunks(richTextBoxLastVersion);

            paintChunks(richTextBoxCurrentVersion, chunklist1);
            paintChunks(richTextBoxLastVersion, chunklist2);

            richTextBoxCurrentVersion.SelectionLength = 0;
            richTextBoxLastVersion.SelectionLength = 0;

        }
        private List<Chunk> collectChunks(RichTextBox RTB)
        {
            RTB.Text = "";
            List<Chunk> chunkList = new List<Chunk>();
            foreach (Diff d in diffs)
            {
                if (RTB == richTextBoxLastVersion && d.operation == Operation.DELETE) continue;
                if (RTB == richTextBoxCurrentVersion && d.operation == Operation.INSERT) continue;

                Chunk ch = new Chunk();
                int length = RTB.TextLength;
                RTB.AppendText(d.text);
                ch.startpos = length;
                ch.length = d.text.Length;
                ch.BackColor = RTB == richTextBoxCurrentVersion ? colors1[(int)d.operation] : colors2[(int)d.operation];
                chunkList.Add(ch);
            }
            return chunkList;
        }
        private void paintChunks(RichTextBox RTB, List<Chunk> theChunks)
        {
            foreach (Chunk ch in theChunks)
            {
                RTB.Select(ch.startpos, ch.length);
                RTB.SelectionBackColor = ch.BackColor;
            }
        }

        public void FillDataInRichTextBox()
        {
            richTextBoxCurrentVersion.Text = textFile.Text;
            richTextBoxLastVersion.Text = GetLatestVersion();
        }
    }
}
