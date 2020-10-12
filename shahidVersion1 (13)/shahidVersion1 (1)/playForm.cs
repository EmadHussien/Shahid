using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shahidVersion1
{
    public partial class playForm : Form
    {
        string _url; int ID , vipFlag;
        public string VideoID
        {
            get
            {
                var yMatch = new Regex(@"http(?:s?)://(?:www\.)?youtu(?:be\.com/watch\?v=|\.be/)([\w\-]+)(&(amp;)?[\w\?=]*)?").Match(_url);
                return yMatch.Success ? yMatch.Groups[1].Value : String.Empty;

            }
        }

        public playForm(int id , int vip)
        {
            InitializeComponent();
            this.ID = id;
            this.vipFlag = vip;
            if (vipFlag != 0)
                openVideo();
            else if (vipFlag == 0 && (ID == 2 || ID == 5 || ID == 10))
            {
                MessageBox.Show("This Content Is Not Free");
            }
            else if (vipFlag == 0 && (ID != 2 || ID != 5 || ID != 10))
                openVideo();
                
        }


        string[] Movielinks = new string[]
        {
            "https://www.youtube.com/watch?v=UVtaf7p1QV4",
            "https://www.youtube.com/watch?v=j2QjHei1zV8",
            "https://youtu.be/3OR0vkiJ69c",
            "https://www.youtube.com/watch?v=s28m79VkWYI",
            "https://www.youtube.com/watch?v=vqSVTCREx8M", 
            "https://www.youtube.com/watch?v=r3mlYJEMMbg",
            "https://www.youtube.com/watch?v=dOu2yIrrBD8",
            "https://www.youtube.com/watch?v=7ZsGOyWWj6k",
            "https://www.youtube.com/watch?v=XAXwnt9Pj80&t=3887s",
            "https://www.youtube.com/watch?v=cSiGQFV4ViI",
            "https://www.youtube.com/watch?v=N4Ms6Peqw_Q",
            "https://www.youtube.com/watch?v=OkmZIxhoyLI"

        };
        
        

        private void openVideo()
        {
     
            _url = Movielinks[ID - 1];

            webBrowser1.DocumentText = String.Format("<html><head>" +
                    "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
                    "</head><body>" +
                    "<iframe width=\"100%\" height=\"840\" src=\"https://www.youtube.com/embed/{0}?autoplay=1\"" +
                    "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
                    "</body></html>", VideoID);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void playForm_Load(object sender, EventArgs e)
        {

        }
    }
}
