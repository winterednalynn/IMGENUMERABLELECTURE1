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
using Microsoft.Win32;

namespace IMGENUMERABLELECTURE
{//EDNA LYNN LAXA 
 //MARCH 11, 2023 
 //LECTURE 13 , IMAGE  
 //CSI PROGRAMMING II 

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Insta> myInstas = new List<Insta>(); 
        public MainWindow()
        {
            InitializeComponent();
            PreloadListOfpicture();
            DisplayImage(myInstas[0]);
            AddingAnImageToYourControlAndGoingGrey();



        }
    
        public void PreloadListOfpicture ()
        {
            //GET IMAGE ADDRESS 
            string filePath = @"C:\Users\allan\OneDrive\Desktop\FLOWER.jpg";

            Insta Flower = new Insta(filePath, "Flower");
            myInstas.Add(Flower);

           

            string filePath2 = @"C:\Users\allan\OneDrive\Desktop\dreamworld.jpg";

            Insta DreamWorld = new Insta(filePath2, "Dreamy");
            myInstas.Add(DreamWorld); 

       
            //ATTACH BITMAPIMAGE TO IMAGE.SOURCE 
            imgDisplay.Source = CreateBitMapImage(filePath);

        }
        public void DisplayImage(Insta insta)
        {
            imgDream.Source = insta.Image ;
            lblSecondImg.Content = insta.Content;

            imgDream.Source = insta.Image;
            lblSecondImg.Content = insta.Content;
        }
        public void AddingAnImageToYourControlAndGoingGrey()
        {
            // Open file diagloug
            OpenFileDialog op = new OpenFileDialog();
            string filePath = "";
            if (op.ShowDialog() == true)
            {
                filePath = op.FileName;
            }


            // THE FILE PATH: 
            //string filePath =@"C:\Users\allan\OneDrive\Desktop\FLOWER.jpg";

            // URI STRUCTURE 
            Uri uri = new Uri(filePath);

            // URI INTO BITMAP 
            BitmapImage bitmap = new BitmapImage(uri);

            // -> Attach to image.source
            //imgDisplay.Source = bitmap;

            // CHANGE TO GREYSCALE
            // Create new FormatConvertBitmap

            FormatConvertedBitmap grey = new FormatConvertedBitmap();
            
            // Begin Init
            grey.BeginInit();
            
            // Source = BitMapImage
            grey.Source = bitmap;
            
            // Destination
            grey.DestinationFormat = PixelFormats.Gray32Float;

            //newFormatedBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            // End Init
            grey.EndInit();

            // ATTACHES TO IMAGE SOURCE 
            imgDisplay.Source = grey;
        }

            public BitmapImage CreateBitMapImage(string filepath)
        {
            ////CREATE NEW URI OBJECT 
            //Uri uri = new Uri(filePath);

            ////STORES IN BITMAPIMAGE 
            //BitmapImage bitmap = new BitmapImage(uri);

            return new BitmapImage(new Uri(filepath)); 


            //PASS IN FILE ADRESS 
            //PASS IN URI TO BITMAP 
        }
      


        private void btnDisplayImg_Click(object sender, RoutedEventArgs e)
        {

            //BUILT IN TO .NET , A file explorer dialog , pick up file addresses 
            OpenFileDialog op= new OpenFileDialog(); //Opens file

            // This will be placed on the upper left header of the file. 
            op.Title = "Select a picture"; 
            
            //This sorts only files w/ jpg , jpeg, .png ; * = anything that consist of 
            //Opens a dialogue to find a path to a file 
            op.Filter = "All supported graphics| *.jpg; *.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpege)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png) | *.png" ; 

            //When slecting button, it will open file. 
            if(op.ShowDialog() == true)
            {
                
                imgDisplay.Source = new BitmapImage(new Uri(op.FileName));

            }


        }
        
        public void OpenImageTest()
        {
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.InitialDirectory = "c:\\";
            //dlg.Filter = "Image files (*.jpg)|*.jpg|All Files(*.*)|*.*";
            //dlg.RestoreDirectory = true; 

            //if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    string selectedFileName = dlg.FileName;
            //    FileNameLabel.Content = selectedFileName;

            //    //In order to get a bitmap, "image?" start here. 
            //    BitmapImage bitmap = new BitmapImage();
            //    bitmap.BeginInit();
            //    bitmap.UriSource = new Uri(selectedFileName);
            //    bitmap.EndInit();

            //    // This probably will display our image in our img ctrl. 
            //    imgDisplay.Source = bitmap; 
            //}

            //==================================================================

            // To get a bitmap "image" initiate: 

            //BitmapImage bitmap = new BitmapImage();
            //bitmap.BeginInit();

            ////Place an image location in url 
            //bitmap.UriSource = new Uri("IMG_2574.jpg");
            //bitmap.EndInit();

            ////Maybe display our image to our image control o
            //imgDisplay.Source = bitmap; 
        }
        private void Breakdown()
        {

            //BUILT IN TO .NET , A file explorer dialog , pick up file addresses 
            OpenFileDialog op = new OpenFileDialog(); //Opens file

            // This will be placed on the upper left header of the file. 
            op.Title = "Select a picture";

            //This sorts only files w/ jpg , jpeg, .png ; * = anything that consist of 
            //Opens a dialogue to find a path to a file 
            op.Filter = "All supported graphics| *.jpg; *.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpege)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png) | *.png";

            //When slecting button, it will open file. 
            if (op.ShowDialog() == true)
            {
                string filePath = op.FileName;

                lblFilePath.Content = filePath;
                imgDisplay.Source = new BitmapImage(new Uri(filePath));

            }
        }

    }
}
