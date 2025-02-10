using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet03
{
    public partial class FrmPrincipale : Form
    {
        //on récupère ici le bonbon que l'utilisateur a séléctionné une fois la selection est valide.
        private static string Nom_bonbonChoisi;
        private static decimal Prix_bonbonChoisi;
        private static int Stock_bonbonChoisi;

        public FrmPrincipale()
        {
            InitializeComponent();
            //initialisation des textbox
            TxtChoix.Text = "0";
            TxtMonnaie.Text = "0";
            //on désactive les composants mentionnés dans les étapes (voir énoncé)
            //exemple
            cmdAjouter.Enabled = false;
            lblMessage.Visible = false;
            //...

        }

        private void cmdAnnuler_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdAjouter_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdAcheter_Click(object sender, EventArgs e)
        {

        }

        private void TxtChoix_TextChanged(object sender, EventArgs e)
        {
          
        }
        //bouton vérifier stock: fonction de vérification de la selection puis le stock
        private void cmdVerifierStock_Click(object sender, EventArgs e)
        {
            if ((int.Parse(TxtChoix.Text) < 1) || (int.Parse(TxtChoix.Text) > 25))
            {
                MessageBox.Show("selection du bonbon invalide, il faut choisir de 1 à 25","Erreur");
            }
            else
            {
                int selection = int.Parse(TxtChoix.Text);
                Nom_bonbonChoisi = Program.GetCandyName(selection);
                Prix_bonbonChoisi = Program.GetCandyPrice(selection);
                Stock_bonbonChoisi = Program.GetCandyStock(selection);
                //on vérifie si le bonbon choisi est en stock, sinon on affiche un MessageBox
                //...
                //si oui, on active les autres composants (voir énoncé)
            }


        }

        private void cmdRecommencer_Click(object sender, EventArgs e)
        {
            //remettre la machine à zéro
        }

        private void cmdQuitter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vous quitter la machine à bonbon?",
                          "Message de confirmation",
                          MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
