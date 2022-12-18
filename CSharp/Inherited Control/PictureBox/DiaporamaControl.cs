using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;
using Accord.Video.FFMPEG;
using System.IO;

namespace Diaporama
{
    public class DiaporamaControl : PictureBox
    {
        private List<Image> _images;
        private int _currentImageIndex;
        private System.Timers.Timer _timer;
        private Button _previousButton;
        private Button _nextButton;

        public DiaporamaControl()
        {
            _images = new List<Image>();
            _currentImageIndex = 0;

            // Configurez ici la durée entre chaque image en utilisant la propriété Interval de l'objet Timer
            _timer = new System.Timers.Timer(5000);
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();

            // Créez les boutons "Précédent" et "Suivant" et ajoutez-les au contrôle
            _previousButton = new Button();
            _previousButton.Text = "Précédent";
            _previousButton.Click += PreviousButton_Click;
            this.Controls.Add(_previousButton);

            _nextButton = new Button();
            _nextButton.Text = "Suivant";
            _nextButton.Click += NextButton_Click;
            this.Controls.Add(_nextButton);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Vérifiez si vous avez atteint la fin de la liste d'images
            if (_currentImageIndex == _images.Count - 1)
            {
                _currentImageIndex = 0;
            }
            else
            {
                _currentImageIndex++;
            }

            // Mettez à jour l'image affichée dans le contrôle PictureBox en utilisant la propriété Image
            this.Image = _images[_currentImageIndex];
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            // Vérifiez si vous êtes au début de la liste d'images
            if (_currentImageIndex == 0)
            {
                _currentImageIndex = _images.Count - 1;
            }
            else
            {
                _currentImageIndex--;
            }

            // Mettez à jour l'image affichée dans le contrôle PictureBox en utilisant la propriété Image
            this.Image = _images[_currentImageIndex];
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            // Vérifiez si vous avez atteint la fin de la liste d'images
            if (_currentImageIndex == _images.Count - 1)
            {
                _currentImageIndex = 0;
            }
            else
            {
                _currentImageIndex++;
            }

            // Mettez à jour l'image affichée dans le contrôle PictureBox en utilisant la propriété Image
            this.Image = _images[_currentImageIndex];
        }
        public void SaveAsVideo(string outputFilePath, int framesPerSecond)
        {
            // Vérifiez que la liste d'images n'est pas vide
            if (_images.Count == 0)
            {
                throw new InvalidOperationException("Il n'y a aucune image dans le diaporama.");
            }

            // Créez un objet VideoFileWriter en spécifiant le chemin du fichier de sortie, la résolution de l'image et la fréquence d'images par seconde
            using (var writer = new VideoFileWriter())
            {
                writer.Open(outputFilePath, _images[0].Width, _images[0].Height, framesPerSecond);

                // Écrivez chaque image dans le fichier de sortie
                foreach (var image in _images)
                {
                    writer.WriteVideoFrame(image);
                }
            }
        }

    }
}
