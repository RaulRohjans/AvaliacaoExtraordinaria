using AvalExt_Backoffice.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvalExt_Backoffice
{
    public partial class Form_Edit_Prof : Form
    {
        public Form_Edit_Prof()
        {
            InitializeComponent();
        }

        DAL dal;
        List<ProfStaff> profStaffs;

        private void Form_Edit_Prof_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dal = new DAL();

                //Inserir itens na cbb
                profStaffs = dal.getProfStaffs();
                if (profStaffs.Count > 0)
                {
                    cbb_users.Items.Clear();
                    for (int i = 0; i < profStaffs.Count(); i++)
                    {
                        if (profStaffs[i].Tipo == ProfStaff.enumTipo.Prof && !profStaffs[i].Oculto)
                            cbb_users.Items.Add(profStaffs[i].ProfStaffID);
                    }
                }
                                
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao buscar dados da DB", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btn_pass_Click(object sender, EventArgs e)
        {
            if (txt_pass1.PasswordChar != '\0')
                txt_pass1.PasswordChar = '\0';
            else
                txt_pass1.PasswordChar = '•';
        }

        private void btn_passRepete_Click(object sender, EventArgs e)
        {
            if (txt_pass2.PasswordChar != '\0')
                txt_pass2.PasswordChar = '\0';
            else
                txt_pass2.PasswordChar = '•';
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem a certeza que pretende cancelar a operação?\nTodos os dados não guardados serão perdidos!", "Cancelar Operação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                this.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Regex telReg = new Regex(@"^\+[1-9]{1}[0-9]{3,14}$");

                if (cbb_users.Text != "")
                {
                    if (txt_nome.Text != "")
                    {
                        if (dtp_.Value < System.DateTime.Now)
                        {
                            if (txt_cont.Text != "")
                            {
                                if (telReg.IsMatch(txt_cont.Text))
                                {
                                    if (txt_morada.Text != "")
                                    {
                                        if (chk_ac.Checked || chk_ai.Checked || chk_ef.Checked || chk_fq.Checked || chk_ing.Checked || chk_mat.Checked || chk_psi.Checked || chk_pt.Checked || chk_rc.Checked || chk_so.Checked || chk_tic.Checked)
                                        {
                                            if (txt_pass1.Text != "" && txt_pass2.Text != "")
                                            {
                                                if (txt_pass1.Text == txt_pass2.Text)
                                                {
                                                    List<string> Sigla = new List<string>();

                                                    if (chk_ac.Checked)
                                                        Sigla.Add("AC");

                                                    if (chk_ai.Checked)
                                                        Sigla.Add("AI");

                                                    if (chk_ef.Checked)
                                                        Sigla.Add("EF");

                                                    if (chk_fq.Checked)
                                                        Sigla.Add("FQ");

                                                    if (chk_ing.Checked)
                                                        Sigla.Add("ING");

                                                    if (chk_mat.Checked)
                                                        Sigla.Add("MAT");

                                                    if (chk_psi.Checked)
                                                        Sigla.Add("PSI");

                                                    if (chk_pt.Checked)
                                                        Sigla.Add("PT");

                                                    if (chk_rc.Checked)
                                                        Sigla.Add("RC");

                                                    if (chk_so.Checked)
                                                        Sigla.Add("SO");

                                                    if (chk_tic.Checked)
                                                        Sigla.Add("TIC");

                                                    dal.editProfStaff(cbb_users.Text, txt_pass1.Text, txt_nome.Text, dtp_.Value.ToShortDateString(), txt_cont.Text, txt_morada.Text, null, null);
                                                    dal.editProfDisc(cbb_users.Text, Sigla);
                                                    this.Close();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("As palavras-passe devem ser iguais!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                if (txt_pass1.Text == "" && txt_pass2.Text == "")
                                                {
                                                    List<string> Sigla = new List<string>();

                                                    if (chk_ac.Checked)
                                                        Sigla.Add("AC");

                                                    if (chk_ai.Checked)
                                                        Sigla.Add("AI");

                                                    if (chk_ef.Checked)
                                                        Sigla.Add("EF");

                                                    if (chk_fq.Checked)
                                                        Sigla.Add("FQ");

                                                    if (chk_ing.Checked)
                                                        Sigla.Add("ING");

                                                    if (chk_mat.Checked)
                                                        Sigla.Add("MAT");

                                                    if (chk_psi.Checked)
                                                        Sigla.Add("PSI");

                                                    if (chk_pt.Checked)
                                                        Sigla.Add("PT");

                                                    if (chk_rc.Checked)
                                                        Sigla.Add("RC");

                                                    if (chk_so.Checked)
                                                        Sigla.Add("SO");

                                                    if (chk_tic.Checked)
                                                        Sigla.Add("TIC");

                                                    dal.editProfStaff(cbb_users.Text, null, txt_nome.Text, dtp_.Value.ToShortDateString(), txt_cont.Text, txt_morada.Text, null, null);
                                                    dal.editProfDisc(cbb_users.Text, Sigla);
                                                    this.Close();                                                    
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Por favor preencha o campo de palavra-passe ou deixe em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Por favor selecione pelo menos uma disciplina!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Por favor insira uma morada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Por favor insira um numero de telefone válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor insira um numero de telefone!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor insira uma data de nascimento válida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor insira um nome!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor selecione um utilizador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Ocorreu um erro ao editar o Professor." + ee, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void cbb_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (cbb_users.Text != "")
            {
                for (int i = 0; i < profStaffs.Count(); i++)
                {
                    if (profStaffs[i].ProfStaffID == cbb_users.Text)
                    {
                        txt_cont.Text = profStaffs[i].Telefone;
                        txt_morada.Text = profStaffs[i].Morada;
                        txt_nome.Text = profStaffs[i].Nome;
                        dtp_.Value = profStaffs[i].DataNasc;

                        //Parte das Disciplinas

                        //deselecionar todas as opçoes
                        chk_ac.CheckState = CheckState.Unchecked;
                        chk_ai.CheckState = CheckState.Unchecked;
                        chk_ef.CheckState = CheckState.Unchecked;
                        chk_fq.CheckState = CheckState.Unchecked;
                        chk_ing.CheckState = CheckState.Unchecked;
                        chk_mat.CheckState = CheckState.Unchecked;                       
                        chk_psi.CheckState = CheckState.Unchecked;                        
                        chk_pt.CheckState = CheckState.Unchecked;                        
                        chk_rc.CheckState = CheckState.Unchecked;                        
                        chk_so.CheckState = CheckState.Unchecked;                        
                        chk_tic.CheckState = CheckState.Unchecked;

                        for (int i2 = 0; i2 < profStaffs[i].Sigla.Count(); i2++)
                        {
                            if (profStaffs[i].Sigla[i2] == "AC")
                                chk_ac.CheckState = CheckState.Checked;

                            if (profStaffs[i].Sigla[i2] == "AI")
                                chk_ai.CheckState = CheckState.Checked;

                            if (profStaffs[i].Sigla[i2] == "EF")
                                chk_ef.CheckState = CheckState.Checked;

                            if (profStaffs[i].Sigla[i2] == "FQ")
                                chk_fq.CheckState = CheckState.Checked;

                            if (profStaffs[i].Sigla[i2] == "ING")
                                chk_ing.CheckState = CheckState.Checked;

                            if (profStaffs[i].Sigla[i2] == "MAT")
                                chk_mat.CheckState = CheckState.Checked;

                            if (profStaffs[i].Sigla[i2] == "PSI")
                                chk_psi.CheckState = CheckState.Checked;

                            if (profStaffs[i].Sigla[i2] == "PT")
                                chk_pt.CheckState = CheckState.Checked;

                            if (profStaffs[i].Sigla[i2] == "RC")
                                chk_rc.CheckState = CheckState.Checked;

                            if (profStaffs[i].Sigla[i2] == "SO")
                                chk_so.CheckState = CheckState.Checked;

                            if (profStaffs[i].Sigla[i2] == "TIC")
                                chk_tic.CheckState = CheckState.Checked;
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
