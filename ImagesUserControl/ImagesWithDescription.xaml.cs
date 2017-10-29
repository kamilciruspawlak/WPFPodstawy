using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImagesUserControl
{
    /// <summary>
    /// Interaction logic for ImagesWithDescription.xaml
    /// </summary>
    public partial class ImagesWithDescription : UserControl
    {
        private double _szerokosc;
        public double Szerokosc {
            get
            {
                return _szerokosc;
            }
            set
            {
                _szerokosc = value;
                this.Width = _szerokosc / 2;
            }
        }

        private string _blur;
        public string Blur
        {
            get
            {
                return _blur;
            }
            set
            {
                _blur = value;
                switch (_blur)
                {
                    case "off":
                        this.blurek.Radius = 0;
                        break;
                    case "medium":
                        this.blurek.Radius = 2;
                        break;
                    case "full":
                        this.blurek.Radius = 6;
                        break;
                    default:
                        this.blurek.Radius = 1;
                        break;
                }
            }
        }


        public ImagesWithDescription()
        {

            InitializeComponent();
        }
    }
}
