using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalExt_Backoffice.Objetos
{
    public class ProfStaff
    {
        #region Campos
        private string mProfStaffID;
        private string mPassword;
        private string mNome;
        private DateTime mDataNasc;
        private string mTelefone;
        private string mMorada;
        private List<string> mSigla;
        private DateTime mDataCria;
        private enumTipo mTipo;
        private bool mOculto;
        #endregion

        #region Construtores
        public ProfStaff()
        {
            mProfStaffID = "";
            mPassword = "";
            mNome = "";
            mDataNasc = System.DateTime.Now;
            mTelefone = "";
            mMorada = "";
            mSigla = new List<string>();
            mDataCria = System.DateTime.Now;
            mTipo = enumTipo.NULL;
            mOculto = false;
        }

        public ProfStaff(string ProfStaffID, string Password, string Nome, DateTime DataNasc, string Telefone, string Morada, List<string> Sigla, DateTime DataCria, enumTipo Tipo, bool Oculto)
        {
            mProfStaffID = ProfStaffID;
            mPassword = Password;
            mNome = Nome;
            mDataNasc = DataNasc;
            mTelefone = Telefone;
            mMorada = Morada;
            mSigla = Sigla;
            mDataCria = DataCria;
            mTipo = Tipo;
            mOculto = Oculto;
        }
        #endregion

        #region Propriedades
        public string ProfStaffID
        {
            get { return mProfStaffID; }
            set { mProfStaffID = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public string Nome
        {
            get { return mNome; }
            set { mNome = value; }
        }

        public DateTime DataNasc
        {
            get { return mDataNasc; }
            set { mDataNasc = value; }
        }

        public string Telefone
        {
            get { return mTelefone; }
            set { mTelefone = value; }
        }

        public string Morada
        {
            get { return mMorada; }
            set { mMorada = value; }
        }

        public List<string> Sigla
        {
            get { return mSigla; }
            set { mSigla = value; }
        }

        public DateTime DataCria
        {
            get { return mDataCria; }
            set { mDataCria = value; }
        }

        public enumTipo Tipo
        {
            get { return mTipo; }
            set { mTipo = value; }
        }

        public bool Oculto
        {
            get { return mOculto; }
            set { mOculto = value; }
        }
        #endregion

        #region Enumerators
        public enum enumTipo
        {
            NULL,
            Prof,
            Func,
        }
        #endregion

    }
}
