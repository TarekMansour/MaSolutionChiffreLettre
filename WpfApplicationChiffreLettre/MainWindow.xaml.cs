using ClassLibraryChiffreLettre;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Media;
using System.Windows.Media;
using System.Threading;//permet d'utiliser plus d'un thread d'exécution
using System.ComponentModel;
using System.Windows.Threading;
using word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;

namespace WpfApplicationChiffreLettre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        #region Declaration
        Score s1 = new Score();
        private SoundPlayer mySound = new SoundPlayer(@"E:\3 émé Genie info\semestre2\C#\TP_C#\ChiffreLettre\music\myGame.wav");
        private char[] TabConsonne = new char[] { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z' };
        private char[] TabVoyelle = new char[] { 'A', 'E', 'I', 'O', 'U', 'Y' };
        private bool btValiderWasClicked = false;
        private bool efaccerWasClicked = false;

        private bool RestartWasClicked = false;
        private bool VoyelleWasClicked = false;
        private bool ConsonnesWasClicked = false;
        private bool hasardWasClicked = false;



        public Button[] tabZoneA = new Button[9];

        int comp = 0;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            s1.valeur = 0;
        }

        #region Démarrage jeu

        public void remplir(Button[] tab)
        {
            tabZoneA[0] = btA1;
            tabZoneA[1] = btA2;
            tabZoneA[2] = btA3;
            tabZoneA[3] = btA4;
            tabZoneA[4] = btA5;
            tabZoneA[5] = btA6;
            tabZoneA[6] = btA7;
            tabZoneA[7] = btA8;
            tabZoneA[8] = btA9;
        }

        //bouton pour choisir aléatoirement une lettre voyelle 
        private void btVolyelle_Click(object sender, RoutedEventArgs e)
        {
            remplir(tabZoneA);
            Random rnd = new Random();
            tabZoneA[comp].FontSize = 20;
            tabZoneA[comp].Content = TabVoyelle[(char)(rnd.Next(0, TabVoyelle.Length))];
            comp++;
            VoyelleWasClicked = true;
        }

        //bouton pour choisir aléatoirement une lettre consonne
        private void btConsonne_Click(object sender, RoutedEventArgs e)
        {
            remplir(tabZoneA);
            Random rnd = new Random();
            tabZoneA[comp].FontSize = 20;
            tabZoneA[comp].Content = TabConsonne[(char)(rnd.Next(0, TabConsonne.Length))];
            comp++;
            ConsonnesWasClicked = true;

        }

        //bouton pour choisir aléatoirement des lettres consonnes et voyelles
        private void hasard_Click(object sender, RoutedEventArgs e)
        {
            Button[] tabZoneA = new Button[] { btA1, btA2, btA3, btA4, btA5, btA6, btA7, btA8, btA9 };

            Random hasardcons = new Random();
            for (int i = 4; i < tabZoneA.Length; i++)
            {
                tabZoneA[i].FontSize = 20;
                tabZoneA[i].Content = TabConsonne[(char)(hasardcons.Next(0, TabConsonne.Length))];
            }
            Random hasardvoy = new Random();
            for (int i = 0; i < 4; i++)
            {
                tabZoneA[i].FontSize = 20;
                tabZoneA[i].Content = TabVoyelle[(char)(hasardcons.Next(0, TabVoyelle.Length))];
            }
            hasardWasClicked = true;
        }

        //bouton rejouer permet de redémarrer et faire initialisation des champs de remplissage
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            Button[] tabZoneA = new Button[] { btA1, btA2, btA3, btA4, btA5, btA6, btA7, btA8, btA9 };
            Button[] tabZoneB = new Button[] { btB1, btB2, btB3, btB4, btB5, btB6, btB7, btB8, btB9 };

            for (int i = 0; i < tabZoneA.Length; i++)//vider le contenu des boutons déja utilisés 
            {
                tabZoneA[i].Content = "";
                tabZoneB[i].Content = "";
            }

            for (int i = 0; i < tabZoneB.Length; i++)
            {
                tabZoneB[i].Background = (Brush)bc.ConvertFrom("#FF7FECEC"); //Brushes.LightGray; 
                                                                             //aprés validation changement de couleur pour la zone d'affichage
            }

            TextMot.Text = ""; //vider le champs du mot proposé
            lblTime.Content = "";
            resultatText.Text = "";
            pbStatus.Value = 0;
            RestartWasClicked = true;
        }
        #endregion

        #region Musique
        //CheckBox pour activer une séquence de musique
        private void musicChek_Checked(object sender, RoutedEventArgs e)
        { mySound.Play(); }

        //CheckBox pour désactiver une séquence de musique
        private void musicChek_Unchecked(object sender, RoutedEventArgs e)
        { mySound.Stop(); }
        #endregion

        #region zoneA
        private void btA1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextMot.Text += btA1.Content.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur!! SVP remplir cette case vide !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btA2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextMot.Text += btA2.Content.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur!! SVP remplir cette case vide !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btA3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextMot.Text += btA3.Content.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur!! SVP remplir cette case vide !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btA4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextMot.Text += btA4.Content.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur!! SVP remplir cette case vide !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btA5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextMot.Text += btA5.Content.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur!! SVP remplir cette case vide !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btA6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextMot.Text += btA6.Content.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur!! SVP remplir cette case vide !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btA7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextMot.Text += btA7.Content.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur!! SVP remplir cette case vide !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btA8_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextMot.Text += btA8.Content.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur!! SVP remplir cette case vide !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btA9_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextMot.Text += btA9.Content.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur!! SVP remplir cette case vide !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        #endregion

        #region Mnaipulation
        //bouton répondre permet d'afficher le mot proposé dans la zone B
        private void Repondre_Click(object sender, RoutedEventArgs e)
        {
            Button[] tabZoneB = new Button[] { btB1, btB2, btB3, btB4, btB5, btB6, btB7, btB8, btB9 };

            //string x = TextMot.Text;
            for (int i = 0; i < TextMot.Text.Length; i++)
            {
                if (TextMot.Text.Length < 3)
                    MessageBox.Show("Votre doit contenir au moins 3 lettres ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    tabZoneB[i].FontSize = 20;
                    tabZoneB[i].Content = TextMot.Text[i];
                }

            }
        }

        //bouton valider permet de valider le mot prposé et déja affiché
        private void btValider_Click(object sender, RoutedEventArgs e)
        {
            Button[] tabZoneB = new Button[] { btB1, btB2, btB3, btB4, btB5, btB6, btB7, btB8, btB9 };
            if (TextMot.Text.Length < 3)
                MessageBox.Show("Votre mot doit contenir au moins 3 lettres ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                for (int i = 0; i < tabZoneB.Length; i++)
                {
                    tabZoneB[i].Background = Brushes.LightGray;//aprés validation changement de couleur pour la zone d'affichage
                }

               // MessageBox.Show("validation avec succés de votre choix de mot ", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                btValiderWasClicked = true; resultatText.Text = s1.ToString();


            }
            //test pour tester si le mot proposé se trouve dans le dictionnaire 
            word.Application app = new word.Application();
            if (app.CheckSpelling(TextMot.Text.ToLower()))
            {
                MessageBox.Show("Sucées ! mot trouvé dans le dictionnaire", "Sucées", MessageBoxButton.OK, MessageBoxImage.Information);
                s1.valeur += 15; //Si un candidat répond correctement, 15 points lui sont attribués.
            }
            else
                MessageBox.Show("Oups ! mot non trouvé dans le dictionnaire", "Oups !", MessageBoxButton.OK, MessageBoxImage.Exclamation);



        }

        //méthode permet de tester lors de choix des lettres à utiliser si le mot proposé depasse un taille maximum
        private void TextMot_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (TextMot.Text.Length > 9)
                MessageBox.Show("vous avez dépassé la taille maximale de votre mot proposé", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        //bouton permet d’effacer une lettre
        private void btEffacer_Click(object sender, RoutedEventArgs e)
        {
           // List<Button> listeZoneB = new List<Button>() {btB1, btB2,btB3,btB3,btB5,btB6,btB7,btB8,btB9 };
           Button [] listeZoneB = new Button[] { btB1, btB2, btB3, btB3, btB5, btB6, btB7, btB8, btB9 };
            int cp= TextMot.Text.Length-1;
            try
            {
                TextMot.Text = TextMot.Text.Substring(0, TextMot.Text.Length - 1);//effacer une lettre depuis TextBox "TextMot"
                listeZoneB[cp--].Content = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur !! aucune lettre à effacer !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (efaccerWasClicked)

                s1.valeur -= 5;//Si un candidat efface une lettre de son mot proposé – 5 points (bonus + 5 point s’il trouve un mot de la première intension)

            else
                s1.valeur += 5;

        }

        //bouton affiche un message box...
        private void Gift_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Chargement page principale
        //méthode 1
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Button[] tabZoneA = new Button[] { btA1, btA2, btA3, btA4, btA5, btA6, btA7, btA8, btA9 };//tableau à utiliser pour bloquer 

            for (int i = 0; i < 100; i++) //100 désigne 100% de progression
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(400); //Suspendre le thread actuel pendant le nombre spécifié de 200 millisecondes(20 sec)

                if ((i == 99) && (!btValiderWasClicked))//tester si 20 secondes sont écoulés et aucun mot proposé est validé 
                                                        //erreur et diminution de score
                {
                    MessageBox.Show("Oups, désolé ! temps de réflexion est écoulé... SVP reprenez le jeu.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    s1.valeur += 0;

                     if ((sender as BackgroundWorker).IsBusy == true)//probléme de multiThreading 
                     {
                         (sender as BackgroundWorker).CancelAsync();
                         btA1.IsEnabled = false; //test pour désactiver le premier bouton

                        // WorkerSupportsCancellation
                     }
                }
                else
                {
                    s1.valeur += 5;//Si un candidat termine en temps, 5 points lui sont attribués
                }

            }
        }

        //méthode 2
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;//pbStatus nom du progressBar
        }

        //méthode responsable au chargement de la fenetre principale
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();//utilisation de la classe BackgroundWorker qui permet de 
                                                             //visualiser une progression mis à jour à l'aide d'execution d'un thread sur l'interface utilisateur
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();//Démarre l'exécution d'une opération d'arrière-plan (lancement du chargement de progressBar) 

            //manipulation du code qui me permet de décrémenter le temps de réflexion (20 secondes) affiché dans l’étiquette lblTime
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            //partie rechargement du progressBar
            /*if ((RestartWasClicked)&&(ConsonnesWasClicked || VoyelleWasClicked || hasardWasClicked))
            {
             //...
            }*/
        }

        int tik = 40;
        void timer_Tick(object sender, EventArgs e)//méthode permet la décrémentation
        {
            lblTime.Content = tik + " secondes restantes";
            if (tik > 0)

                tik--;
            else
                lblTime.Content = "Le temps est écoulé";
        }




        #endregion

        private void resultatText_SelectionChanged(object sender, RoutedEventArgs e)
        {
            resultatText.Text = "le score est: " + s1.valeur.ToString();

        }
    }
}




