
namespace EspacioDatos
{
    public class Cadeteria
    {
        private string? nombre;

        private int telefono;
           private List<Cadete> listadoCadetes;

        public string? Nombre { get => nombre; set => nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }



        public Cadeteria(){

        ListadoCadetes = new List<Cadete>();
    }



    }
}