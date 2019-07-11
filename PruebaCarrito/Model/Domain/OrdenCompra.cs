using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class OrdenCompra
    {
        private int id;
        private string email;
        private string direccion;
        private string estado;
        private int totalProductos;
        private DateTime fecha;
        private float montoCancelar;

        public OrdenCompra(int id, string email, string direccion, string estado, int totalProductos, DateTime fecha, float montoCancelar)
        {
            this.id = id;
            this.email = email;
            this.direccion = direccion;
            this.estado = estado;
            this.totalProductos = totalProductos;
            this.fecha = fecha;
            this.montoCancelar = montoCancelar;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valor invalido");
                }

                id = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Valor invalido");
                }

                direccion = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Valor invalido");
                }

                email = value;
            }
        }


        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Valor invalido");
                }

                estado = value;
            }
        }

        public int TotalProductos
        {
            get
            {
                return totalProductos;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valor invalido");
                }

                totalProductos = value;
            }
        }

        public float MontoCancelar
        {
            get
            {
                return montoCancelar;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valor invalido");
                }

                montoCancelar = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                if (value.ToString("MM/dd/yyyy").Equals(null))
                {
                    throw new Exception("Valor invalido");
                }

                fecha = value;
            }
        }
    }
}
