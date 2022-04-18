using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionClientCabinetDocteur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelSociete_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //bouton Quitter 
        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous quitter l'application ? ", "close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void textBoxIDClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            //si c'est pas du text numerique  
            if ((!(char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar))))
            {
                errorProviderNum.SetError(textBoxIDClient, "Erreur de saisie valeur numérique");
                //errorProvider1.SetError(txtnum, "Erreur de saisie valeur numérique");
                e.Handled = true;
            }
            else
                errorProviderNum.SetError(textBoxIDClient, "");
        }

        private void textBoxTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //si c'est pas du text numerique  
            if ((!(char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar))))
            {
                errorProviderNum.SetError(textBoxTelephone, "Erreur de saisie valeur numérique");
                //errorProvider1.SetError(txtnum, "Erreur de saisie valeur numérique");
                e.Handled = true;
            }
            else
                errorProviderNum.SetError(textBoxTelephone, "");

        }

        private void textBoxNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            //si c'est pas des touche aphabetique  
            if ((!(char.IsLetter(e.KeyChar) | char.IsControl(e.KeyChar) )))
            {
                //afficher un message d'erreur 
                errorProviderAlph.SetError(textBoxNom, "Erreur de saisie valeur Alphabetique");
            }
            //si ya pas d'erreur 
            else
                errorProviderAlph.SetError(textBoxNom, "");
        }

        private void textBoxPrenom_KeyPress(object sender, KeyPressEventArgs e)
        {
            //si c'est pas des touche aphabetique  
            if ((!(char.IsLetter(e.KeyChar) | char.IsControl(e.KeyChar))))
            {
                //afficher un message d'erreur 
                errorProviderAlph.SetError(textBoxPrenom, "Erreur de saisie valeur Alphabetique");
            }
            //si ya pas d'erreur 
            else
                errorProviderAlph.SetError(textBoxPrenom, "");
        }

        private void textBoxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            //si c'est pas du text numerique  
            if ((!(char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar))))
            {
                errorProviderNum.SetError(textBoxIDClient, "Erreur de saisie valeur numérique");
                //errorProvider1.SetError(txtnum, "Erreur de saisie valeur numérique");
                e.Handled = true;
            }
            else
                errorProviderNum.SetError(textBoxIDClient, "");
        }


        //enregistrer  dan le fichier 
        private void buttonSave_Click(object sender, EventArgs e)
        {

            saveFileDialogListClient.InitialDirectory = Application.ExecutablePath;
            saveFileDialogListClient.Filter = "Fichiers texte (*.txt)|*.txt |Tous les fichiers (*.*)|*.* ";

            if (saveFileDialogListClient.ShowDialog() == DialogResult.OK)
            {
                //recuperer nom fichier 
                string nomFichier = saveFileDialogListClient.FileName;
                StreamWriter fichier = null;
                try
                {
                    //on ouvre le fichier en écriture
                    fichier = new StreamWriter(nomFichier);
                    //on écrit le texte dedans 
                    foreach(string client in listBoxClient.Items)
                        fichier.WriteLine(client.ToString());
                }
                catch (Exception ex)
                {
                    //probleme
                    MessageBox.Show("Probleme à l'écriture du fichier(" + ex.Message + ")", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                finally
                {
                    //on ferme le fichier 
                    if (fichier != null)
                    {
                        fichier.Dispose();
                    }


                }
            }
        }

       //ajouter le liste Box
        private void button1_Click(object sender, EventArgs e)
        {
            listBoxClient.Items.AddRange(new String[] { textBoxIDClient.Text + "|"

                                                        + textBoxPrenom.Text +"|"
                                                        + textBoxNom.Text +"|"
                                                        + textBoxAge.Text+"|"
                                                        + textBoxAdresse.Text +"|"
                                                        + textBoxTelephone.Text +"|"
                                                        + comboBoxGenre.Text.ToString()
                                                        });
        }

        private void listBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //ouverture duy fichier 
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialogListClient.InitialDirectory = Application.ExecutablePath;
            openFileDialogListClient.Filter = "Fichiers texte (*.txt)|*.txt |Tous les fichiers (*.*)|*.* ";

            if (openFileDialogListClient.ShowDialog() == DialogResult.OK)
            {
                //recuperer nom fichier 
                string nomFichier = openFileDialogListClient.FileName;
                StreamReader fichier = null;
                try
                {
                    //on ouvre le fichier en écriture
                    fichier = new StreamReader(nomFichier);
                    //on écrit le texte dedans 

                    listBoxClient.Items.Add(fichier.ReadToEnd()); 

                }
                catch (Exception ex)
                {
                    //probleme
                    MessageBox.Show("Probleme à l'ouverture du fichier(" + ex.Message + ")", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                finally
                {
                    //on ferme le fichier 
                    if (fichier != null)
                    {
                        fichier.Dispose();
                    }


                }
            }
        }
    }
}
