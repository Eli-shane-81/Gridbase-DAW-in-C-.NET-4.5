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
using System.Data.SqlClient;
using NAudio;
using NAudio.Wave;
using NAudio.Midi;
using NAudio.Lame;
using NAudio.Wave.SampleProviders; 

namespace btnObj
{
    public partial class PebbleTap : Form
    {
        const int rows = 13;  
        const int cols = 50;   
        Button[,] pads = new Button[rows, cols];
        bool[,] isActive = new bool[rows, cols];
        string[] soundPaths;
        long startTick = 0;
        int currentStep = 0;
        bool hasb, iswriten;
        private string albumFolderpath = "";

        public PebbleTap()
        {
            InitializeComponent();

            string soundF = Path.Combine(Application.StartupPath, "wav");
            soundPaths = new string[]
            {
                Path.Combine(soundF, "a1.wav"),
                Path.Combine(soundF, "a1s.wav"),
                Path.Combine(soundF, "b1.wav"),
                Path.Combine(soundF, "c1.wav"),
                Path.Combine(soundF, "c1s.wav"),
                Path.Combine(soundF, "c2.wav"),
                Path.Combine(soundF, "d1.wav"),
                Path.Combine(soundF, "d1s.wav"),
                Path.Combine(soundF, "e1.wav"),
                Path.Combine(soundF, "f1.wav"),
                Path.Combine(soundF, "f1s.wav"),
                Path.Combine(soundF, "g1.wav"),
                Path.Combine(soundF, "g1s.wav")
            };
        }

        private void PlaySound(string path)
        {
            try
            {
                var reader = new AudioFileReader(path);
                var outputDevice = new WaveOutEvent();
                outputDevice.Init(reader);
                outputDevice.Play();

                outputDevice.PlaybackStopped += (s, e) =>
                {
                    outputDevice.Dispose();
                    reader.Dispose();
                };
            }
            catch (Exception)
            {
                // MessageBox.Show("Sound PATH error : " + ex.Message);
            }
        }

        private void ResetStepHighlight(bool newClick)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    pads[row, col].BackColor = isActive[row, col] ? Color.LightGreen : SystemColors.Control;
                    if (hasb == true)
                    { pads[row, col].BackColor = isActive[row, col] ? Color.LightGreen : Color.DarkGray; }
                    if (newClick == true)
                    {
                        isActive[row, col] = false;
                        pads[row, col].BackColor = hasb ? Color.DarkGray : SystemColors.Control;
                    }
                }
            }
        }
        
        private void Form1_Load(object sender, EventArgs e) 
        {
            int padSize = 60;
            int margin = 1;
            
            tblL.RowCount = rows;
            tblL.ColumnCount = cols;
            tblL.Controls.Clear();
            tblL.RowStyles.Clear();
            tblL.ColumnStyles.Clear();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Button pad = new Button();
                    pad.Size = new Size(padSize, padSize);
                    pad.Text = "";
                    pad.BackColor = SystemColors.Control;
                    pad.Margin = new Padding(margin / 1);
                    pad.Height = 39;
                    int rr = r, cc = c;
                    pad.Click += (s, ee) =>
                    {
                        isActive[rr, cc] = !isActive[rr, cc];
                        pad.BackColor = isActive[rr, cc] ? Color.LightGreen : SystemColors.Control;
                        iswriten = true;
                    };
                    pads[r, c] = pad;
                    isActive[r, c] = false;
                    tblL.Controls.Add(pad, c, r);
                }
            }
        } 

        private void StepTimer_Tick(object sender, EventArgs e)
        {
            ResetStepHighlight(false);
            for(int row = 0; row < rows; row++)
            {
                Button pad = pads[row, currentStep];
                if (isActive[row, currentStep])
                {
                    pad.BackColor = Color.LimeGreen;
                    if (row < soundPaths.Length)
                    {
                        PlaySound(soundPaths[row]);
                    }
                }
                else
                {
                    pad.BackColor = Color.LightGray;
                    if (hasb == true)
                    { pad.BackColor = Color.WhiteSmoke; }
                }
            }
            currentStep = (currentStep + 1) % cols;
        }

        private void btnplaystop_Click(object sender, EventArgs e)
        {
            if (btnplaystop.Text == "Play")
            {
                currentStep = 0;
                StepTimer.Start();
                btnplaystop.Text = "Stop";
            }
            else
            {
                btnplaystop.Text = "Play";
                StepTimer.Stop();
            }
        }

        private void btnfin_Click(object sender, EventArgs e)
        { 
            exportToolStripMenuItem.Enabled = true;
            btnfin.Enabled = false;
            btnplaystop.Enabled = false;
            tblL.Enabled = false;
            StepTimer.Stop();
            btnplaystop.Text = "Play";
            ResetStepHighlight(false);
        }

        private void btnimprt_Click(object sender, EventArgs e)
        {
            if (btnimprt.Text == "Cancel") { tblL.Visible = true; dgv.Visible = false; btnimprt.Text = "Import"; label1.Visible = true; return; }
            if (DialogResult.Yes == MessageBox.Show("Do you want to import from Server?", "Import Option", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                tblL.Visible = false;
                dgv.Visible = true;
                label1.Visible = false;
                btnimprt.Text = "Cancel";
                loadfromdb();
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "MIDI |*.mid";
                ofd.Title = "Select a file to Import";
                tealb.Clear();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    btnplaystop.Enabled = true;
                    btnfin.Enabled = true;
                    exportToolStripMenuItem.Enabled = false;
                    lblfilnm.Text = "File : "+Path.GetFileNameWithoutExtension(ofd.FileName);
                }
                importfromdb(null,true, ofd.FileName);
            }
            
        }

        private void midfordb(string strfilename, int extn)
        {
            SqlConnection con = new SqlConnection("Data Source=PC229; Initial Catalog=DAW;Integrated Security=True");
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("SELECT ISNULL(MAX(FileId), 0) + 1 FROM tblFile", con);
            int nextFileId = Convert.ToInt32(cmd.ExecuteScalar());
            cmd = new SqlCommand("INSERT INTO tblFile(Fileid,Filename, Filedata, FileType, isAct) VALUES (@fid,@fname, @fdata, @ftype,@isact)", con);
            try
            {
                using (MemoryStream midiStream = crtmid())
                {
                    byte[] midiBytes = midiStream.ToArray();

                    cmd.Parameters.AddWithValue("@fid", nextFileId);
                    cmd.Parameters.AddWithValue("@fname", Path.GetFileNameWithoutExtension(strfilename));
                    cmd.Parameters.AddWithValue("@fdata", midiBytes);
                    cmd.Parameters.AddWithValue("@ftype", extn);
                    cmd.Parameters.AddWithValue("isact", true);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in : " + ex.Message);
            }
            cmd = new SqlCommand("SELECT TOP 1 Fileid FROM tblFile WHERE isAct = 1 ORDER BY Fileid DESC;", con);
            albthings(tealb.Text.Trim(),(int)cmd.ExecuteScalar());
            cmd = new SqlCommand("DECLARE @fid INT; DECLARE @albid INT; UPDATE Album SET Fileid = @fid WHERE Albid = @albid AND Fileid IS NULL;", con);
            cmd.ExecuteScalar();
            con.Close();
        }

        private MemoryStream crtmid(string strfilename = null)
        {
            int ticksPerQuarterNote = 480;
            var midEvnt = new MidiEventCollection(1, ticksPerQuarterNote);
            // Track 0
            var track0 = new List<MidiEvent>();
            track0.Add(new TimeSignatureEvent(startTick, 4, 2, 24, 8));
            track0.Add(new TempoEvent(500000, 0));
            track0.Add(new TextEvent("Step Sequencer MIDI", MetaEventType.SequenceTrackName, 0));
            track0.Add(new MetaEvent(MetaEventType.EndTrack, 0, 0));
            midEvnt.AddTrack(track0);
            // Track 1
            var track1 = new List<MidiEvent>();
            int channel = 1;
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (isActive[row, col])
                    {
                        int time = col * ticksPerQuarterNote / 2;
                        int noteNumber = 60 + row * 2;

                        track1.Add(new NoteOnEvent(time, channel, noteNumber, 100, 0));
                        track1.Add(new NoteEvent(time + ticksPerQuarterNote / 4, channel, MidiCommandCode.NoteOff, noteNumber, 0));
                    }
                }
            }

            track1.Add(new MetaEvent(MetaEventType.EndTrack, 0, ticksPerQuarterNote * cols));
            midEvnt.AddTrack(track1);
            exportToolStripMenuItem.Enabled = false;

            if (!string.IsNullOrEmpty(strfilename))
            {
                MidiFile.Export(strfilename, midEvnt);
            }

            string tmpath = Path.GetTempFileName();
            MidiFile.Export(tmpath, midEvnt);

            byte[] midiBytes = File.ReadAllBytes(tmpath);
            File.Delete(tmpath);

            return new MemoryStream(midiBytes);
        }

        private void midToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog  SFD = new SaveFileDialog();
            SFD.Filter = "MIDI |*.mid";
            SFD.Title = "Export MIDI File";

            if (SFD.ShowDialog() == DialogResult.Cancel)
            {
                tblL.Enabled = true;
                btnplaystop.Enabled = true;
                btnfin.Enabled = true;
            }
            else
            {
                StepTimer.Stop();
                btnplaystop.Enabled = false;
                crtmid(SFD.FileName);
                midfordb(SFD.FileName, 1);
                if(DialogResult.OK == MessageBox.Show("File Saved!! ", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information))
                {
                    exportToolStripMenuItem.Enabled = false;
                }
            }
        }
        
        private void wavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "WAV |*.wav";
            SFD.Title = "Export WAV File";
            crtmid(SFD.FileName);
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                int sampleRate = 44100;
                int channels = 2;
                var waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels);
                var mixer = new MixingSampleProvider(waveFormat);

                int StepIntervalMs = (int)(60000.0 / trackBar1.Value / 4);
                for (int col = 0; col < cols; col++)
                {
                    double offsetSeconds = (col * StepIntervalMs) / 1000.0;
                    for (int row = 0; row < rows; row++)
                    {
                        if (isActive[row, col])
                        {
                            var reader = new AudioFileReader(soundPaths[row]);
                            var offsetSample = new OffsetSampleProvider(reader)
                            {
                                DelayBy = TimeSpan.FromSeconds(offsetSeconds)
                            };
                            mixer.AddMixerInput(offsetSample);
                        }
                    }
                }

                double totalDurationSec = ((cols * StepIntervalMs) / 1000.0) + 10;
                int bufferSize = 1024;
                float[] buffer = new float[bufferSize];
                int totalSamples = (int)(totalDurationSec * sampleRate);
                int writtenSamples = 0;

                using (var waveFile = new WaveFileWriter(SFD.FileName, waveFormat))
                {
                    while (writtenSamples < totalSamples)
                    {
                        int samplesRead = mixer.Read(buffer, 0, buffer.Length);
                        if (samplesRead == 0) break;
                        waveFile.WriteSamples(buffer, 0, samplesRead);
                        writtenSamples += samplesRead;
                    }
                }
                MessageBox.Show("File Saved!! ", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            midfordb(SFD.FileName, 2);
        }

        private void mp3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "MP3 |*.mp3";
            SFD.Title = "Export MP3 File";
            crtmid(SFD.FileName);
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                int sampleRate = 44100;
                int channels = 2;
                var MptreFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels);
                var mixer = new MixingSampleProvider(MptreFormat);

                int StepIntervalMs = (int)(60000.0 / trackBar1.Value / 4);
                for (int col = 0; col < cols; col++)
                {
                    double offsetSeconds = (col * StepIntervalMs) / 1000.0;
                    for (int row = 0; row < rows; row++)
                    {
                        if (isActive[row, col])
                        {
                            var reader = new AudioFileReader(soundPaths[row]);
                            var offsetSample = new OffsetSampleProvider(reader)
                            {
                                DelayBy = TimeSpan.FromSeconds(offsetSeconds)
                            };
                            mixer.AddMixerInput(offsetSample);
                        }
                    }
                }

                double totalDurationSec = ((cols * StepIntervalMs) / 1000.0) + 10;
                float[] buffer = new float[1024];
                int totalSamples = (int)(totalDurationSec * sampleRate);
                int writtenSamples = 0;

                using (var Mptre = new LameMP3FileWriter(SFD.FileName, WaveFormat.CreateIeeeFloatWaveFormat(44100, 2), LAMEPreset.STANDARD))
                {
                    while (writtenSamples < totalSamples)
                    {
                        int samplesRead = mixer.Read(buffer, 0, buffer.Length);
                        if (samplesRead == 0) { break; }
                        while ((samplesRead = mixer.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            // Convert float samples (32-bit) to bytes
                            byte[] byteBuffer = new byte[samplesRead * 4];
                            Buffer.BlockCopy(buffer, 0, byteBuffer, 0, byteBuffer.Length);
                            Mptre.Write(byteBuffer, 0, byteBuffer.Length);
                        }
                    }
                }
                MessageBox.Show("File Saved!! ", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            midfordb(SFD.FileName, 3);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iswriten)
            {
                if (DialogResult.Yes == MessageBox.Show("Sure you want to clear the selections ?", "Clear all?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    ResetStepHighlight(true);
                    StepTimer.Stop();
                    lblfilnm.Text = string.Empty;
                    trackBar1.Value = 120; 
                    lblt.Text = trackBar1.Value + " BPM"; 
                    iswriten = false;
                }
            }
            btnfin.Enabled = true; btnplaystop.Enabled = true; tblL.Enabled = true; exportToolStripMenuItem.Enabled = false;
        }

        private void thmD_Click(object sender, EventArgs e)
        {
            menStr.BackColor = ColorTranslator.FromHtml("#393636");
            menStr.ForeColor = Color.White;
            this.BackColor = ColorTranslator.FromHtml("#424242");
            lblfilnm.ForeColor = Color.White; lab.ForeColor = Color.White;
            lblt.ForeColor = Color.White; label1.ForeColor = Color.White; 
            hasb = true;
            ResetStepHighlight(false);
        }

        private void thmW_Click(object sender, EventArgs e)
        {
            menStr.BackColor = SystemColors.ControlLight;
            menStr.ForeColor = Color.Black;
            this.BackColor = SystemColors.Control;
            lblfilnm.ForeColor = Color.Black; lab.ForeColor = Color.Black;
            lblt.ForeColor = Color.Black; label1.ForeColor = Color.Black; 
            hasb = false;
            ResetStepHighlight(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (DialogResult.Yes == MessageBox.Show("Do you really want to quit the DAW?", "Hold On!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                { albumFolderpath = null;  Application.Exit(); }
        }

        private void btnstrt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tealb.Text))
            {
                MessageBox.Show("Enter Album name to create Album", "Create New Album", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            } tblL.Enabled = true; btnplaystop.Enabled = true; btnfin.Enabled = true;

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "Select location to create your album's folder";

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                albumFolderpath = Path.Combine(folderDialog.SelectedPath, tealb.Text.Trim());
                try
                {
                    if (!Directory.Exists(albumFolderpath))
                    {
                        Directory.CreateDirectory(albumFolderpath);
                    }
                    else
                    {
                        MessageBox.Show("Album already exists in this location", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information); tealb.Clear(); tealb.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating album folder: " + ex.Message);
                }
            }
            albthings(tealb.Text.Trim(), null);
        }
        
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int bpm = trackBar1.Value;
            int stepsPerBeat = 4;
            double beatDurationMs = 60000.0 / bpm;
            lblt.Text = bpm + " BPM";
            StepTimer.Interval = (int)(beatDurationMs / stepsPerBeat);
        }

        private void loadfromdb()
        {
            SqlConnection con = new SqlConnection("Data Source=PC229; Initial Catalog=DAW;Integrated Security=True");
            SqlDataAdapter datA = new SqlDataAdapter("SELECT f.Fileid, f.Filename, a.Albname FROM tblFile f JOIN Album a ON f.Fileid = a.Fileid", con); 
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                datA.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].HeaderText = "File Name"; dgv.Columns[2].HeaderText = "Album Name";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading files from Database!" + ex.Message);
            }
        }

        private void importfromdb(int? fileid, bool sysimp, string tempPath)
        {
            try
            {
                SqlConnection con = null;
                if (sysimp == false)
                {
                    con = new SqlConnection("Data Source=PC229; Initial Catalog=DAW;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("SELECT Filedata FROM tblFile WHERE Fileid = @fid", con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@fid", fileid);
                    byte[] fileBytes = (byte[])cmd.ExecuteScalar();

                    tempPath = Path.GetTempFileName();
                    File.WriteAllBytes(tempPath, fileBytes);
                    con.Close();
                }
                    MidiFile midifile = new MidiFile(tempPath, false);
                    int baseNote = 60;         
                    int noteStep = 2;    
                    int ticksPerStep = 240;

                    ResetStepHighlight(true);
                    foreach (var track in midifile.Events)
                    {
                        foreach (var midiEvent in track)
                        {
                            if (midiEvent.CommandCode == MidiCommandCode.NoteOn)
                            {
                                var noteOn = (NoteOnEvent)midiEvent;
                                if (noteOn.Velocity > 0)
                                {
                                    int row = (noteOn.NoteNumber - baseNote) / noteStep;
                                    int col = (int)(noteOn.AbsoluteTime / ticksPerStep);

                                    isActive[row, col] = true;
                                    pads[row, col].BackColor = Color.LightGreen;
                                    iswriten = true;
                                }
                            }
                        }
                    }
                    if (sysimp == false) { File.Delete(tempPath); }
            }
            catch (Exception) { MessageBox.Show("Failed to import the file, Please try again", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); lblfilnm.Text = ""; }
        }  

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int Filid = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Fileid"].Value);
                tealb.Text = dgv.Rows[e.RowIndex].Cells["Albname"].Value.ToString();
                string Filnm = dgv.Rows[e.RowIndex].Cells["Filename"].Value.ToString();
                importfromdb(Filid, false,Filnm);
                lblfilnm.Text = "File : " + Filnm;
            }
            tblL.Visible = true;
            dgv.Visible = false;
            btnimprt.Text = "Import";
            tblL.Enabled = true;
            label1.Visible = true; btnplaystop.Enabled = true; btnfin.Enabled = true;
        }

        private int albthings(string albname, int? newFileId)
        {
            int albid = 0;

            using (SqlConnection con = new SqlConnection("Data Source=PC229; Initial Catalog=DAW;Integrated Security=True"))
            {
                con.Open();

                string checkQry = "SELECT TOP 1 Albid FROM Album WHERE Albname = @albname ORDER BY Albid DESC";

                using (SqlCommand cmd = new SqlCommand(checkQry, con))
                {
                    cmd.Parameters.AddWithValue("@albname", albname);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        string insertNewAlbumQry = @"DECLARE @newAlbid INT; SELECT @newAlbid = ISNULL(MAX(Albid), 0) + 1 FROM Album; INSERT INTO Album (Albid, Albname, Fileid, isAct) VALUES (@newAlbid, @albname, NULL, 1); SELECT @newAlbid;";

                        using (SqlCommand cmd2 = new SqlCommand(insertNewAlbumQry, con))
                        {
                            cmd2.Parameters.AddWithValue("@albname", albname);
                            albid = (int)cmd2.ExecuteScalar();
                        }
                        return albid;
                    }
                    else
                    {
                        albid = (int)result;
                    }
                }

                if (newFileId == null)
                {
                    string insertEmptyRowQry = "INSERT INTO Album (Albid, Albname, Fileid, isAct) VALUES (@albid, @albname, NULL, 1);";

                    using (SqlCommand cmd = new SqlCommand(insertEmptyRowQry, con))
                    {
                        cmd.Parameters.AddWithValue("@albid", albid);
                        cmd.Parameters.AddWithValue("@albname", albname);
                        cmd.ExecuteNonQuery();
                    }

                    return albid;
                }

                string insertExportRowQry = @"INSERT INTO Album (Albid, Albname, Fileid, isAct) VALUES (@albid, @albname, @fileid, 1);";

                using (SqlCommand cmd = new SqlCommand(insertExportRowQry, con))
                {
                    cmd.Parameters.AddWithValue("@albid", albid);
                    cmd.Parameters.AddWithValue("@albname", albname);
                    cmd.Parameters.AddWithValue("@fileid", newFileId);
                    cmd.ExecuteNonQuery();
                }
                string qry = "Delete from Album where Fileid IS NULL;";
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    cmd.ExecuteNonQuery();
                }
                return albid;
            }
        }
    }
}