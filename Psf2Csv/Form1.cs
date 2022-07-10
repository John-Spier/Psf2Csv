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
                SaveCsvFile(sfdSaveList.FileName, sfdSaveList.FilterIndex);
                
            }
            
        }

        private void dgvFiles_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Int32 t = 0;
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
                AddPsfSet(fbdAddPsf.SelectedPath);
            }
        }

        public void AddPsfSet (string dir)
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
                    vab[6] = Base64Hash(vab[7]);
                    dgvFiles.Rows.Add(vab);
                } catch (Exception cx)
                {
                    sbiStatusText.Text = cx.Message;
                }
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

        public void SaveCsvFile(string filename, int index)
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

                    rec.stack = (string)r.Cells[3].Value;
                    rec.source = (string)r.Cells[2].Value;
                    rec.intname = '"' + (string)r.Cells[1].Value + '"';
                    rec.extname = '"' + (string)r.Cells[0].Value + '"';
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
