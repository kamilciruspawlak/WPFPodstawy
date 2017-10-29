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

namespace OurDependencyProperty
{
    /// <summary>
    /// Interaction logic for ImagesWithDescription.xaml
    /// </summary>
    public partial class ImagesWithDescription : UserControl
    {

        #region properties
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
        #endregion


        // private List<OurImage> _imagesSource;
        public List<OurImage> ImagesSource {
            get
            {
                return (List<OurImage>)GetValue(ImagesSourceProperty);
            }
            set
            {
                SetValue(ImagesSourceProperty, value);
            }
        }
        // ImagesSource trzeba powiazac z zwyklym property poprzez rejestracje
        public static readonly DependencyProperty ImagesSourceProperty = DependencyProperty.Register(
            "ImagesSource", // nazwa naszego zwyklego property
            typeof(List<OurImage>), //typ jaki jest zwracany przez nasze zwykle property
            typeof(ImagesWithDescription), // klasa w ktorej znajduje sie nasze property
            new FrameworkPropertyMetadata(null,new PropertyChangedCallback((dependencyObject,dependencyPropertyChangedEventArgs)=> {
                // jest to wywolanie anonimowej funkcji
                // dependencyObject - zrdolo wywolania (ImagesWithDescription)
                // dependncyPropertyEventArgs - wlasciwosc ktora zostala zmieniona (ImageSource)
                var source = dependencyObject as ImagesWithDescription;
                source.itemsControl.ItemsSource = (List<OurImage>) dependencyPropertyChangedEventArgs.NewValue;
            }))
            );

        public ImagesWithDescription()
        {

            InitializeComponent();
        }
    }
}
