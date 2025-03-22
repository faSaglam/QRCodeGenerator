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


        PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "yph.inc");

     

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
                    string org = $"ORG:YILPORT HOLDING - COREX PORTS & TERMINALS";
                    string title = $"TITLE:{de.Properties["title"].Value}";
                    string corexAdr = "ADR:;;Professor W.H. Keesomlaan 5\\,;Amstelveen;;1183 DJ;The Netherlands";
                    string extention = de.Properties["telephoneNumber"].Value?.ToString();
                    string maslakVoice = $"TEL;TYPE=work;{extention}:+90 212 290 30 80";
                    string dilovasiVoice = $"TEL;TYPE=work;{extention}:+90 262 679 76 00";
                    string mobileCell = $"TEL;TYPE=cell:{de.Properties["mobile"].Value}";
                    string yilportMail = $"EMAIL;TYPE=internet:{de.Properties["mail"].Value}";
                    string corexMail = $"EMAIL;TYPE=internet:{samAccountNameTextBox.Text}@corexholding.com";
                    string urlYilport = "URL:www.yilport.com";
                    string urlCorex = "URL:www.corexports.com";
                    //address
                    string street = de.Properties["streetAddress"].Value?.ToString();
                    string city = de.Properties["l"].Value?.ToString();
                    string state = de.Properties["st"].Value?.ToString();
                    string postalCode = de.Properties["postalCode"].Value?.ToString();
                    string country = de.Properties["co"].Value?.ToString();

                    // Build the Address String
                    string address = $"ADR:;;{street};{city};{state};{postalCode};{country}";


                    //dail number
                    var dailCity = city.ToLower(new CultureInfo("en-GB"));
                    string dailNumber;
                    switch (dailCity)
                    {
                        case "istanbul":
                            dailNumber = maslakVoice;
                            break;
                        case "dilovasi":
                             dailNumber = dilovasiVoice;
                            break;
                        case "kocaeli":
                            dailNumber = dilovasiVoice;
                            break;
                        default:
                            dailNumber = "";
                            break;
                    }
                    // Construct vCard
                    List<string> vCardLines = new List<string>
                    {
                        "BEGIN:VCARD",
                        "VERSION:3.0",
                        n,
                        fn,
                        org,
                        title,
                        address, // Always include default address
                        mobileCell,
                        dailNumber,
                        yilportMail, // Always include Yilport email
                        urlYilport
                    };
               
                    if(corexCheckBox.Checked)
                    {
                        vCardLines.Add(corexAdr);
                        vCardLines.Add(corexMail);
                        vCardLines.Add(urlCorex);
                    }
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
                        Directory.CreateDirectory(folderPath); // Klasör yoksa oluþtur

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
