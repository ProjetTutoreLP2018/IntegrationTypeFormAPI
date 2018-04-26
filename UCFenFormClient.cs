﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LettreCooperation.modele;
using LettreCooperation.Model;
using app_lp;

namespace LettreCooperation
{
	public partial class UCFenFormClient : UserControl
	{
		public UCFenFormClient()
		{
			InitializeComponent();
            ESSNon.Checked = true;
		}

		private void préremplirAutomatiquementToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			PreremplirAutomatiquement();
		}

		private void PreremplirAutomatiquement()
		{
			FenPreRemplissageAutomatique fenPreRemplissageAutomatique = new FenPreRemplissageAutomatique();
			if (fenPreRemplissageAutomatique.ShowDialog(this) == DialogResult.OK)
			{
				Record enregistrement = fenPreRemplissageAutomatique.entrepriseSelectionnee;
                if (enregistrement.fields.l1_normalisee != null)
                    NomOrganisation.Text = enregistrement.fields.l1_normalisee;
                else
                    NomOrganisation.Text = "";

                if (enregistrement.fields.libnj != null)
                    FormeJuridique.Text = enregistrement.fields.libnj.Split(',')[0];
                else
                    FormeJuridique.Text = "";

                if (enregistrement.fields.numvoie != null && enregistrement.fields.typvoie != null && enregistrement.fields.libvoie != null)
                    Adresse.Text = String.Format("{0} {1} {2}", enregistrement.fields.numvoie, enregistrement.fields.typvoie, enregistrement.fields.libvoie);
                else
                    Adresse.Text = "";

                if (enregistrement.fields.codpos != null)
                    CodePostal.Text = enregistrement.fields.codpos;
                else
                    CodePostal.Text = "";

                if (enregistrement.fields.libcom != null)
                    Ville.Text = enregistrement.fields.libcom;
                else
                    Ville.Text = "";

                if (enregistrement.fields.siret != null)
                    NumeroSiret.Text = enregistrement.fields.siret;
                else
                    NumeroSiret.Text = "";

                if (enregistrement.fields.libapet != null)
                    textBoxActivite.Text = enregistrement.fields.libapet;
                else
                    textBoxActivite.Text = "";

                if (enregistrement.fields.numvoie != null)
                    NumeroVoie.Value = Int32.Parse(enregistrement.fields.numvoie);
                else
                    NumeroVoie.Value = 0;

                if (enregistrement.fields.dcren != null)
                    DateImmatriculation.Text = enregistrement.fields.dcren;
                else
                    DateImmatriculation.Text = "";

                if (enregistrement.fields.efetcent.Equals("NN"))
                    Effectif.Value = 0;
                else
                    Effectif.Value = Int32.Parse(enregistrement.fields.efetcent);

                if (enregistrement.fields.indrep != null)
                {
                    if (enregistrement.fields.indrep.Equals("T"))
                        IndiceRepetition.Text = "ter";
                    if (enregistrement.fields.indrep.Equals("B"))
                        IndiceRepetition.Text = "bis";
                    if (enregistrement.fields.indrep.Equals("Q"))
                        IndiceRepetition.Text = "quater";
                    if (enregistrement.fields.indrep.Equals("C"))
                        IndiceRepetition.Text = "quinquies";

                } else
                {
                    enregistrement.fields.indrep = "";
                }


            }
		}

		private void préremplirAvecUnFichierClientToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			//TODO : à implémenter
		}

		private  void BoutonValider_ClickAsync(object sender, EventArgs e)
		{


            messageErr.Text = string.Empty;
            adresseMailMess.Text = string.Empty;

            string email = CourrielRepresentant.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);


            if (!match.Success)
            {
                adresseMailMess.Text = "L'adresse email n'est pas valide.";
                return;
            }

            if (NomOrganisation.Text.Equals("") || FormeJuridique.Text.Equals("") || Effectif.Text.Equals("") ||
                NumeroSiret.Text.Equals("") || OrganisationComptable.Text.Equals("") || NumeroVoie.Text.Equals("") ||
                Adresse.Text.Equals("") || CodePostal.Text.Equals("") || Ville.Text.Equals("") ||
                NomRepresentant.Text.Equals("") || PrenomRepresentant.Text.Equals("") || CourrielRepresentant.Text.Equals("") ||
                SexeRepresentant.Text.Equals("") || FonctionRepresentant.Text.Equals("") || LieuImmatriculation.Text.Equals(""))
            {
                messageErr.Text = "Veuillez renseigner tous les champs.";
                return;
            }



                try
			{
				ModelManager modele = new ModelManager();

				Adresse adresse = new Adresse();
				adresse.numero = NumeroVoie.Text;
                if (!String.IsNullOrWhiteSpace(IndiceRepetition.Text))
                    adresse.indice = IndiceRepetition.Text;
                else
                    adresse.indice = " ";

                adresse.voie = Adresse.Text;

                if (!String.IsNullOrEmpty(Complement.Text))
                    adresse.complements = Complement.Text;
                else
                    adresse.complements = " ";

				adresse.code_postal = CodePostal.Text;
				adresse.ville = Ville.Text;

				modele.CreerAdresse(adresse);

				Client client = new Client();
				client.CA = (double)CA.Value;
				client.date_immatriculation = DateImmatriculation.Value;
				client.effectifs = (int)Effectif.Value;
				client.ESS = ESSOui.Checked;
				client.fonction_referent = FonctionRepresentant.Text;
				client.forme_juridique = FormeJuridique.Text;
				client.lieu_immatriculation = LieuImmatriculation.Text;
				client.nom_referent = NomRepresentant.Text;
				client.organisation_comptable = OrganisationComptable.Text;
				client.prenom_referent = PrenomRepresentant.Text;
				client.raison_sociale = NomOrganisation.Text;
				client.sexe_referent = SexeRepresentant.Text;
				client.siret = NumeroSiret.Text;
     

                if (String.IsNullOrEmpty(SiteInternet.Text))
                    client.site_web = " ";
                else
                    client.site_web = SiteInternet.Text;

                if (String.IsNullOrEmpty(TelephoneRepresentant.Text))
                    client.tel_fix = " ";
                else
                    client.tel_fix = TelephoneRepresentant.Text;


                if (String.IsNullOrEmpty(TelephonePortableRepresentant.Text))
                    client.tel_portable = " ";
                else
                    client.tel_portable = TelephonePortableRepresentant.Text;


				client.volume_annuel = Double.Parse(VolumesAnnuels.Text);
				client.id_adresse = adresse.id_adresse;
                client.mail_referent = CourrielRepresentant.Text;

				modele.CreerClient(client);

                MessageBox.Show("Votre client " + client.raison_sociale + " a bien était enregistré");

                Init();

            }
			catch (Exception ex)
			{
				MessageBox.Show("Une erreur est survenue. Veuillez réessayer.\nSi cette erreur se reproduit à l'avenir, contactez le développeur du logiciel en lui indiquant le message d'erreur.\nMessage d'erreur : " + ex.StackTrace, "Erreur");
			}
		
		}

		private void BoutonAnnuler_Click(object sender, EventArgs e)
		{
            Init();
		}


        private void Init()
        {


            NumeroVoie.Text = string.Empty;

            IndiceRepetition.Items.Clear();
            Adresse.Text = string.Empty;
            Complement.Text = string.Empty;
            CodePostal.Text = string.Empty;
            Ville.Text = string.Empty;
            
            CA.Value = 0;
            DateImmatriculation.Value = DateTime.Now;
            Effectif.Value = 0;
            ESSOui.Checked = false;
            FonctionRepresentant.Text = string.Empty;
            FormeJuridique.Text = string.Empty;
            LieuImmatriculation.Text = string.Empty;
            NomRepresentant.Text = string.Empty;
            OrganisationComptable.Text = string.Empty;
            PrenomRepresentant.Text = string.Empty;
            NomOrganisation.Text = string.Empty;
            SexeRepresentant.Text = string.Empty;
            NumeroSiret.Text = string.Empty;
            SiteInternet.Text = string.Empty;
            TelephoneRepresentant.Text = string.Empty;
            TelephonePortableRepresentant.Text = string.Empty;
            VolumesAnnuels.Text = string.Empty;
            
        }

		private void préremplirAvecTypeFormToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FenChoixClientTypeForm fenChoixClientTypeForm = new FenChoixClientTypeForm();
		    if(fenChoixClientTypeForm.ShowDialog(this) == DialogResult.OK)
			{
				InfoEntreprise entrepriseChoisie = FenChoixClientTypeForm.entrepriseChoisie;
				NomOrganisation.Text = entrepriseChoisie.nomEntreprise;
				FormeJuridique.Text = entrepriseChoisie.statut;
				NomRepresentant.Text = entrepriseChoisie.nom_contact;
				PrenomRepresentant.Text = entrepriseChoisie.prenom;
				Ville.Text = entrepriseChoisie.ville;
				CodePostal.Text = entrepriseChoisie.code_postal;
				DateImmatriculation.Value = DateTime.Parse(entrepriseChoisie.date_creation).Date;
				
			}
		}
	}
}
