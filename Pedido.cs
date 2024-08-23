using System;
using EspacioCliente;

namespace EspacioPedido
{
    public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private int estado;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public int Estado { get => estado; set => estado = value; }

        public string VerDireccionCliente()
        {
            return($"{Cliente.Direccion}");
        }

        public string VerDatosCliente()
        {
            return("DATOS DEL CLIENTE \n" +
            $"Nombre: {Cliente.Nombre}" +
            $"Telefono: {Cliente.Telefono}" +
            $"Dirección: {this.VerDireccionCliente()}");
        }

        public Pedido(int nro, string obs, Cliente cliente, int estado)
        {
            this.nro = nro;
            this.obs = obs;
            this.cliente = cliente;
            this.estado = estado; 
        }
    }
}