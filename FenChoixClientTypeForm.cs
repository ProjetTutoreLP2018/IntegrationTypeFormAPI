using AnswerTypeForm;
using app_lp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LettreCooperation
{
	public partial class FenChoixClientTypeForm : Form
	{
		public static InfoEntreprise entrepriseChoisie;
		private Formulaire1 formulaire1 = new Formulaire1();
		private Formulaire2 formulaire2 = new Formulaire2();
		public FenChoixClientTypeForm()
		{
			InitializeComponent();
		}

		private async void FenChoixClientTypeForm_Load(object sender, EventArgs e)
		{
		    AnswerObject reponses = await typeFormApi.getAnswers(Identifiants.Token, Identifiants.IDFormulaire1);
			formulaire1.json_answers = reponses;

			reponses = await typeFormApi.getAnswers(Identifiants.Token, Identifiants.IDFormulaire2);
			formulaire2.json_answers = reponses;



			foreach (InfoEntreprise infoEntreprise in formulaire1.getInfoEntreprises()) {
				cbChoixClientTypeForm.Items.Add(infoEntreprise.nomEntreprise);
			}
		}

		private void btnValideChoixClientTypeForm_Click(object sender, EventArgs e)
		{
			//entrepriseChoisie = formulaire1.getInfosEntrepriseByNom(cbChoixClientTypeForm.SelectedItem.ToString());

			entrepriseChoisie = FormulaireAbstract.getInfoEntrepriseForm1Form2(formulaire1, formulaire2, cbChoixClientTypeForm.SelectedItem.ToString());

			return;
		}
	}
}