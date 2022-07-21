using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using CsvHelper;
using CsvHelper.Configuration;
using System.Diagnostics;

namespace Psf2Csv
{
    
    public partial class Form1 : Form
    {
        private static readonly string[] extn = {
            ".hit",
            ".pxm",
            ".psq",
            ".psp",
            ".txt",
            ".mnu",
            ".exe"
        };

        private static readonly string[] extstk =
        {
            "FFFFFF01",
            "FFFFFF02",
            "FFFFFF03",
            "FFFFFF04",
            //"FFFFFF05",
            "FFFFFFFF",
            "FFFFFFFD",
            "801FFFF0"
        };

        private const int sep_min = 0x01000000;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lnkDOSEMU_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ofdDOSEMU.ShowDialog() == DialogResult.OK)
            {
                txtDOSEMU.Text = ofdDOSEMU.FileName;
            }
        }

        private void lnkSeq2Sep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ofdSeq2Sep.ShowDialog() == DialogResult.OK)
            {
                txtSeq2Sep.Text = ofdSeq2Sep.FileName;
            }
        }

        private void lnkQLPTool_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ofdQLPTool.ShowDialog() == DialogResult.OK)
            {
                txtQLPTool.Text = ofdQLPTool.FileName;
            }
        }

        private void lnkVFSTool_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ofdQLPTool.ShowDialog() == DialogResult.OK)
            {
                txtVFSTool.Text = ofdVFSTool.FileName;
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (ofdAddFile.ShowDialog() == DialogResult.OK)
            {
                string[] file = new string[4];
                file[0] = ofdAddFile.FileName;
                file[1] = TruncateString(Path.GetFileNameWithoutExtension(ofdAddFile.FileName), 63);
                file[2] = "-1";
                if (ofdAddFile.FilterIndex <= extn.Length)
                {
                    file[3] = extstk[ofdAddFile.FilterIndex - 1];
                    dgvFiles.Rows.Add(file);
                } else if (ofdAddFile.FilterIndex == extn.Length + 1)
                {
                    for (int i = 0; i<extn.Length; i++)
                    {
                        if (Path.GetExtension(ofdAddFile.FileName) == extn[i])
                        {
                            file[3] = extstk[i];
                            
                        }

                    }
                    dgvFiles.Rows.Add(file);
                } else
                {
                    sbiStatusText.Text = "Loading files from " + Path.GetDirectoryName(ofdAddFile.FileName);
                    for (int i = 0; i < extn.Length; i++) {
                        foreach (string s in Directory.GetFiles(Path.GetDirectoryName(ofdAddFile.FileName), '*' + extn[i], SearchOption.AllDirectories))
                        {
                            file[0] = s;
                            file[1] = TruncateString(Path.GetFileNameWithoutExtension(s), 63);
                            file[2] = "-1";
                            file[3] = extstk[i];
                            dgvFiles.Rows.Add(file);
                        }
                    }
                    sbiStatusText.Text = "Ready";

                }

                //dgvFiles.Rows.Add(file);
            }

        }

        private void btnSaveList_Click(object sender, EventArgs e)
        {
            
            if (sfdSaveList.ShowDialog() == DialogResult.OK)
            {
                //int[] quoted = { 2, 3 };
                SaveCsvFile(sfdSaveList.FileName, sfdSaveList.FilterIndex, dgvFiles, sbiStatusText);
                
            }
            
        }

        private void dgvFiles_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int t = 0;
            foreach (DataGridViewRow r in dgvFiles.Rows)
            {
                try
                {
                    t = Convert.ToInt32(r.Cells[2].Value);
                    if (t > dgvFiles.SelectedRows[0].Index)
                    {
                        r.Cells[2].Value = t - 1;
                    }
                    
                }
                catch (Exception ix)
                {
                    sbiStatusText.Text = ix.Message;
                }
            }

        }

        private void dgvFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] file = new string[4];
            string[] files;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string f in files)
                {
                    if (Directory.Exists(f))
                    {

                    } else
                    {
                        file[0] = f;
                        file[1] = TruncateString(Path.GetFileNameWithoutExtension(f), 63);
                        file[2] = "-1";
                        for (int i = 0; i < extn.Length; i++)
                        {
                            if (Path.GetExtension(f) == extn[i])
                            {
                                file[3] = extstk[i];

                            }

                        }
                        dgvFiles.Rows.Add(file);
                    }

                }
            }
        }

        private void dgvFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            } else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void btnAddPsf_Click(object sender, EventArgs e)
        {
            if (fbdAddPsf.ShowDialog() == DialogResult.OK)
            {
                AddPsfSet(fbdAddPsf.SelectedPath, sbiStatusText, dgvFiles, File.Exists(txtDOSEMU.Text), File.Exists(txtDOSEMU.Text), txtDOSEMU.Text, txtSeq2Sep.Text);
            }
        }

        public void AddPsfSet (string dir, ToolStripStatusLabel sbiStatusText, DataGridView dgvFiles, bool tempfn, bool dosemu, string dospath, string s2spath)
        {
            string[] vab = new string[8]; //remove extra columns and merge strings for easier comparison
            foreach (string s in Directory.GetFiles(dir, "*.seq", SearchOption.AllDirectories))
            {
                vab[0] = TruncateString(s, 255);
                vab[1] = TruncateString(Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(s)), 63); // removes data_0000
                try
                {
                    vab[5] = FindVhVb(s, ".vh");
                    vab[4] = Base64Hash(vab[5]);
                    
                    vab[7] = FindVhVb(s, ".vb");
                    vab[4] += Base64Hash(vab[7]);
                    //vab[6] = "TRUE";
                    dgvFiles.Rows.Add(vab);
                } catch (Exception cx)
                {
                    sbiStatusText.Text = cx.Message;
                }



            }
            dgvFiles.ClearSelection();

            Dictionary<string, int> psflib = new Dictionary<string, int>();
            int skip;
            int seq;
            //rows will always be added to the end
            
            //bool tempfn = File.Exists(txtDOSEMU.Text); //change this if your dos emu works better
            string tempfile;
            if (tempfn)
            {
                foreach (string s in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.seq"))
                {
                    //MessageBox.Show(Directory.GetCurrentDirectory(), s);
                    File.Delete(s);
                }
            }
            foreach (DataGridViewRow f in dgvFiles.Rows)
            {
                if (f.Cells[4].Value != null && f.Cells[6].Value == null)
                {
                    
                    if (psflib.TryGetValue(f.Cells[4].Value.ToString(), out seq))
                    {
                        if (tempfn)
                        {
                            tempfile = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".seq";
                            while (File.Exists(tempfile)) //avoid collision even though it will probably never happen
                            {
                                tempfile = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".seq";
                            }
                        }
                        else
                        {
                            tempfile = '"' + f.Cells[0].Value.ToString() + '"';
                        }

                        dgvFiles.Rows[seq].Cells[4].Value += (" " + tempfile );
                        f.Cells[2].Value = seq.ToString();
                        skip = sep_min + (int)dgvFiles.Rows[seq].Cells[6].Value;
                        f.Cells[3].Value = skip.ToString("X8");
                        dgvFiles.Rows[seq].Cells[6].Value = (int)dgvFiles.Rows[seq].Cells[6].Value + 1;

                        f.Cells[4].Value = null;
                    }
                    else
                    {
                        psflib.Add(f.Cells[4].Value.ToString(), f.Index);
                        f.Cells[6].ValueType = typeof(int);
                        f.Cells[6].Value = 1;
                        if (tempfn)
                        {
                            string tempsep = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".sep";
                            while (File.Exists(tempsep))
                            {
                                tempsep = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".sep";
                            }
                            tempfile = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".seq";
                            while (File.Exists(tempfile))
                            {
                                tempfile = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".seq";
                            }
                            tempfile = " -o " + tempsep + " " + tempfile;
                            f.Cells[0].Value = tempsep;
                        }
                        else
                        {
                            f.Cells[0].Value = Path.GetDirectoryName(f.Cells[0].Value.ToString()) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(f.Cells[0].Value.ToString());
                            tempfile = " -o " + '"' + f.Cells[0].Value.ToString() + '"';
                        }

                        f.Cells[4].Value = tempfile;
                        f.Cells[2].Value = "-1";
                        //f.Cells[3].Value = "FFFFFF04";
                        //non-track SEP value will always restart.
                        f.Cells[3].Value = sep_min.ToString("X8");
                    }
                }
            }
            if (File.Exists(s2spath))
            {
                //bool dosemu = File.Exists(txtDOSEMU.Text);
                //bool dosemu = tempfn;
                Process seq2sep = new Process();
                foreach (int v in psflib.Values)
                {
                    //dgvFiles.Rows[v].Cells[0].Value = Path.GetDirectoryName(dgvFiles.Rows[v].Cells[0].Value.ToString()) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(dgvFiles.Rows[v].Cells[0].Value.ToString()) + ".sep";
                    if (dosemu)
                    {
                        seq2sep.StartInfo.FileName = Path.GetFullPath(dospath);
                        seq2sep.StartInfo.Arguments = '"' + Path.GetFullPath(s2spath) + '"' + dgvFiles.Rows[v].Cells[4].Value.ToString();
                        //seq2sep.StartInfo.Arguments = '"' + Path.GetFullPath(txtSeq2Sep.Text) + '"' + " -o " + '"' + dgvFiles.Rows[v].Cells[0].Value.ToString() + '"' + " " + dgvFiles.Rows[v].Cells[4].Value.ToString();

                        MessageBox.Show(seq2sep.StartInfo.Arguments, seq2sep.StartInfo.FileName);
                        //seq2sep.StartInfo.FileName = "cmd.exe";
                        //seq2sep.StartInfo.Arguments = "/k " + '"' + Path.GetFullPath(txtDOSEMU.Text) + '"' + " " + '"' + Path.GetFullPath(txtSeq2Sep.Text) + '"' + " -o " + '"' + dgvFiles.Rows[v].Cells[0].Value.ToString() + '"' + " " + dgvFiles.Rows[v].Cells[4].Value.ToString();
                        
                    }
                    else
                    {
                        MessageBox.Show(seq2sep.StartInfo.Arguments, seq2sep.StartInfo.FileName);
                        seq2sep.StartInfo.FileName = Path.GetFullPath(s2spath);
                        //seq2sep.StartInfo.Arguments = " -o " + '"' + dgvFiles.Rows[v].Cells[0].Value.ToString() + '"' + " " + dgvFiles.Rows[v].Cells[4].Value.ToString();
                        seq2sep.StartInfo.Arguments = dgvFiles.Rows[v].Cells[4].Value.ToString();
                    }
                    try
                    {
                        seq2sep.Start();
                        seq2sep.WaitForExit();
                    } 
                    catch (Exception px)
                    {
                        sbiStatusText.Text = px.Message;
                    }
                    //need to get random filename here and copy the files to the working directorty with that filename. 
                }
                /*
                seq2sep.StartInfo.FileName = txtSeq2Sep.Text;
                seq2sep.StartInfo.Arguments = "z:\\account.txt";
                seq2sep.Start();
                seq2sep.WaitForExit();
                */
                //MessageBox.Show("exe done");
            } 
            else
            {

            }
        }
        public string Base64Hash (string file)
        {
            
            
            try
            {
                SHA256 hash = SHA256.Create();
                FileStream reader = new FileStream(file, FileMode.Open, FileAccess.Read);
                byte[] hashbin = hash.ComputeHash(reader);
                return Convert.ToBase64String(hashbin);
            } 
            catch
            {
                throw;
            }
            //return "";
        }

        public string FindVhVb (string s, string ext)
        {
            try
            {
                if (File.Exists(Path.GetDirectoryName(s) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(s) + ext))
                {
                    return Path.GetDirectoryName(s) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(s) + ext;

                }
                else
                {
                    foreach (string t in Directory.GetFiles(Path.GetDirectoryName(s), ext, SearchOption.AllDirectories))
                    {
                        return t;
                    }
                }
            }
            catch
            {
                throw;
            }
            return "";
        }

        public string TruncateString (string s, int l)
        {
            if (s.Length <= l)
            {
                return s;
            } else
            {
                return s.Substring(0, l);
            }
        }

        public void SaveCsvFile(string filename, int index, DataGridView dgvFiles, ToolStripStatusLabel sbiStatusText)
        {
            try
            {
                dgvFiles.AllowUserToAddRows = false; //stops the empty row at the end from getting into the csv
                vfsRecord rec = new vfsRecord { };
                StreamWriter stream = new StreamWriter(filename, false);
                CsvConfiguration csv = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture);
                csv.HasHeaderRecord = false;
                csv.ShouldQuote = args => false;
                CsvWriter writer = new CsvWriter(stream, csv);
                //writer.Configuration.HasHeaderRecord = false;
                foreach (DataGridViewRow r in dgvFiles.Rows)
                {
                    //would have used integers for these but oh well
                    rec.stack = r.Cells[3].Value.ToString();
                    rec.source = r.Cells[2].Value.ToString();
                    rec.intname = '"' + r.Cells[1].Value.ToString() + '"';
                    rec.extname = '"' + r.Cells[0].Value.ToString() + '"';
                    writer.WriteRecord(rec);
                    writer.NextRecord();

                }
                writer.Flush();
                writer.Dispose();
                dgvFiles.AllowUserToAddRows = true;
            } 
            catch (Exception xx)
            {
                sbiStatusText.Text = xx.Message;
            }
        }

    }

    public class vfsRecord
    {
        public string stack { get; set; }
        public string source { get; set; }
        public string intname { get; set; }
        public string extname { get; set; }
    }
}
