using System.Text;

namespace BidConReport.DesktopBridge;
public partial class Shell : Form
{
    public Shell()
    {
        InitializeComponent();
    }

    private void Shell_FormClosing(object sender, FormClosingEventArgs e)
    {
        if(e.CloseReason != CloseReason.ApplicationExitCall)
        {
            e.Cancel = true;
            Visible = false;
        }        
    }

    private void Shell_VisibleChanged(object sender, EventArgs e)
    {
        UpdateLog();
    }

    private void updateToolStripMenuItem_Click(object sender, EventArgs e)
    {
        UpdateLog();
    }

    private void UpdateLog()
    {
        var today = DateTime.Now.ToString("yyyyMMdd");
        var file = $"Logs/log{DateTime.Now.ToString("yyyyMMdd")}.txt";
        if (File.Exists(file))
        {
            using (var stream = File.Open($"Logs/log{DateTime.Now.ToString("yyyyMMdd")}.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream, Encoding.Default))
            {
                richTextBox1.Text = reader.ReadToEnd();
            }
        }
        
    }
}
