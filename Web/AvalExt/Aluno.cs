using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvalExt
{
    public class Aluno
    {
        #region Campos
        private string mAlunoID;
        private string mPassword;
        private string mNome;
        private DateTime mDataNasc;
        private string mTelefone;
        private string mMorada;
        private DateTime mDataCria;
        private string mTurma;
        private bool mOculto;
        #endregion

        #region Construtores
        public Aluno()
        {
            mAlunoID = "";
            mPassword = "";
            mNome = "";
            mDataNasc = System.DateTime.Now;
            mDataCria = System.DateTime.Now;
            mTelefone = "";
            mMorada = "";
            mTurma = "";
            mOculto = false;
        }

        public Aluno(string AlunoID, string Password, string Nome, DateTime DataNasc, DateTime DataCria, string Telefone, string Morada, string Turma, bool Oculto)
        {
            mAlunoID = AlunoID;
            mPassword = Password;
            mNome = Nome;
            mDataNasc = DataNasc;
            mDataCria = DataCria;
            mTelefone = Telefone;
            mMorada = Morada;
            mTurma = Turma;
            mOculto = Oculto;
        }
        #endregion

        #region Propriedades
        public string AlunoID
        {
            get { return mAlunoID; }
            set { mAlunoID = value; }
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

        public DateTime DataCria
        {
            get { return mDataCria; }
            set { mDataCria = value; }
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

        public string Turma
        {
            get { return mTurma; }
            set { mTurma = value; }
        }

        public bool Oculto
        {
            get { return mOculto; }
            set { mOculto = value; }
        }
        #endregion
    }
}