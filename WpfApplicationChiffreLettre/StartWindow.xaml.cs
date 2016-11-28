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
using System.Windows.Shapes;

namespace WpfApplicationChiffreLettre
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        //Bouton permet la rédirection à la fenetre de jeu principale 
        private void btJouer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bonjour joueur !\n"+
                            "Vous avez 40 secondes de réflexion pour choisir votre mot proposé\n"+
                            "Bonne chance… \n",
                            "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            MainWindow myWindow = new MainWindow();//objet myWindow de la classe MainWindow principlae
            myWindow.Show();
        }

        private void btHelp_Click(object sender, RoutedEventArgs e)
        {   
            MessageBox.Show("Score :\n\n" +
                            "•Si personne ne répond avant les 40 secondes, aucun point n'est attribué.\n\n" +
                            "•Si un candidat termine en temps, 5 points lui sont attribués \n\n" +
                            "•Si un candidat répond correctement, 15 points lui sont attribués. \n\n" +
                            "•Si un candidat répond mal, 10 points sont attribués à son adversaire (sans que ce dernier n'ait besoin de donner sa propre réponse). \n\n" +
                            "•Si un candidat efface une lettre de son mot proposé – 5 points (bonus de 5 points s’il trouve un mot de la première intension). \n\n", 
                            "A PROPOS JEU", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
