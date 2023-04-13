namespace FileHandelingApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String val = comboBox1.SelectedItem.ToString();
            System.IO.DriveInfo dinfo = new System.IO.DriveInfo(val);
            textBox3.Text = "Drive: " + val + 
                "\n Total Size:"+ dinfo.TotalSize +
                "\n Free Space:" + dinfo.AvailableFreeSpace;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String path = textBox1.Text;
                System.IO.DirectoryInfo sudir = new DirectoryInfo(textBox1.Text);
                String subname = textBox4.Text;
                sudir.CreateSubdirectory(subname);
                MessageBox.Show("SubDirectory has successfully created");
            }
            catch (Exception ram)
            {
                MessageBox.Show(ram.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox1.Text))
            {
                Directory.CreateDirectory(textBox1.Text);
                MessageBox.Show("Directory created");
            }
            else
            {
                MessageBox.Show("Please Enter correct directory path and File name");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = textBox2.Text;
            if (Directory.Exists(path))
            {
                string[] subdirs = Directory.GetDirectories(path);
                textBox5.Text = string.Join(Environment.NewLine, subdirs);
            }
            else
            {
                MessageBox.Show("Invalid path");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(textBox6.Text, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                String str = sr.ReadToEnd();
                int i = (str.IndexOf(textBox8.Text, 0));
                if (i > -1)
                {
                    MessageBox.Show("This word exist's in the file");
                }
                else
                {
                    MessageBox.Show("This word doesn't exist's in the file....try another words");
                }
            }
            catch (Exception ram)
            {
                MessageBox.Show(ram.Message);
            }
        
    }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(textBox6.Text, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(textBox10.Text);
                sw.Flush();
                fs.Close();
                MessageBox.Show("Content is written in file successfully");
            }
            catch (Exception ram)
            {
                MessageBox.Show(ram.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                String str = textBox6.Text;
                StreamWriter sw = File.AppendText(str);
                sw.WriteLine(textBox7.Text);
                sw.Close();
                MessageBox.Show("File contents appended successfully");
            }
            catch (Exception ram)
            {
                MessageBox.Show(ram.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Boolean binary = radioButton1.Checked;
            Boolean text = radioButton2.Checked;
            String Location = textBox6.Text;

            if (binary)
            {
                // Read binary data from file
                byte[] readBytes = File.ReadAllBytes(Location);
                string readValue = System.Text.Encoding.UTF8.GetString(readBytes);
                textBox9.Text = readValue;

            }
            else
            {
                try
                {
                    FileStream fs = new FileStream(textBox6.Text, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    textBox9.Text = sr.ReadToEnd();
                    MessageBox.Show(textBox9.Text);
                    fs.Close();
                }
                catch (Exception ram)
                {
                    MessageBox.Show(ram.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}