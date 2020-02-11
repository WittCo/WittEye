using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaptiveVision;
using AvlNet;

namespace WindowsFormsApp1
{
    class we_vision
    {
        //Variable

        NullableRef<AvlNet.Image> image = AvlNet.Nullable.Create<AvlNet.Image>();
        NullableRef<AvlNet.Image> image2 = AvlNet.Nullable.Create<AvlNet.Image>();
       

     
        private ProgramMacrofilters macros;

        //Metoden

        public void CamConfig()
        {
         
        }

        public void GetCamIMG()
        {
          
        }

        /*private void DrawImage()
        {
            if (image.HasValue == true & image2.HasValue == true)
            {
                ImgBox.Image?.Dispose();

                ImgBox.Image = image.Value.CreateBitmap(); //Image -> Bitmap

                Imbox2.Image?.Dispose();

                Imbox2.Image = image2.Value.CreateBitmap(); //Image -> Bitmap

                //   macros.RectifyFusion(image, image2, true, image3);

                pictureBox1.Image = image3.Value.CreateBitmap();


            }

       

        private void AcquireImage2()
        {

            long? BildID, BildID2, timebild, timebild2;
            bool a1, a2;

            //  macros.Kamera_Vorne_Unten(camIPText.Text, true, image, out BildID,out timebild,out a1); //Hole Bild von IP
            // macros.Kamera_Vorne_Oben(camIPText2.Text, true, image2, out BildID2, out timebild2, out a2);


            macros.ResetKamera_Vorne_Unten();
            macros.ResetKamera_Vorne_Oben();
            // macros.ResetRectifyFusion();

            ToConsole(String.Format("Neue Aufname geholt"));
            GC.Collect(); //Garbage Collector Call
                          //  label42.Text = BildID.ToString();
                          //  label67.Text = BildID2.ToString();
                          //  label68.Text = timebild.ToString();
                          // label69.Text = timebild2.ToString();
                          // label70.Text = a1.ToString();
                          // label71.Text = a2.ToString();




        }


        private bool AcquireImage()
        {
            try
            {
                image = AvlNet.Nullable.Create<AvlNet.Image>(); //Nullbare Image-Objekt-Referenz
                image2 = AvlNet.Nullable.Create<AvlNet.Image>();

                int buldZahl2;

                //   macros.Kamera_Vorne_Unten(camIPText.Text, true, image, out buldZahl2); //Hole Bild von IP
                //  macros.Kamera_Vorne_Oben(camIPText2.Text, true, image2);

                ToConsole(String.Format("Neue Aufname geholt"));
                ImgBox.Image?.Dispose();
                if (image != null)
                    ImgBox.Image = image.Value.CreateBitmap(); //Image -> Bitmap
                else
                    ToConsole("Bild null");

                Imbox2.Image?.Dispose();
                if (image2 != null)
                    Imbox2.Image = image2.Value.CreateBitmap(); //Image -> Bitmap
                else
                    ToConsole("Bild null");


                if (image.Value.Height == 2748)
                {
                    // macros.RectifyFusion(image, image2, true, image3);
                    pictureBox1.Image = image3.Value.CreateBitmap();

                }


                macros.ResetKamera_Vorne_Unten();
                macros.ResetKamera_Vorne_Oben();

                GC.Collect(); //Garbage Collector Call
                /*


                                checkBox12.Checked = true;

                                //Hahnerkenung(image3);


                              
                return true;

            }



            catch (Exception e)
            {
                ToConsole("Bildakquirierung nicht möglich!: " + e.Message);
                image = null;
                image2 = null;
                return false;
            }


        }
 
        */
 
    }
}
