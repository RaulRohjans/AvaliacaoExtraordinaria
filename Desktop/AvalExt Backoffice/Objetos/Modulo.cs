using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalExt_Backoffice.Objetos
{
    public class Modulo
    {
        #region Campos
        private int mModuloID;
        private int mNumModulo;
        private string mSigla;
        #endregion

        #region Contrutores
        public Modulo()
        {
            mModuloID = -1;
            mNumModulo = -1;
            mSigla = "";
        }

        public Modulo(int ModuloID, int NumModulo, string Sigla)
        {
            mModuloID = ModuloID;
            mNumModulo = NumModulo;
            mSigla = Sigla;
        }
        #endregion

        #region Propriedades
        public int ModuloID
        {
            get { return mModuloID; }
            set { mModuloID = value; }
        }

        public int NumModulo
        {
            get { return mNumModulo; }
            set { mNumModulo = value; }
        }

        public string Sigla
        {
            get { return mSigla; }
            set { mSigla = value; }
        }
        #endregion

    }
}
