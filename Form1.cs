using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using QRCoder;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using System.Globalization;

namespace QRCodeGenerator
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "ENTER YOUR DOMAIN ADDRESS");
        private void go_Click(object sender, EventArgs e)
        {
            using (var searcher = new PrincipalSearcher(new UserPrincipal(principalContext)))
            {
                UserPrincipal userPrincipal = new UserPrincipal(principalContext);
                userPrincipal.SamAccountName = samAccountNameTextBox.Text;
                searcher.QueryFilter = userPrincipal;
                var result = searcher.FindOne();
                if (result != null)
                {
                    DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;           
                    string n = $"N:{de.Properties["sn"].Value};{de.Properties["givenName"].Value};;;";
                    string fn = $"FN:{de.Properties["cn"].Value}";                   
                    string org = $"ORG:{de.Properties["company"].Value};";
                    string title = $"TITLE:{de.Properties["title"].Value}";
                    string extention = de.Properties["telephoneNumber"].Value?.ToString();
                    string mobileCell = $"TEL;TYPE=cell:{de.Properties["mobile"].Value}";
                    string mail = $"EMAIL;TYPE=internet:{de.Properties["mail"].Value}";
                   
                    //address
                    string street = de.Properties["streetAddress"].Value?.ToString();
                    string city = de.Properties["l"].Value?.ToString();
                    string state = de.Properties["st"].Value?.ToString();
                    string postalCode = de.Properties["postalCode"].Value?.ToString();
                    string country = de.Properties["co"].Value?.ToString();

                    // Build the Address String
                    string address = $"ADR:;;{street};{city};{state};{postalCode};{country}";

                    // Construct vCard
                    List<string> vCardLines = new List<string>
                    {
                        "BEGIN:VCARD",
                        "VERSION:3.0",
                        n,
                        fn,
                        org,
                        title,
                        address,
                        mobileCell, 
                        mail, 
                      
                    };
                    vCardLines.Add("END:VCARD");

                    string vCard = string.Join(Environment.NewLine,vCardLines);
                    // Display in TextBox
                    informationsTextBos.Multiline = true;
                    informationsTextBos.Text = vCard;
                    // Generate QR Code
                    GenerateQRCode(vCard.ToString());
                }
                else
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenerateQRCode(dynamic vCardData)
        {
            using (QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator())
            {
                using (QRCodeData qRCodeData = qrGenerator.CreateQrCode(vCardData,QRCoder.QRCodeGenerator.ECCLevel.Q))
                {
                    using (QRCode qr = new QRCode(qRCodeData))
                    {
                        string folderPath = Path.Combine(Environment.CurrentDirectory, "qrcodes");
                        Directory.CreateDirectory(folderPath); 
                        string filePath = Path.Combine(folderPath, $"{samAccountNameTextBox.Text}_vcard_qr.png");
                        Bitmap qrCodeImage = qr.GetGraphic(20);
                        qrCodeImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                        Bitmap resizedQR = new Bitmap(qrCodeImage, pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.Image = resizedQR;    
                        MessageBox.Show($"QR Code saved as {samAccountNameTextBox.Text}_vcard_qr.png", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
        }
    }
}
