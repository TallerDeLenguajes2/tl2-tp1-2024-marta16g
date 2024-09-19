using System;
using EspacioCadete;
using EspacioCliente;

namespace EspacioPedido
{
    public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private EnumPedido estado;
        private Cadete cadete;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public EnumPedido Estado { get => estado; set => estado = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }

        public string VerDireccionCliente()
        {
            return($"{cliente.Direccion}");
        }

        public string VerDatosCliente()
        {
            return("DATOS DEL CLIENTE \n" +
            $"Nombre: {Cliente.Nombre}" +
            $"Telefono: {Cliente.Telefono}" +
            $"Dirección: {this.VerDireccionCliente()}");
        }

        public Pedido(int nro, string obs, string nombre, ulong telefono, string direccion, string datosReferenciaDireccion, EnumPedido estado, Cadete cadete)
        {
            this.nro = nro;
            this.obs = obs;
            this.cliente = new Cliente(nombre, telefono, direccion, datosReferenciaDireccion);
            this.estado = estado; 
            this.Cadete = cadete;
        }
    }
    public enum EnumPedido
    {
        Pendiente = 1,
        EnProceso = 2,
        Completado = 3,
        Cancelado = 4
    }
}