using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace AvalExt
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        SqlConnection db = new SqlConnection(@"Server=.\SQLEXPRESS; Database=AvaExt; Trusted_Connection=True;");
        SqlCommand ocm;
        SqlDataReader reader;

        public WebService()
        {
            db.Open();
            db.Close();
        }

        [WebMethod]
        public Aluno getAluno(string AlunoID)
        {
            db.Open();
            //Adquirir quantidade de registos
            int qtd = 0;

            ocm = new SqlCommand("Select count(*) from Aluno where AlunoID='" + AlunoID + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                Aluno aluno = new Aluno();
                ocm = new SqlCommand("Select * from Aluno where AlunoID='" + AlunoID + "'", db);
                reader = ocm.ExecuteReader();

                while (reader.Read())
                {

                    aluno.AlunoID = AlunoID;
                    aluno.Password = reader.GetString(1);
                    aluno.Nome = reader.GetString(2);
                    aluno.DataNasc = reader.GetDateTime(3);
                    aluno.Telefone = reader.GetString(4);
                    aluno.Morada = reader.GetString(5);
                    aluno.DataCria = reader.GetDateTime(6);
                    aluno.Turma = reader.GetString(7);
                    aluno.Oculto = reader.GetBoolean(8);
                }

                db.Close();
                return aluno;

            }
            else
            {
                db.Close();
                throw new ArgumentOutOfRangeException("Aluno não Existente");
            }

        }

        [WebMethod]
        public List<Aluno> getAlunos()
        {
            db.Open();
            List<Aluno> alunos = new List<Aluno>();

            //Adquirir quantidade de registos
            int qtd = 0;

            ocm = new SqlCommand("Select count(*) from Aluno", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                ocm = new SqlCommand("Select * from Aluno", db);
                reader = ocm.ExecuteReader();

                while (reader.Read())
                {
                    Aluno aluno = new Aluno();
                    aluno.AlunoID = reader.GetString(0);
                    aluno.Password = reader.GetString(1);
                    aluno.Nome = reader.GetString(2);
                    aluno.DataNasc = reader.GetDateTime(3);
                    aluno.Telefone = reader.GetString(4);
                    aluno.Morada = reader.GetString(5);
                    aluno.DataCria = reader.GetDateTime(6);
                    aluno.Turma = reader.GetString(7);
                    aluno.Oculto = reader.GetBoolean(8);

                    alunos.Add(aluno);
                }
            }

            db.Close();
            return alunos;
        }

        [WebMethod]
        public bool checkAluno(string AlunoID)
        {
            db.Open();
            //Adquirir quantidade de registos
            int qtd = 0;

            ocm = new SqlCommand("Select count(*) from Aluno where AlunoID='" + AlunoID + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                db.Close();
                return true;
            }
            else
            {
                db.Close();
                return false;
            }
        }

        [WebMethod]
        public void addAluno(Aluno aluno)
        {
            db.Open();
            ocm = new SqlCommand("InsertAl", db);
            ocm.CommandType = System.Data.CommandType.StoredProcedure;

            ocm.Parameters.AddWithValue("AlunoID", aluno.AlunoID);
            ocm.Parameters.AddWithValue("Password", aluno.Password);
            ocm.Parameters.AddWithValue("Nome", aluno.Nome);
            ocm.Parameters.AddWithValue("DataNasc", aluno.DataNasc);
            ocm.Parameters.AddWithValue("Telefone", aluno.Telefone);
            ocm.Parameters.AddWithValue("Morada", aluno.Morada);
            ocm.Parameters.AddWithValue("DataCria", aluno.DataCria);
            ocm.Parameters.AddWithValue("Turma", aluno.Turma);
            ocm.Parameters.AddWithValue("Oculto", aluno.Oculto);

            ocm.ExecuteNonQuery();
            db.Close();
        }

        [WebMethod]
        public void editAluno(string AlunoID, string Password, string Nome, string DataNasc, string Telefone, string Morada, string DataCria, string Turma)
        {
            db.Open();
            if (Password != null)
            {
                ocm = new SqlCommand("update Aluno set Password='" + Password + "' where AlunoID='" + AlunoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Nome != null)
            {
                ocm = new SqlCommand("update Aluno set Nome='" + Nome + "' where AlunoID='" + AlunoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (DataNasc != null)
            {
                ocm = new SqlCommand("update Aluno set DataNasc='" + DataNasc + "' where AlunoID='" + AlunoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Telefone != null)
            {
                ocm = new SqlCommand("update Aluno set Telefone='" + Telefone + "' where AlunoID='" + AlunoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Morada != null)
            {
                ocm = new SqlCommand("update Aluno set Morada='" + Morada + "' where AlunoID='" + AlunoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (DataCria != null)
            {
                ocm = new SqlCommand("update Aluno set DataCria='" + DataCria + "' where AlunoID='" + AlunoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Turma != null)
            {
                ocm = new SqlCommand("update Aluno set Turma='" + Turma + "' where AlunoID='" + AlunoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            db.Close();
        }

        [WebMethod]
        public void delUser(string ID)
        {
            db.Open();
            ocm = new SqlCommand("update Aluno set Oculto='True' where AlunoID='" + ID + "'", db);
            ocm.ExecuteNonQuery();

            ocm = new SqlCommand("update ProfStaff set Oculto='True' where ProfStaffID='" + ID + "'", db);
            ocm.ExecuteNonQuery();
            db.Close();
        }

        [WebMethod]
        public ProfStaff getProfStaff(string ProfStaffID)
        {
            db.Open();
            //Adquirir quantidade de registos
            int qtd = 0;

            ocm = new SqlCommand("Select count(*) from ProfStaff where ProfStaffID='" + ProfStaffID + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                ProfStaff profstaff = new ProfStaff();
                ocm = new SqlCommand("Select * from ProfStaff where ProfStaffID='" + ProfStaffID + "'", db);
                reader = ocm.ExecuteReader();

                while (reader.Read())
                {
                    profstaff.ProfStaffID = ProfStaffID;
                    profstaff.Password = reader.GetValue(1).ToString();
                    profstaff.Nome = reader.GetString(2);
                    profstaff.DataNasc = reader.GetDateTime(3);
                    profstaff.Telefone = reader.GetString(4);
                    profstaff.Morada = reader.GetString(5);
                    profstaff.DataCria = reader.GetDateTime(6);

                    switch (reader.GetString(7))
                    {
                        case "Prof":
                            profstaff.Tipo = ProfStaff.enumTipo.Prof;
                            break;

                        case "Func":
                            profstaff.Tipo = ProfStaff.enumTipo.Func;
                            break;

                        case "NULL":
                            db.Close();
                            throw new ArgumentOutOfRangeException("Erro tipo de funcionario igual a null");

                    }

                    profstaff.Oculto = reader.GetBoolean(8);
                }
                reader.Close();

                if (profstaff.Tipo == ProfStaff.enumTipo.Prof)
                {
                    ocm = new SqlCommand("Select Sigla from DiscProf where ProfStaffID='" + ProfStaffID + "'", db);
                    reader = ocm.ExecuteReader();

                    while (reader.Read())
                    {
                        profstaff.Sigla.Add(reader.GetString(0));
                    }
                }

                db.Close();
                return profstaff;
            }
            else
            {
                db.Close();
                throw new ArgumentOutOfRangeException("ProfFunc não Existente");
            }
        }

        [WebMethod]
        public List<ProfStaff> getProfStaffs()
        {
            db.Open();
            List<ProfStaff> profStaffs = new List<ProfStaff>();

            //Adquirir quantidade de registos
            int qtd = 0;

            ocm = new SqlCommand("Select count(*) from ProfStaff", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                ocm = new SqlCommand("Select * from ProfStaff", db);
                reader = ocm.ExecuteReader();

                while (reader.Read())
                {
                    ProfStaff profStaff = new ProfStaff();
                    profStaff.ProfStaffID = reader.GetString(0);
                    profStaff.Password = reader.GetString(1);
                    profStaff.Nome = reader.GetString(2);
                    profStaff.DataNasc = reader.GetDateTime(3);
                    profStaff.Telefone = reader.GetString(4);
                    profStaff.Morada = reader.GetString(5);
                    profStaff.DataCria = reader.GetDateTime(6);

                    switch (reader.GetString(7))
                    {
                        case "Prof":
                            profStaff.Tipo = ProfStaff.enumTipo.Prof;
                            break;

                        case "Func":
                            profStaff.Tipo = ProfStaff.enumTipo.Func;
                            break;

                        case "NULL":
                            db.Close();
                            throw new ArgumentOutOfRangeException("Erro tipo de funcionario igual a null");
                    }
                    profStaff.Oculto = reader.GetBoolean(8);

                    profStaffs.Add(profStaff);
                }
                reader.Close();

                for (int i = 0; i < profStaffs.Count(); i++)
                {
                    if (profStaffs[i].Tipo == ProfStaff.enumTipo.Prof)
                    {
                        ocm = new SqlCommand("Select Sigla from DiscProf where ProfStaffID='" + profStaffs[i].ProfStaffID + "'", db);
                        reader = ocm.ExecuteReader();

                        while (reader.Read())
                        {
                            profStaffs[i].Sigla.Add(reader.GetString(0));
                        }
                        reader.Close();
                    }
                }

            }

            db.Close();
            return profStaffs;
        }

        [WebMethod]
        public int[] getProfStaffsFromDisc(string Disc)
        {
            int qtd = 0;
            db.Open();
            ocm = new SqlCommand("Select count(*) from DiscProf where Sigla='" + Disc + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = reader.GetInt32(0);
            reader.Close();

            int[] ids = new int[qtd];
            if (qtd > 0)
            {
                int idx = 0;
                ocm = new SqlCommand("Select ProfStaffID from DiscProf where Sigla = '" + Disc + "'", db);
                reader = ocm.ExecuteReader();

                while (reader.Read())
                {
                    ids[idx] = Convert.ToInt32(reader.GetString(0));
                    idx++;
                }
            }
            db.Close();
            return ids;
        }

        [WebMethod]
        public bool checkProfStaff(string ProfStaffID)
        {
            db.Open();
            //Adquirir quantidade de registos
            int qtd = 0;

            ocm = new SqlCommand("Select count(*) from ProfStaff where ProfStaffID='" + ProfStaffID + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                db.Close();
                return true;
            }
            else
            {
                db.Close();
                return false;
            }
        }

        [WebMethod]
        public void addProfStaff(ProfStaff profStaff)
        {
            db.Open();
            ocm = new SqlCommand("InsertProfStaff", db);
            ocm.CommandType = System.Data.CommandType.StoredProcedure;

            ocm.Parameters.AddWithValue("ProfStaffID", profStaff.ProfStaffID);
            ocm.Parameters.AddWithValue("Password", profStaff.Password);
            ocm.Parameters.AddWithValue("Nome", profStaff.Nome);
            ocm.Parameters.AddWithValue("DataNasc", profStaff.DataNasc);
            ocm.Parameters.AddWithValue("Telefone", profStaff.Telefone);
            ocm.Parameters.AddWithValue("Morada", profStaff.Morada);
            ocm.Parameters.AddWithValue("DataCria", profStaff.DataCria);

            switch (profStaff.Tipo)
            {
                case ProfStaff.enumTipo.Func:
                    ocm.Parameters.AddWithValue("Tipo", "Func");
                    break;

                case ProfStaff.enumTipo.Prof:
                    ocm.Parameters.AddWithValue("Tipo", "Prof");
                    break;

                case ProfStaff.enumTipo.NULL:
                    throw new ArgumentException("Tipo de ProfStaff e NULL");
            }
            ocm.Parameters.AddWithValue("Oculto", profStaff.Oculto);

            ocm.ExecuteNonQuery();

            if (profStaff.Tipo == ProfStaff.enumTipo.Prof)
            {
                for (int i = 0; i < profStaff.Sigla.Count(); i++)
                {
                    ocm = new SqlCommand("InsertDiscProf", db);
                    ocm.CommandType = System.Data.CommandType.StoredProcedure;
                    ocm.Parameters.AddWithValue("Sigla", profStaff.Sigla[i]);
                    ocm.Parameters.AddWithValue("ProfStaffID", profStaff.ProfStaffID);

                    ocm.ExecuteNonQuery();
                }
            }

            db.Close();

        }

        [WebMethod]
        public void editProfStaff(string ProfStaffID, string Password, string Nome, string DataNasc, string Telefone, string Morada, string DataCria, string Tipo)
        {
            db.Open();
            if (Password != null)
            {
                ocm = new SqlCommand("update ProfStaff set Password='" + Password + "' where ProfStaffID='" + ProfStaffID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Nome != null)
            {
                ocm = new SqlCommand("update ProfStaff set Nome='" + Nome + "' where ProfStaffID='" + ProfStaffID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (DataNasc != null)
            {
                ocm = new SqlCommand("update ProfStaff set DataNasc='" + DataNasc + "' where ProfStaffID='" + ProfStaffID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Telefone != null)
            {
                ocm = new SqlCommand("update ProfStaff set Telefone='" + Telefone + "' where ProfStaffID='" + ProfStaffID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Morada != null)
            {
                ocm = new SqlCommand("update ProfStaff set Morada='" + Morada + "' where ProfStaffID='" + ProfStaffID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (DataCria != null)
            {
                ocm = new SqlCommand("update ProfStaff set DataCria='" + DataCria + "' where ProfStaffID='" + ProfStaffID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Tipo != null)
            {
                ocm = new SqlCommand("update ProfStaff set Tipo='" + Tipo + "' where ProfStaffID='" + ProfStaffID + "'", db);
                ocm.ExecuteNonQuery();
            }

            db.Close();
        }

        [WebMethod]
        public void delProfStaff(string ProfStaffID)
        {
            db.Open();
            ocm = new SqlCommand("update ProfStaff set Oculto='True' where ProfStaffID='" + ProfStaffID + "'");
            ocm.ExecuteNonQuery();
            db.Close();
        }

        [WebMethod]
        public void editProfDisc(string ProfStaffID, List<string> Sigla)
        {
            db.Open();
            //Eliminar todos os regisos com esse ID
            ocm = new SqlCommand("delDiscProf", db);
            ocm.CommandType = System.Data.CommandType.StoredProcedure;
            ocm.Parameters.AddWithValue("ProfStaffID", ProfStaffID);
            ocm.ExecuteNonQuery();

            //Inserir os atuais se houver

            if (Sigla.Count > 0)
            {
                for (int i = 0; i < Sigla.Count(); i++)
                {
                    ocm = new SqlCommand("InsertDiscProf", db);
                    ocm.CommandType = System.Data.CommandType.StoredProcedure;
                    ocm.Parameters.AddWithValue("Sigla", Sigla[i]);
                    ocm.Parameters.AddWithValue("ProfStaffID", ProfStaffID);

                    ocm.ExecuteNonQuery();
                }
            }

            db.Close();
        }

        [WebMethod]
        public string[] getDiscFromProf(string id)
        {
            db.Open();
            int qtd = 0;
            ocm = new SqlCommand("Select count(*) from DiscProf where ProfStaffID='" + id + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = reader.GetInt32(0);

            reader.Close();
            string[] disc = new string[qtd];
            if(qtd > 0)
            {
                ocm = new SqlCommand("Select Sigla from DiscProf where ProfStaffID='" + id + "'", db);
                reader = ocm.ExecuteReader();
                int idx = 0;
                while(reader.Read())
                {
                    disc[idx] = reader.GetString(0);
                    idx++;
                }
                reader.Close();
            }

            db.Close();
            return disc;
        }

        [WebMethod]
        public int getQtdUsers()
        {
            db.Open();
            int qtd = 0;

            //Adquirir quantidade de registos

            ocm = new SqlCommand("Select count(*) from Aluno", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd += Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            ocm = new SqlCommand("Select count(*) from ProfStaff", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd += Convert.ToInt32(reader.GetValue(0));
            reader.Close();
            db.Close();
            return qtd;
        }

        [WebMethod]
        public Pedido getPedido(int PedidoID)
        {
            db.Open();
            //Adquirir quantidade de registos
            int qtd = 0;

            ocm = new SqlCommand("Select count(*) from Pedido where PedidoID='" + PedidoID + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                Pedido pedido = new Pedido();
                ocm = new SqlCommand("Select * from Pedido where PedidoID='" + PedidoID + "'", db);
                reader = ocm.ExecuteReader();

                while (reader.Read())
                {
                    pedido.PedidoID = PedidoID;
                    pedido.Aluno = reader.GetString(1);
                    pedido.Prof = reader.GetString(2);
                    pedido.Modulo = reader.GetInt32(3);
                    pedido.DataCria = reader.GetDateTime(4);
                    pedido.HoraCria = DateTime.Parse(reader.GetTimeSpan(5).ToString());

                    if (reader.GetValue(6) != DBNull.Value)
                        pedido.DataExame = reader.GetDateTime(6);

                    if (reader.GetValue(7) != DBNull.Value)
                        pedido.HoraExame = DateTime.Parse(reader.GetTimeSpan(7).ToString());

                    if (reader.GetValue(8) != DBNull.Value)
                        pedido.DurExame = reader.GetInt32(8);

                    if (reader.GetValue(9) != DBNull.Value)
                        pedido.DataAprov = reader.GetDateTime(9);

                    if (reader.GetValue(10) != DBNull.Value)
                        pedido.HoraAprov = DateTime.Parse(reader.GetTimeSpan(10).ToString());

                    if (reader.GetValue(11) != DBNull.Value)
                        pedido.DataPago = reader.GetDateTime(11);

                    if (reader.GetValue(12) != DBNull.Value)
                        pedido.HoraPago = DateTime.Parse(reader.GetTimeSpan(12).ToString());

                    if (reader.GetValue(13) != DBNull.Value)
                        pedido.DataTermin = reader.GetDateTime(13);

                    if (reader.GetValue(14) != DBNull.Value)
                        pedido.HoraTermin = DateTime.Parse(reader.GetTimeSpan(14).ToString());

                    switch (reader.GetString(15))
                    {
                        case "NULL":
                            db.Close();
                            throw new ArgumentOutOfRangeException("Estado igual a null");

                        case "PorAprovar":
                            pedido.Estado = Pedido.enumEstado.PorAprovar;
                            break;

                        case "Aprovado":
                            pedido.Estado = Pedido.enumEstado.Aprovado;
                            break;

                        case "Pago":
                            pedido.Estado = Pedido.enumEstado.Pago;
                            break;

                        case "Terminado":
                            pedido.Estado = Pedido.enumEstado.Terminado;
                            break;

                        case "NaoAprovado":
                            pedido.Estado = Pedido.enumEstado.NaoAprovado;
                            break;

                        case "Lancado":
                            pedido.Estado = Pedido.enumEstado.Lancado;
                            break;
                    }

                    if (reader.GetValue(16) != DBNull.Value)
                        pedido.Preco = reader.GetDecimal(16);

                    if (reader.GetValue(17) != DBNull.Value)
                        pedido.TipoPaga = reader.GetString(17);

                    if (reader.GetValue(18) != DBNull.Value)
                    {
                        switch (reader.GetString(18))
                        {
                            case "Isento":
                                pedido.TipoTaxa = Pedido.enumTaxa.Isento;
                                break;

                            case "ForaEpoca":
                                pedido.TipoTaxa = Pedido.enumTaxa.ForaEpoca;
                                break;

                            case "Epoca":
                                pedido.TipoTaxa = Pedido.enumTaxa.Epoca;
                                break;
                        }
                    }

                    if (reader.GetValue(19) != DBNull.Value)
                        pedido.Nota = reader.GetDouble(19);

                }

                db.Close();
                return pedido;
            }
            else
            {
                db.Close();
                throw new ArgumentOutOfRangeException("Pedido não Existente");
            }
        }

        [WebMethod]
        public List<Pedido> getPedidos()
        {
            db.Open();
            List<Pedido> pedidos = new List<Pedido>();

            //Adquirir quantidade de registos
            int qtd = 0;

            ocm = new SqlCommand("Select count(*) from Pedido", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                ocm = new SqlCommand("Select * from Pedido", db);
                reader = ocm.ExecuteReader();

                while (reader.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.PedidoID = reader.GetInt32(0);
                    pedido.Aluno = reader.GetString(1);
                    pedido.Prof = reader.GetString(2);
                    pedido.Modulo = reader.GetInt32(3);
                    pedido.DataCria = reader.GetDateTime(4);
                    pedido.HoraCria = DateTime.Parse(reader.GetTimeSpan(5).ToString());

                    if (reader.GetValue(6) != DBNull.Value)
                        pedido.DataExame = reader.GetDateTime(6);

                    if (reader.GetValue(7) != DBNull.Value)
                        pedido.HoraExame = DateTime.Parse(reader.GetTimeSpan(7).ToString());

                    if (reader.GetValue(8) != DBNull.Value)
                        pedido.DurExame = reader.GetInt32(8);

                    if (reader.GetValue(9) != DBNull.Value)
                        pedido.DataAprov = reader.GetDateTime(9);

                    if (reader.GetValue(10) != DBNull.Value)
                        pedido.HoraAprov = DateTime.Parse(reader.GetTimeSpan(10).ToString());

                    if (reader.GetValue(11) != DBNull.Value)
                        pedido.DataPago = reader.GetDateTime(11);

                    if (reader.GetValue(12) != DBNull.Value)
                        pedido.HoraPago = DateTime.Parse(reader.GetTimeSpan(12).ToString());

                    if (reader.GetValue(13) != DBNull.Value)
                        pedido.DataTermin = reader.GetDateTime(13);

                    if (reader.GetValue(14) != DBNull.Value)
                        pedido.HoraTermin = DateTime.Parse(reader.GetTimeSpan(14).ToString());

                    switch (reader.GetString(15))
                    {
                        case "NULL":
                            db.Close();
                            throw new ArgumentOutOfRangeException("Estado igual a null");

                        case "PorAprovar":
                            pedido.Estado = Pedido.enumEstado.PorAprovar;
                            break;

                        case "Aprovado":
                            pedido.Estado = Pedido.enumEstado.Aprovado;
                            break;

                        case "Pago":
                            pedido.Estado = Pedido.enumEstado.Pago;
                            break;

                        case "Terminado":
                            pedido.Estado = Pedido.enumEstado.Terminado;
                            break;

                        case "NaoAprovado":
                            pedido.Estado = Pedido.enumEstado.NaoAprovado;
                            break;

                        case "Lancado":
                            pedido.Estado = Pedido.enumEstado.Lancado;
                            break;
                    }

                    if (reader.GetValue(16) != DBNull.Value)
                        pedido.Preco = reader.GetDecimal(16);

                    if (reader.GetValue(17) != DBNull.Value)
                        pedido.TipoPaga = reader.GetString(17);

                    if (reader.GetValue(18) != DBNull.Value)
                    {
                        switch (reader.GetString(18))
                        {
                            case "Isento":
                                pedido.TipoTaxa = Pedido.enumTaxa.Isento;
                                break;

                            case "ForaEpoca":
                                pedido.TipoTaxa = Pedido.enumTaxa.ForaEpoca;
                                break;

                            case "Epoca":
                                pedido.TipoTaxa = Pedido.enumTaxa.Epoca;
                                break;
                        }
                    }

                    if (reader.GetValue(19) != DBNull.Value)
                        pedido.Nota = reader.GetDouble(19);

                    pedidos.Add(pedido);
                }
            }

            db.Close();
            return pedidos;
        }

        [WebMethod]
        public int getQtdPedidos()
        {
            db.Open();
            int qtd = 0;

            //Adquirir quantidade de registos
            qtd = 0;

            ocm = new SqlCommand("Select count(*) from Pedido", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();
            db.Close();
            return qtd;
        }

        [WebMethod]
        public int[] getPedidosFromUser(string id)
        {
            db.Open();
            int qtd = 0;

            //Adquirir quantidade de registos
            qtd = 0;

            ocm = new SqlCommand("Select count(*) from Pedido", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            int[] ids = new int[qtd];
            int idx = 0;


            //Adquirir quantidade de registos
            qtd = 0;

            ocm = new SqlCommand("Select count(*) from Pedido where Aluno='" + id + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                ocm = new SqlCommand("Select PedidoID from Pedido where Aluno ='" + id + "'", db);
                reader = ocm.ExecuteReader();
                idx = 0;
                while (reader.Read())
                {
                    ids[idx] = reader.GetInt32(0);
                    idx++;
                }
            }

            //Adquirir quantidade de registos
            qtd = 0;

            ocm = new SqlCommand("Select count(*) from Pedido where Prof='" + id + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                ocm = new SqlCommand("Select PedidoID from Pedido where Prof='" + id + "'", db);
                reader = ocm.ExecuteReader();
                idx = 0;
                while (reader.Read())
                {
                    ids[idx] = reader.GetInt32(0);
                    idx++;
                }
            }

            db.Close();
            return ids;
        }

        [WebMethod]
        public void addPedido(Pedido pedido)
        {
            db.Open();
            ocm = new SqlCommand("InsertPedido", db);
            ocm.CommandType = System.Data.CommandType.StoredProcedure;

            ocm.Parameters.AddWithValue("PedidoID", pedido.PedidoID);
            ocm.Parameters.AddWithValue("Aluno", pedido.Aluno);
            ocm.Parameters.AddWithValue("Prof", pedido.Prof);
            ocm.Parameters.AddWithValue("Modulo", pedido.Modulo);
            ocm.Parameters.AddWithValue("DataCria", pedido.DataCria);
            ocm.Parameters.AddWithValue("HoraCria", pedido.HoraCria);

            if (pedido.DataExame != DateTime.Parse("999-1-1"))
                ocm.Parameters.AddWithValue("DataExame", pedido.DataExame);
            else
                ocm.Parameters.AddWithValue("DataExame", DBNull.Value);

            if (pedido.HoraExame != DateTime.Parse("999-1-1"))
                ocm.Parameters.AddWithValue("HoraExame", pedido.HoraExame);
            else
                ocm.Parameters.AddWithValue("HoraExame", DBNull.Value);

            if (pedido.DurExame != -1)
                ocm.Parameters.AddWithValue("DurExame", pedido.DurExame);
            else
                ocm.Parameters.AddWithValue("DurExame", DBNull.Value);

            if (pedido.DataAprov != DateTime.Parse("999-1-1"))
                ocm.Parameters.AddWithValue("DataAprov", pedido.DataAprov);
            else
                ocm.Parameters.AddWithValue("DataAprov", DBNull.Value);

            if (pedido.HoraAprov != DateTime.Parse("999-1-1"))
                ocm.Parameters.AddWithValue("HoraAprov", pedido.HoraAprov);
            else
                ocm.Parameters.AddWithValue("HoraAprov", DBNull.Value);

            if (pedido.DataPago != DateTime.Parse("999-1-1"))
                ocm.Parameters.AddWithValue("DataPago", pedido.DataPago);
            else
                ocm.Parameters.AddWithValue("DataPago", DBNull.Value);

            if (pedido.HoraPago != DateTime.Parse("999-1-1"))
                ocm.Parameters.AddWithValue("HoraPago", pedido.HoraPago);
            else
                ocm.Parameters.AddWithValue("HoraPago", DBNull.Value);

            if (pedido.DataTermin != DateTime.Parse("999-1-1"))
                ocm.Parameters.AddWithValue("DataTermin", pedido.DataTermin);
            else
                ocm.Parameters.AddWithValue("DataTermin", DBNull.Value);

            if (pedido.HoraTermin != DateTime.Parse("999-1-1"))
                ocm.Parameters.AddWithValue("HoraTermin", pedido.HoraTermin);
            else
                ocm.Parameters.AddWithValue("HoraTermin", DBNull.Value);

            switch (pedido.Estado)
            {
                case Pedido.enumEstado.Aprovado:
                    ocm.Parameters.AddWithValue("Estado", "Aprovado");
                    break;

                case Pedido.enumEstado.Pago:
                    ocm.Parameters.AddWithValue("Estado", "Pago");
                    break;

                case Pedido.enumEstado.PorAprovar:
                    ocm.Parameters.AddWithValue("Estado", "PorAprovar");
                    break;

                case Pedido.enumEstado.Terminado:
                    ocm.Parameters.AddWithValue("Estado", "Terminado");
                    break;

                case Pedido.enumEstado.NULL:
                    throw new ArgumentException("Estado do Pedido a NULL");
            }

            if (pedido.Preco != -1)
                ocm.Parameters.AddWithValue("Preco", pedido.Preco);
            else
                ocm.Parameters.AddWithValue("Preco", DBNull.Value);

            if (pedido.TipoPaga != "" && pedido.TipoPaga != null)
                ocm.Parameters.AddWithValue("TipoPaga", pedido.TipoPaga);
            else
                ocm.Parameters.AddWithValue("TipoPaga", DBNull.Value);

            switch (pedido.TipoTaxa)
            {
                case Pedido.enumTaxa.Isento:
                    ocm.Parameters.AddWithValue("TipoTaxa", "Isento");
                    break;

                case Pedido.enumTaxa.ForaEpoca:
                    ocm.Parameters.AddWithValue("TipoTaxa", "ForaEpoca");
                    break;

                case Pedido.enumTaxa.Epoca:
                    ocm.Parameters.AddWithValue("TipoTaxa", "Epoca");
                    break;

                case Pedido.enumTaxa.NULL:
                    ocm.Parameters.AddWithValue("TipoTaxa", DBNull.Value);
                    break;
            }

            if (pedido.Nota != -1)
                ocm.Parameters.AddWithValue("Nota", pedido.Nota);
            else
                ocm.Parameters.AddWithValue("Nota", DBNull.Value);

            ocm.ExecuteNonQuery();
            db.Close();
        }

        [WebMethod]
        public void editPedido(int PedidoID, string Aluno, string Prof, int Modulo, string DataCria, string HoraCria, string DataExame, string HoraExame, int DurExame, string DataAprov, string HoraAprov, string DataPago, string HoraPago, string DataTermin, string HoraTermin, string Estado, decimal Preco, string TipoPaga, string TipoTaxa, double Nota)
        {
            db.Open();
            if (Aluno != null)
            {
                ocm = new SqlCommand("update Pedido set Aluno='" + Aluno + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Prof != null)
            {
                ocm = new SqlCommand("update Pedido set Prof='" + Prof + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Modulo != -1)
            {
                ocm = new SqlCommand("update Pedido set Modulo='" + Modulo.ToString() + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (DataCria != null)
            {
                ocm = new SqlCommand("update Pedido set DataCria='" + DataCria + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (HoraCria != null)
            {
                ocm = new SqlCommand("update Pedido set HoraCria='" + HoraCria + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (DataExame != null)
            {
                ocm = new SqlCommand("update Pedido set DataExame='" + DataExame + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (HoraExame != null)
            {
                ocm = new SqlCommand("update Pedido set HoraExame='" + HoraExame + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (DurExame != -1)
            {
                ocm = new SqlCommand("update Pedido set DurExame='" + DurExame.ToString() + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (DataAprov != null)
            {
                ocm = new SqlCommand("update Pedido set DataAprov='" + DataAprov + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (HoraAprov != null)
            {
                ocm = new SqlCommand("update Pedido set HoraAprov='" + HoraAprov + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (DataPago != null)
            {
                ocm = new SqlCommand("update Pedido set DataPago='" + DataPago + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (HoraPago != null)
            {
                ocm = new SqlCommand("update Pedido set HoraPago='" + HoraPago + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (DataTermin != null)
            {
                ocm = new SqlCommand("update Pedido set DataTermin='" + DataTermin + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (HoraTermin != null)
            {
                ocm = new SqlCommand("update Pedido set HoraTermin='" + HoraTermin + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Estado != null)
            {
                ocm = new SqlCommand("update Pedido set Estado='" + Estado + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (Preco != -1)
            {
                ocm = new SqlCommand("update Pedido set Preco=" + Preco + " where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (TipoPaga != null)
            {
                ocm = new SqlCommand("update Pedido set TipoPaga='" + TipoPaga + "' where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            if (TipoTaxa != null)
            {
                if (TipoTaxa == "")
                {
                    ocm = new SqlCommand("update Pedido set TipoTaxa=NULL where PedidoID='" + PedidoID + "'", db);
                    ocm.ExecuteNonQuery();
                }
                else
                {
                    ocm = new SqlCommand("update Pedido set TipoTaxa='" + TipoTaxa + "' where PedidoID='" + PedidoID + "'", db);
                    ocm.ExecuteNonQuery();
                }
            }

            if (Nota != -1)
            {
                ocm = new SqlCommand("update Pedido set Nota=" + Nota.ToString() + " where PedidoID='" + PedidoID + "'", db);
                ocm.ExecuteNonQuery();
            }

            db.Close();
        }

        [WebMethod]
        public int getQtdPedidos(string id)
        {
            int qtd = 0;

            db.Open();
            ocm = new SqlCommand("Select count(*) from Pedido where Aluno='" + id + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd += reader.GetInt32(0);

            reader.Close();

            ocm = new SqlCommand("Select count(*) from Pedido where Prof='" + id + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd += reader.GetInt32(0);

            db.Close();
            return qtd;

        }

        [WebMethod]
        public void delPedido(int PedidoID)
        {
            db.Open();
            ocm = new SqlCommand("delPedido", db);
            ocm.CommandType = System.Data.CommandType.StoredProcedure;

            ocm.Parameters.AddWithValue("PedidoID", PedidoID);

            ocm.ExecuteNonQuery();
            db.Close();
        }

        [WebMethod]
        public int getLastPedido()
        {
            int id = 0;
            db.Open();
            ocm = new SqlCommand("select top 1 PedidoID from Pedido order by PedidoID desc", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                id = reader.GetInt32(0);

            db.Close();
            return id;
        }

        [WebMethod]
        public List<Pedido> queryPedido(string estado, string date, DateTime DataInic, DateTime DataFim, string aluno, string prof, string modulo)
        {
            List<Pedido> pedidos = new List<Pedido>();
            int qtd = 0;
            int[] ids;
            int idx = 0;

            string inic = DataInic.Year.ToString("0000") + DataInic.Month.ToString("00") + DataInic.Day.ToString("00");

            string fim = DataFim.Year.ToString("0000") + DataFim.Month.ToString("00") + DataFim.Day.ToString("00");

            db.Open();

            if (estado != null)
            {
                if (date != null)
                {
                    if (aluno != "-")
                    {
                        if (prof != "-")
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Aluno='" + aluno + "' and Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Aluno='" + aluno + "' and Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Aluno='" + aluno + "' and Prof='" + prof + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Aluno='" + aluno + "' and Prof='" + prof + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Aluno='" + aluno + "' and Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Aluno='" + aluno + "' and Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Aluno='" + aluno + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Aluno='" + aluno + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (prof != "-")
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Prof='" + prof + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Prof='" + prof + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "' and Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (aluno != "-")
                    {
                        if (prof != "-")
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and Aluno='" + aluno + "' and Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and Aluno='" + aluno + "' and Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and Aluno='" + aluno + "' and Prof='" + prof + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and Aluno='" + aluno + "' and Prof='" + prof + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and Aluno='" + aluno + "' and Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and Aluno='" + aluno + "' and Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and Aluno='" + aluno + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and Aluno='" + aluno + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (prof != "-")
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and Prof='" + prof + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and Prof='" + prof + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "' and Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "' and Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Estado='" + estado + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Estado='" + estado + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (date != "" && date != null)
                {
                    if (aluno != "-")
                    {
                        if (prof != "-")
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Aluno='" + aluno + "' and Prof='" + prof + "' and Modulo='" + modulo + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Aluno='" + aluno + "' and Prof='" + prof + "' and Modulo='" + modulo + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Aluno='" + aluno + "' and Prof='" + prof + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Aluno='" + aluno + "' and Prof='" + prof + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Aluno='" + aluno + "' and Modulo='" + modulo + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Aluno='" + aluno + "' and Modulo='" + modulo + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Aluno='" + aluno + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Aluno='" + aluno + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (prof != "-")
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Prof='" + prof + "' and Modulo='" + modulo + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Prof='" + prof + "' and Modulo='" + modulo + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Prof='" + prof + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido Prof='" + prof + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Modulo='" + modulo + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Modulo='" + modulo + "' and " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where " + date + ">='" + inic + "' and " + date + "<='" + fim + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (aluno != "-")
                    {
                        if (prof != "-")
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Aluno='" + aluno + "' and Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Aluno='" + aluno + "' and Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Aluno='" + aluno + "' and Prof='" + prof + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Aluno='" + aluno + "' and Prof='" + prof + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Aluno='" + aluno + "' and Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Aluno='" + aluno + "' and Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Aluno='" + aluno + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Aluno='" + aluno + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (prof != "-")
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Prof='" + prof + "' and Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Prof='" + prof + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Prof='" + prof + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (modulo != "-")
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido where Modulo='" + modulo + "'", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido where Modulo='" + modulo + "'", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                            else
                            {
                                ocm = new SqlCommand("Select count(*) from Pedido", db);
                                reader = ocm.ExecuteReader();

                                while (reader.Read())
                                {
                                    qtd = reader.GetInt32(0);
                                }

                                reader.Close();

                                if (qtd > 0)
                                {
                                    ocm = new SqlCommand("Select PedidoID from Pedido", db);
                                    reader = ocm.ExecuteReader();

                                    ids = new int[qtd];
                                    idx = 0;
                                    while (reader.Read())
                                    {
                                        ids[idx] = reader.GetInt32(0);
                                        idx++;
                                    }

                                    db.Close();
                                    reader.Close();

                                    for (int i = 0; i < ids.Count(); i++)
                                    {
                                        Pedido pedido = getPedido(ids[i]);
                                        pedidos.Add(pedido);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            db.Close();
            return pedidos;
        }

        [WebMethod]
        public Modulo getModulo(int ModuloID)
        {
            db.Open();
            //Adquirir quantidade de registos
            int qtd = 0;

            ocm = new SqlCommand("Select count(*) from Modulo where ModuloID='" + ModuloID + "'", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                Modulo modulo = new Modulo();
                ocm = new SqlCommand("Select * from Modulo where ModuloID='" + ModuloID + "'", db);
                reader = ocm.ExecuteReader();

                while (reader.Read())
                {
                    modulo.ModuloID = ModuloID;
                    modulo.NumModulo = reader.GetInt32(1);
                    modulo.Sigla = reader.GetString(2);
                }


                db.Close();
                return modulo;

            }
            else
            {
                db.Close();
                throw new ArgumentOutOfRangeException("Aluno não Existente");
            }
        }

        [WebMethod]
        public List<Modulo> getModulos()
        {
            db.Open();
            List<Modulo> modulos = new List<Modulo>();

            //Adquirir quantidade de registos
            int qtd = 0;

            ocm = new SqlCommand("Select count(*) from Modulo", db);
            reader = ocm.ExecuteReader();

            while (reader.Read())
                qtd = Convert.ToInt32(reader.GetValue(0));
            reader.Close();

            if (qtd > 0)
            {
                ocm = new SqlCommand("Select * from Modulo", db);
                reader = ocm.ExecuteReader();

                while (reader.Read())
                {
                    Modulo modulo = new Modulo();
                    modulo.ModuloID = reader.GetInt32(0);
                    modulo.NumModulo = reader.GetInt32(1);
                    modulo.Sigla = reader.GetString(2);

                    modulos.Add(modulo);
                }
            }

            db.Close();
            return modulos;
        }

        [WebMethod]
        public void addModulo(Modulo modulo)
        {
            db.Open();
            ocm = new SqlCommand("InsertModulo", db);
            ocm.CommandType = System.Data.CommandType.StoredProcedure;

            ocm.Parameters.AddWithValue("ModuloID", modulo.ModuloID);
            ocm.Parameters.AddWithValue("NumModulo", modulo.NumModulo);
            ocm.Parameters.AddWithValue("Sigla", modulo.Sigla);

            ocm.ExecuteNonQuery();
            db.Close();
        }


        [WebMethod]
        public string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
