using System.ComponentModel.DataAnnotations.Schema;

namespace EngenhariaObrasApi.Models
{
    public class ObrasMateriais
    {
        public int ObraId { get; set; }
        public Obra Obra { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int Quantidade { get; set; }
    }

}
