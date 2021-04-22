using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalExt_Backoffice.Objetos
{
    public class Pedido
    {
        #region Campos
        private int mPedidoID;
        private string mAluno;
        private string mProf;
        private int mModulo;
        private DateTime mDataCria;
        private DateTime mHoraCria;
        private DateTime mDataExame;
        private DateTime mHoraExame;
        private int mDurExame;
        private DateTime mDataAprov;
        private DateTime mHoraAprov;
        private DateTime mDataPago;
        private DateTime mHoraPago;
        private DateTime mDataTermin;
        private DateTime mHoraTermin;
        private enumEstado mEstado;
        private Decimal mPreco;
        private string mTipoPaga;
        private enumTaxa mTipoTaxa;
        private double mNota;
        #endregion

        #region Construtores
        public Pedido()
        {
            mPedidoID = -1;
            mAluno = "";
            mProf = "";
            mModulo = -1;
            mDataCria = new DateTime(999, 1, 1);
            mHoraCria = new DateTime(999, 1, 1);
            mDataExame = new DateTime(999, 1, 1);
            mHoraExame = new DateTime(999, 1, 1);
            mDurExame = -1;
            mDataAprov = new DateTime(999, 1, 1);
            mHoraAprov = new DateTime(999, 1, 1);
            mDataPago = new DateTime(999, 1, 1);
            mHoraPago = new DateTime(999, 1, 1);
            mDataTermin = new DateTime(999, 1, 1);
            mHoraTermin = new DateTime(999, 1, 1);
            mEstado = enumEstado.NULL;
            mPreco = -1;
            mTipoPaga = "";
            mTipoTaxa = enumTaxa.NULL;
            mNota = -1;
        }

        public Pedido(int PedidoID, string Aluno, string Prof, int Modulo, DateTime DataCria, DateTime HoraCria, DateTime DataExame, DateTime HoraExame, int DurExame, DateTime DataAprov, DateTime HoraAprov, DateTime DataPago, DateTime HoraPago, DateTime DataTermin, DateTime HoraTermin, enumEstado Estado, Decimal Preco, string TipoPaga, enumTaxa TipoTaxa, double Nota)
        {
            mPedidoID = PedidoID;
            mAluno = Aluno;
            mProf = Prof;
            mModulo = Modulo;
            mDataCria = DataCria;
            mHoraCria = HoraCria;
            mDataExame = DataExame;
            mHoraExame = HoraExame;
            mDurExame = DurExame;
            mDataAprov = DataAprov;
            mHoraAprov = HoraAprov;
            mDataPago = DataPago;
            mHoraPago = HoraPago;
            mDataTermin = DataTermin;
            mHoraTermin = HoraTermin;
            mEstado = Estado;
            mPreco = Preco;
            mTipoPaga = TipoPaga;
            mTipoTaxa = TipoTaxa;
            mNota = Nota;
        }
        #endregion

        #region Propriedades
        public int PedidoID
        {
            get { return mPedidoID; }
            set { mPedidoID = value; }
        }

        public string Aluno
        {
            get { return mAluno; }
            set { mAluno = value; }
        }

        public string Prof
        {
            get { return mProf; }
            set { mProf = value; }
        }

        public int Modulo
        {
            get { return mModulo; }
            set { mModulo = value; }
        }

        public DateTime DataCria
        {
            get { return mDataCria; }
            set { mDataCria = value; }
        }

        public DateTime HoraCria
        {
            get { return mHoraCria; }
            set { mHoraCria = value; }
        }

        public DateTime DataExame
        {
            get { return mDataExame; }
            set { mDataExame = value; }
        }

        public DateTime HoraExame
        {
            get { return mHoraExame; }
            set { mHoraExame = value; }
        }

        public int DurExame
        {
            get { return mDurExame; }
            set { mDurExame = value; }
        }

        public DateTime DataAprov
        {
            get { return mDataAprov; }
            set { mDataAprov = value; }
        }

        public DateTime HoraAprov
        {
            get { return mHoraAprov; }
            set { mHoraAprov = value; }
        }

        public DateTime DataPago
        {
            get { return mDataPago; }
            set { mDataPago = value; }
        }

        public DateTime HoraPago
        {
            get { return mHoraPago; }
            set { mHoraPago = value; }
        }

        public DateTime DataTermin
        {
            get { return mDataTermin; }
            set { mDataTermin = value; }
        }

        public DateTime HoraTermin
        {
            get { return mHoraTermin; }
            set { mHoraTermin = value; }
        }

        public enumEstado Estado
        {
            get { return mEstado; }
            set { mEstado = value; }
        }

        public Decimal Preco
        {
            get { return mPreco; }
            set { mPreco = value; }
        }

        public string TipoPaga
        {
            get { return mTipoPaga; }
            set { mTipoPaga = value; }
        }

        public enumTaxa TipoTaxa
        {
            get { return mTipoTaxa; }
            set { mTipoTaxa = value; }
        }

        public double Nota
        {
            get { return mNota; }
            set { mNota = value; }
        }

        #endregion

        #region Enumeradores
        public enum enumEstado
        {
            NULL,
            PorAprovar,
            NaoAprovado,
            Aprovado,
            Pago,
            Lancado,
            Terminado,
        }

        public enum enumTaxa
        {
            NULL,
            Isento,
            Epoca,
            ForaEpoca,
        }
        #endregion
    }
}
