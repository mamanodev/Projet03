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
        public static string Nom_bonbonChoisi;
        public static decimal Prix_bonbonChoisi;
        public static int Stock_bonbonChoisi;
        public static decimal totalMonnaie = 0;
        public List<decimal> monnaiesPossible = new List<decimal> { 0.05m, 0.1m, 0.25m, 1, 2 };

        public FrmPrincipale()
        {
            InitializeComponent();
            //initialisation des textbox
            TxtChoix.Text = "0";
            TxtMonnaie.Text = "0";
            //on désactive les composants mentionnés dans les étapes (voir énoncé)
            //exemple
            cmdAjouter.Enabled = false;
            cmdAcheter.Enabled = false;
            lblMessage.Visible = false;
            lblBonbon.Visible = false;
            TxtMonnaie.Enabled = false;
            //...

        }

        private void cmdAnnuler_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdAjouter_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(TxtMonnaie.Text, out decimal monnaie) && monnaiesPossible.Contains(monnaie))
            {
                totalMonnaie += monnaie;
                lblPercu.Text = Convert.ToString(totalMonnaie);
                TxtMonnaie.Text="0";
            }
            else
            {
                MessageBox.Show("Veuillez entrer une monnaie valide (5c, 10c, 25c, 1$, 2$)", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtMonnaie.Text = "0";
            }

        }
        public decimal calculRemis(decimal monnaie, decimal PrixBonbon)
        {
            decimal remis = totalMonnaie - Prix_bonbonChoisi;
            return remis;
        }
        private void cmdAcheter_Click(object sender, EventArgs e)
        {
            
            if (totalMonnaie >= Prix_bonbonChoisi)
            {
                decimal MonnaieRemise = calculRemis(totalMonnaie, Prix_bonbonChoisi);
                totalMonnaie = 0;
                lblRemis.Text = Convert.ToString(MonnaieRemise);
                lblMessage.Visible = true;
                lblBonbon.Visible = true;
                lblBonbon.Text = Nom_bonbonChoisi.ToUpper();
            }
            else
            {
                MessageBox.Show("Monnaie insuffisante, Ajouté de la monnaie pour completer l'achat", "Info", MessageBoxButtons.OK);
            }

        }

        private void TxtChoix_TextChanged(object sender, EventArgs e)
        {
          
        }
        //bouton vérifier stock: fonction de vérification de la selection puis le stock
        private void cmdVerifierStock_Click(object sender, EventArgs e)
        {
            if (TxtChoix.Text=="")
            {
                TxtChoix.Text="0";
            }

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
                if (selection == 0) {
                    MessageBox.Show("Le bonbon n'est pas en stock !","Info");
                } else {
                  
                    cmdAjouter.Enabled = true;
                    cmdAcheter.Enabled = true;
                    TxtMonnaie.Enabled = true;
                    lblSelection.Text =Convert.ToString( selection);
                    lblPrix.Text = Prix_bonbonChoisi.ToString();
                }
                
            }


        }

        private void cmdRecommencer_Click(object sender, EventArgs e)
        {
            //remettre la machine à zéro
            
            if (totalMonnaie > 0)
            {
                MessageBox.Show($"Monnaie rendue : {totalMonnaie:C}", "Remboursement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            totalMonnaie = 0;
            TxtChoix.Text = "0";
            TxtMonnaie.Text = "0";
            //on désactive les composants mentionnés dans les étapes (voir énoncé)
            //exemple
            cmdAjouter.Enabled = false;
            cmdAcheter.Enabled = false;
            lblMessage.Visible = false;
            lblBonbon.Visible = false;
            TxtMonnaie.Enabled = false;
            lblPrix.Text="00";
            lblPercu.Text="00";
            lblRemis.Text="00";
            lblSelection.Text="00";
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
